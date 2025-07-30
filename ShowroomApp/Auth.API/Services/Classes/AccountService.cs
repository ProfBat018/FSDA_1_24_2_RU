using System.Security.Claims;
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
    private readonly EmailService _emailService;

    public AccountService(AuthDbContext context, IMapper mapper, IWebHostEnvironment env, ITokenService tokenService,
        EmailService emailService)
    {
        _context = context;
        _mapper = mapper;
        _env = env;
        _emailService = emailService;
    }

    public async Task VerifyEmailAsync(string id)
    {
        var user = await _context.Users.FindAsync(id);
        user.IsConfirmed = true;
        await _context.SaveChangesAsync();
    }

    public async Task<Result> ConfirmEmailAsync(HttpContext context, ClaimsPrincipal user, string token)
    {
        var userEmail = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
        var username = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
        var userId = await _context.Users.Where(u => u.Email == userEmail).Select(u => u.Id).FirstOrDefaultAsync();

        var filePath = Path.Combine(_env.WebRootPath, "EmailConfirmation.html");

        var text = new StringBuilder(await File.ReadAllTextAsync(filePath));


        var link = $"{context.Request.Scheme}://{context.Request.Host}/api/Account/Email/Verify/{userId}/{token}";

        text.Replace("{Username}", username);
        text.Replace("{ConfirmationLink}", link);

        await _emailService.SendEmailAsync(userEmail, username, "Email Confirmation", text.ToString());

        return Result.Success();
    }


    public async Task<Result> RegisterAsync(RegisterRequestDTO request)
    {
        var mappingRes = _mapper.Map<RegisterRequestDTO, User>(request);

        mappingRes.Password = HashPassword(request.Password);

        _context.Users.Add(mappingRes);

        await _context.SaveChangesAsync();

        return Result.Success("User Successfully registered");
    }

    public async Task<string> GetIdByEmailAsync(string email)
    {
        return await _context.Users
            .Where(u => u.Email == email)
            .Select(u => u.Id)
            .FirstOrDefaultAsync();
    }
}