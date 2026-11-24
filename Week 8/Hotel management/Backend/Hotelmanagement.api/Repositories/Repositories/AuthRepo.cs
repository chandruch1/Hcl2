using Hotelmanagement.api.Data;
using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotelmanagement.api.Repositories.Interfaces;

public class AuthRepo : IAuthRepo
{
    private readonly AppDbContext _context;
    public AuthRepo(AppDbContext context)
    {
        _context = context;
    }
    public async Task<bool> UserExistsAsync(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> AdminLoginAsync(Adminlogindto dto)
    {
        var user =await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        return user;
    }
}
