using Auth.API.DTOs;
using Auth.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDTO request)
    {
        var res = await _accountService.RegisterAsync(request);
        return Ok(res);
    }
    
    [HttpPost("Email/Verify")]
    public async Task<IActionResult> VerifyEmailAsync()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost("Email/Confirm")]
    public async Task<IActionResult> ConfirmEmailAsync()
    {
        throw new NotImplementedException();
    }
    
}