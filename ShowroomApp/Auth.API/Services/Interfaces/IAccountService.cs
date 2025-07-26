using Auth.API.DTOs;
using Auth.API.DTOs.Response;

namespace Auth.API.Services.Interfaces;

public interface IAccountService
{
    public Task<Result> RegisterAsync(RegisterRequestDTO request);
    public Task<Result> AssignRoleToUser(string userId, string roleName = "appUser");
}