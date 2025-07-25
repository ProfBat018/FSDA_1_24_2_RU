using Auth.API.DTOs;

namespace Auth.API.Services.Interfaces;

public interface IAccountService
{
    public Task RegisterAsync(RegisterRequestDTO request);
}