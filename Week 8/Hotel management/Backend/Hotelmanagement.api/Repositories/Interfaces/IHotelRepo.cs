using Hotelmanagement.api.Data;
using Hotelmanagement.api.Model;

namespace Hotelmanagement.api.Repositories.Interfaces;

public interface IHotelRepo
{
    Task<List<Hotel>> GetHotelAsync();
    Task<bool> IsExsist(string email);
    Task<Hotel> AddHotelAsync(Hotel hotel);
    Task<Hotel?> GetHotelById(int id);
    Task<Hotel> UpdateHotelAsync(Hotel hotel);
}
