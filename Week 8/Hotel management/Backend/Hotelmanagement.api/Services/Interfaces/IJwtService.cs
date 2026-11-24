using Hotelmanagement.api.Model;
using Microsoft.IdentityModel.Tokens;

namespace Hotelmanagement.api.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
