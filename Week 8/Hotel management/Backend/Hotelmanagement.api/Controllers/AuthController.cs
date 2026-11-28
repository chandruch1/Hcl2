using System.Reflection.Metadata.Ecma335;
using Hotelmanagement.api.Data;
using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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

    [HttpPost("User-login")]
    public async Task<ActionResult> UserLogin([FromBody] UserLoginDto dto)
    {
        var exsist = await _services.UserExists(dto.Email);
        if (!exsist)
        {
            return new ConflictObjectResult(new
            {
                Message = "Please Register"
            });
        }
        var user = await _services.LoginAsync(dto);
        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }
        var token = _JwtService.GenerateToken(user);
        return Ok(new
        {
            Token = token,
            UserMail = dto.Email,
        });
    }
    [HttpPost("customer-Register")]
    public async Task<ActionResult> CustomerRegister([FromBody] CustomerRegisterdto dto)
    {
        var exsist = await _services.UserExists(dto.Email);
        if (exsist)
        {
            return new ConflictObjectResult(new
            {
                message = "Already Register Please Login"
            });
        }
        var register = await _services.CustomerRegisterAsync(dto);
        if (!register)
        {
            return new ConflictObjectResult("Something wrong");
        }
        return Ok(new{ message="Register Succesfully"});
    }
}
