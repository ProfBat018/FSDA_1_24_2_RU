using Auth.API.DTOs;
using Auth.API.DTOs.Response;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace Auth.API.Services.Classes;

public class AuthService : IAuthService
{
    private readonly AuthDbContext _context;
    private readonly ITokenService _tokenService;

    public AuthService(AuthDbContext context, ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    public async Task<TypedResult<object>> LoginAsync(LoginRequestDTO request)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);

        if (user == null || !Verify(request.Password, user.Password))
        {
            throw new ArgumentException("Invalid login credetials");
        }

        var userRoles = await _context.UserRoles.Include(ur => ur.Role)
            .Where(ur => ur.UserId == user.Id)
            .Select(r => r.Role.Name).ToListAsync();
        
        var accessToken = await _tokenService.CreateAccessTokenAsync(user, userRoles);

        return TypedResult<object>.Success(new
        {
            AccessToken = accessToken
        }, "Token Created Successfully");
    }
}