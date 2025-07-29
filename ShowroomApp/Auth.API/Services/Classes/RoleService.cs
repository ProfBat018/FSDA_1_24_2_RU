using Auth.API.DTOs;
using Auth.API.DTOs.Response;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using Auth.Data.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Services.Classes;

public class RoleService : IRoleService
{
    private readonly AuthDbContext _context;

    public RoleService(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedResult<object>> GetAllRolesAsync(int page, int contentPerPage)
    {
        var allResCount = await _context.Roles.CountAsync();

        var res = await _context.Roles
            .Skip((page - 1) * contentPerPage)
            .Take(contentPerPage)
            .Select(r => new { RoleId = r.Id, RoleName = r.Name })
            .ToListAsync();

        return PaginatedResult<object>.Success(res, allResCount);
    }

    public async Task<TypedResult<object>> GetRoleByIdAsync(string id)
    {
        Role role = await _context.Roles.FindAsync(id);

        return TypedResult<object>.Success(new
        {
            Id = role.Id,
            Name = role.Name
        });
    }

    public async Task<Result> UpsertRoleAsync(UpsertRoleRequestDto request)
    {
        string message; 
        var role = await _context.Roles.FindAsync(request.RoleId);

        if (request.RoleId != null && role != null)
        {
            role.Name = request.RoleName;
            message = "Role updated";
        }
        else
        {
            message = "Role added";
            await _context.Roles.AddAsync(new() { Name = request.RoleName });
        }

        await _context.SaveChangesAsync();
        return Result.Success(message);
    }
    

    public async Task<Result> RemoveRoleAsync(RemoveRoleRequestDto request)
    {
        var role = await _context.Roles.FindAsync(request.RoleId);

        if (role == null)
        {
            throw new Exception("Role not found");
        }
        _context.Roles.Remove(role);
        await _context.SaveChangesAsync();
        
        return Result.Success();
    }

    public async Task<Result> AssignRoleAsync(UserRoleRequestDto request)
    {
        var roleId = (await _context.Roles.FindAsync(request.RoleId)).Id;
        var userId = (await _context.Users.FindAsync(request.UserId)).Id;
        
        if (roleId == null || userId == null)
            throw new Exception("Role not found");

        await _context.UserRoles.AddAsync(new()
        {
            RoleId = roleId,
            UserId = userId
        });

        await _context.SaveChangesAsync();

        return Result.Success();
    }

    public async Task<Result> UnAssignRoleAsync(UserRoleRequestDto request)
    {
        var roleId = (await _context.Roles.FindAsync(request.RoleId)).Id;
        var userId = (await _context.Users.FindAsync(request.UserId)).Id;
        
        if (roleId == null || userId == null)
            throw new Exception("Role not found");

        var userRole = await _context.UserRoles.FindAsync(new UserRole()
        {
            UserId = userId,
            RoleId = roleId
        });
        
        if (userRole == null)
        {
            throw new Exception("User does not hav this role");
        }
        _context.UserRoles.Remove(userRole);

        await _context.SaveChangesAsync();
        return Result.Success();
    }
}