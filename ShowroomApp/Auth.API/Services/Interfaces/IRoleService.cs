using Auth.API.DTOs;
using Auth.API.DTOs.Response;
using Auth.Data.Data.Models;

namespace Auth.API.Services.Interfaces;

public interface IRoleService
{
    public Task<PaginatedResult<object>> GetAllRolesAsync(int page, int contentPerPage);
    public Task<TypedResult<object>> GetRoleByIdAsync(string id);
    public Task<Result> UpsertRoleAsync(UpsertRoleRequestDto request);
    public Task<Result> RemoveRoleAsync(RemoveRoleRequestDto request);
    public Task<Result> AssignRoleAsync(UserRoleRequestDto request);
    public Task<Result> UnAssignRoleAsync(UserRoleRequestDto request);
    
    
}
