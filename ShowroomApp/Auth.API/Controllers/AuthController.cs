using Auth.Data.Data;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> LoginAsync()
    {
        throw new NotImplementedException();
    }
}