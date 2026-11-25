using Hotelmanagement.api.Data;
using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using Hotelmanagement.api.Repositories.Interfaces;
using Hotelmanagement.api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Hotelmanagement.api.Services.Services;

public class AuthService : IAuthService
{
    private readonly IAuthRepo _repo;
    public AuthService(IAuthRepo repo)
    {
        _repo = repo;
    }
    public async Task<bool> UserExists(string email)
    {
        var exsist = await _repo.UserExistsAsync(email);
        return exsist;
    }
    public async Task<User?> LoginAsync(UserLoginDto dto)

    {
        var user = await _repo.LoginAsync(dto);
        return user;
    }
    public async Task<bool> CustomerRegisterAsync(CustomerRegisterdto dto)
    {
        var customer = new User{
            UserName = dto.UserName,
            Email = dto.Email,
            Role = Role.Customers,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };
        var res = await _repo.CustomerRegisterAsync(customer);
        return res;
    }
}
