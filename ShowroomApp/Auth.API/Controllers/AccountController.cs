using Auth.API.DTOs;
using Auth.API.Services.Classes;
using Auth.API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;


    public AccountController(IAccountService accountService, ITokenService tokenService)
    {
        _accountService = accountService;
        _tokenService = tokenService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestDTO request)
    {
        var res = await _accountService.RegisterAsync(request);
        return Ok(res);
    }

    [HttpGet("Email/Verify/{id}/{token}")]
    public async Task<IActionResult> VerifyEmailAsync(string id, string token)
    {
        var res = await _tokenService.ValidateEmailConfirmationTokenAsync(token);
        var emailFromToken = await _tokenService.GetEmailFromToken(token);

        var userId = await _accountService.GetIdByEmailAsync(emailFromToken);

        if (res && userId == id)
        {
            await _accountService.VerifyEmailAsync(userId);
        }
        return Ok(res ? "Email verified successfully" : "Invalid or expired token");
    }

    [Authorize]
    [HttpPost("Email/Confirm")]
    public async Task<IActionResult> ConfirmEmailAsync()
    {
        var token = await _tokenService.CreateEmailConfirmationTokenAsync(User);
        await _accountService.ConfirmEmailAsync(HttpContext, User, token);
        return Ok("Email sent");
    }
}