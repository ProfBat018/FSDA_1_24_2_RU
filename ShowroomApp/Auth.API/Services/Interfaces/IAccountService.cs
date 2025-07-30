using System.Security.Claims;
using Auth.API.DTOs;
using Auth.API.DTOs.Response;

namespace Auth.API.Services.Interfaces;

public interface IAccountService
{
    public Task VerifyEmailAsync(string id);
    public Task<Result> ConfirmEmailAsync(HttpContext context, ClaimsPrincipal User, string token);
    public Task<Result> RegisterAsync(RegisterRequestDTO request);
    public Task<string> GetIdByEmailAsync(string email);
}