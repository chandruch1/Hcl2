

using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using Microsoft.AspNetCore.Identity.Data;

namespace Hotelmanagement.api.Repositories.Interfaces;

public interface IAuthRepo
{
    public Task<bool> UserExistsAsync(string email);
    public Task<User?> LoginAsync(UserLoginDto dto);
    public Task<bool> CustomerRegisterAsync(User dto);
}
