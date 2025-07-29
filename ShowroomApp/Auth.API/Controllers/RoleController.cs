using Auth.API.DTOs;
using Auth.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[Authorize(Policy = "AdminPolicy")]
[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet("All/{page}/{pageSize}")]
    public async Task<IActionResult> GetAllRolesAsync(int page=1, int pageSize=15)
    {
        return Ok(await _roleService.GetAllRolesAsync(page, pageSize));
    }
    
    [HttpPost("New")]
    public async Task<IActionResult> AddNewRoleAsync(UpsertRoleRequestDto request)
    {
        return Ok(await _roleService.UpsertRoleAsync(request));
    }
    
    [HttpDelete("Remove")]
    public async Task<IActionResult> RemoveRoleAsync(RemoveRoleRequestDto request)
    {
        return Ok(await _roleService.RemoveRoleAsync(request));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRoleAsync(string id)
    {
        return Ok(await _roleService.GetRoleByIdAsync(id));
    }

    
    [HttpPost("Assign")]
    public async Task<IActionResult> AssignRoleAsync(UserRoleRequestDto request)
    {
        throw new NotImplementedException();
    }

    [HttpGet("UnAssign")]
    public async Task<IActionResult> UnAssignRoleAsync(UserRoleRequestDto request)
    {
        throw new NotImplementedException();
    }
}