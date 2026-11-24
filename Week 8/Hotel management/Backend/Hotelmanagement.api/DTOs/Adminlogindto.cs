using Scalar.AspNetCore;

namespace Hotelmanagement.api.DTOs;

public class Adminlogindto
{
    public string Email { get; set; } = string.Empty;
    public string PassWord { get; set; } = string.Empty;
}
