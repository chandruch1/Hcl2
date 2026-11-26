using Hotelmanagement.api.Data;
using Hotelmanagement.api.Migrations;
using Hotelmanagement.api.Model;
using Hotelmanagement.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Hotelmanagement.api.Repositories.Repositories;

public class HotelRepo : IHotelRepo
{
    private readonly AppDbContext _context;
    public HotelRepo(AppDbContext context)
    {
        _context=context;
    }
    public Task<List<Hotel>> GetHotelAsync()
    {
        return  _context.Hotels.ToListAsync();
    }
    public Task<bool> IsExsist(string email)
    {
        return _context.Hotels.AnyAsync(h => h.HotelMail == email);
    }
    public async Task<Hotel> AddHotelAsync(Hotel hotel)
    
    {
        await _context.Hotels.AddAsync(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }
}
