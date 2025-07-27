using Auth.API.DTOs;
using Auth.API.DTOs.Response;

namespace Auth.API.Services.Interfaces;

public interface IAuthService
{
    public Task<TypedResult<object>> LoginAsync(LoginRequestDTO request);
}