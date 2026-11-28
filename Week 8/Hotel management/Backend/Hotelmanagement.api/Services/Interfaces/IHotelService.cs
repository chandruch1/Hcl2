using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hotelmanagement.api.Services.Interfaces;

public interface IHotelService
{
    Task<List<Hotel>> GetHotelAsync();
    Task<bool> IsExsist(string email);
    Task<Hotel?> AddHotelAsync(Hotel hotel);
    Task<Hotel?> GetHotelById(int id);
    Task<Hotel> UpdateHotelAsync(int id, Hotel UpdatedHotel);
}
