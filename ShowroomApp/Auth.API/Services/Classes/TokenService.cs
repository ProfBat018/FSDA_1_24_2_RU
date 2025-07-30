using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Auth.API.Services.Interfaces;
using Auth.Data.Data.Models;
using Microsoft.IdentityModel.Tokens;

namespace Auth.API.Services.Classes;

public class TokenService : ITokenService
{
    private IConfiguration _configuration;
    

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> CreateAccessTokenAsync(User user, List<string> userRoles)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email)
        };

        foreach (var role in userRoles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:SecretKey").Value));

        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(15),
            issuer: _configuration.GetSection("JWT:Issuer").Value,
            audience: _configuration.GetSection("JWT:Audience").Value,
            signingCredentials: signingCred);

        string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return tokenString;
    }

    public async Task<string> CreateEmailConfirmationTokenAsync(ClaimsPrincipal user)
    {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:EmailKey").Value));

            var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: user.Claims,
                expires: DateTime.UtcNow.AddMinutes(3),
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                audience: _configuration.GetSection("JWT:Audience").Value,
                signingCredentials: signingCred);

            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
    }
    
    public async Task<string> GetEmailFromToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

        if (securityToken == null)
            throw new SecurityTokenException("Invalid token");

        var username = securityToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);

        return username.Value;
    }

    
    public async Task<bool> ValidateEmailConfirmationTokenAsync(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:EmailKey").Value));
        
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _configuration.GetSection("JWT:Issuer").Value,
            ValidAudience = _configuration.GetSection("JWT:Audience").Value,
            IssuerSigningKey = securityKey,
            ClockSkew = TimeSpan.Zero
        };
        
        var principal = await tokenHandler.ValidateTokenAsync(token, validationParameters);

        return principal.IsValid;
    }
}