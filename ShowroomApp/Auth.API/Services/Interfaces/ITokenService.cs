using Auth.Data.Data.Models;

namespace Auth.API.Services.Interfaces;

public interface ITokenService
{
    public Task<string> CreateAccessTokenAsync(User user, List<string> userRoles);
}