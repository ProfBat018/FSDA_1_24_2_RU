using Auth.API.DTOs;
using Auth.API.Services.Interfaces;
using Auth.Data.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDTO request)
    {
        var res = await _authService.LoginAsync(request);

        return Ok(res);
    }

    [Authorize(Roles = "AppAdmin")]
    [HttpGet("Test")]
    public async Task<IActionResult> Test()
    {
        return Ok("success");
    }
}