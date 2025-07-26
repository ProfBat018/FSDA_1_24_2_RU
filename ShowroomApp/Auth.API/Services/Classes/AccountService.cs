using Auth.API.DTOs;
using Auth.API.DTOs.Response;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using Auth.Data.Data.Models;
using AutoMapper;
using static BCrypt.Net.BCrypt;

namespace Auth.API.Services.Classes;

public class AccountService : IAccountService
{
    private readonly AuthDbContext _context;
    private readonly IMapper _mapper;

    public AccountService(AuthDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
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