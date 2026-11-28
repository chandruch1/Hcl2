using Hotelmanagement.api.Data;
using Hotelmanagement.api.Migrations;
using Hotelmanagement.api.Model;
using Hotelmanagement.api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace Hotelmanagement.api.Repositories.Repositories;

public class HotelRepo(AppDbContext _context)  : IHotelRepo
{
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
    public async Task<Hotel?> GetHotelById(int id)
    {
        return await _context.Hotels.FindAsync(id);
    }
    public async Task<Hotel> UpdateHotelAsync(Hotel hotel)
    {
        _context.Hotels.Update(hotel);
        await _context.SaveChangesAsync();
        return hotel;
    }
}
