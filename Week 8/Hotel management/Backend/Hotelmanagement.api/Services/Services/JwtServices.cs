using Hotelmanagement.api.Services.Interfaces;
using Hotelmanagement.api.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;

namespace Hotelmanagement.api.Services.Services;

public class JwtServices : IJwtService
{
    private readonly IConfiguration _configuration;
    public JwtServices(IConfiguration configuration)
    {
        _configuration=configuration;
    }
    public string GenerateToken(User user)
    {
        // * Read JWT configuration
        var key = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Key is missing");
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        //* claims
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role,user.Role.ToString()),
        };
        // * Create signing key
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        // * Create JWT token
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials : credentials
        );

        //* converting token to string 
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
