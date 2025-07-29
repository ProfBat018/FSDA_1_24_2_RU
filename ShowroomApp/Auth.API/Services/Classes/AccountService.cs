using System.Text;
using Auth.API.DTOs;
using Auth.API.DTOs.Response;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using Auth.Data.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace Auth.API.Services.Classes;

public class AccountService : IAccountService
{
    private readonly AuthDbContext _context;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;
    private readonly ITokenService _tokenService;

    public AccountService(AuthDbContext context, IMapper mapper, IWebHostEnvironment env, ITokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _env = env;
        _tokenService = tokenService;
    }

    public async Task<Result> ConfirmEmailAsync(HttpContext context, string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        
        var filePath = Path.Combine(_env.WebRootPath, "wwwroot", $"EmailConfirmation.html");

        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Email template EmailConfirmation.html not found at {filePath}");

        var text = new StringBuilder(await File.ReadAllTextAsync(filePath));

        var token = await _tokenService.CreateEmailConfirmationTokenAsync(user);


        // context.Request.Scheme берет http или https в зависимости от того как проект запущен
        // context.Request.Host - это адресс и порт по которому был запущен ваш проект 
        // остальное это путь к контроллеру
        var link =
            $"{context.Request.Scheme}://{context.Request.Host}/api/v1/Account/Email/Verify?token={token}";
        text.Replace("{Username}", user.Username);
        text.Replace("{ConfirmationLink}", user);
        

    }

    public async Task<Result> RegisterAsync(RegisterRequestDTO request)
    {  
        var mappingRes = _mapper.Map<RegisterRequestDTO, User>(request);
        
        mappingRes.Password = HashPassword(request.Password);
       
        _context.Users.Add(mappingRes);

        await AssignRoleToUser(mappingRes.Id);

        await _context.SaveChangesAsync();
       
        return Result.Success("User Successfully registered");
    }

    public async Task<Result> AssignRoleToUser(string userId, string roleName = "AppUser")
    {
        var role = _context.Roles.First(r => r.Name == roleName);

        _context.UserRoles.Add(new() { UserId = userId, RoleId = role.Id });
        
        return Result.Success();
    }
}