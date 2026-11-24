using System.Reflection.Metadata.Ecma335;
using Hotelmanagement.api.Data;
using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hotelmanagement.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _services;
    private readonly IJwtService _JwtService;
    public AuthController(IAuthService service,IJwtService jwtService)
    {
        _services = service;
        _JwtService=jwtService;
    }

    [HttpPost("admin-login")]
    public async Task<ActionResult> AdminLogin(Adminlogindto dto)
    {
        var exsist = await _services.UserExists(dto.Email);
        if (!exsist)
        {
            return new ConflictObjectResult(new
            {
                Message = "Please Register"
            });
        }
        var user = await _services.LoginAdminAsync(dto);
        if(user == null)
        {
            return Unauthorized("Invalid email or password");
        }
        var token = _JwtService.GenerateToken(user);
        return Ok(new
        {
            Token = token,
            UserMail = dto.Email
        });
    }
}
