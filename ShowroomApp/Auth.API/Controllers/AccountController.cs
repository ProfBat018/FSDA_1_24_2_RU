using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterAsync()
    {
        throw new NotImplementedException();
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