using Hotelmanagement.api.Model;

namespace Hotelmanagement.api.Services.Interfaces;

public interface IHotelService
{
    Task<List<Hotel>> GetHotelAsync();
    Task<bool> IsExsist(string email);
    Task<Hotel?> AddHotelAsync(Hotel hotel);
    Task<Hotel?> GetHotelById(int id);
}
