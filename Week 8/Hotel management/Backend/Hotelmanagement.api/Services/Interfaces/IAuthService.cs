using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;

namespace Hotelmanagement.api.Services.Interfaces;

public interface IAuthService
{
     Task<bool> UserExists(string Email);
     Task<User?> LoginAdminAsync(Adminlogindto dto);
}
