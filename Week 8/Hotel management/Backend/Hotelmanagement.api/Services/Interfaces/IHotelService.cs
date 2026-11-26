using Hotelmanagement.api.Model;

namespace Hotelmanagement.api.Services.Interfaces;

public interface IHotelService
{
    Task<List<Hotel>> GetHotelAsync();
    Task<bool> IsExist(string email);
    Task<Hotel?> AddHotelAsync(Hotel hotel);
}
