using System.Security.Claims;
using Auth.Data.Data.Models;

namespace Auth.API.Services.Interfaces;

public interface ITokenService
{
    public Task<string> CreateAccessTokenAsync(User user, List<string> userRoles);
    public Task<string> CreateEmailConfirmationTokenAsync(ClaimsPrincipal user);

    public Task<string> GetEmailFromToken(string token);
    public Task<bool> ValidateEmailConfirmationTokenAsync(string token);
}