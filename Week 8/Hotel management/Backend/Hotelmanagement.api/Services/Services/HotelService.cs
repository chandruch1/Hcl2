using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using Hotelmanagement.api.Repositories.Interfaces;
using Hotelmanagement.api.Repositories.Repositories;
using Hotelmanagement.api.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Hotelmanagement.api.Services.Services;

public class HotelService (IHotelRepo _repo): IHotelService
{
    public Task<List<Hotel>> GetHotelAsync()
    {
        return  _repo.GetHotelAsync();
    }
    public async Task<bool> IsExsist(string email)
    {
        var IsExist = await _repo.IsExsist(email);
        return IsExist;
    }
    public async Task<Hotel?> AddHotelAsync(Hotel hotel)
    {
         return await _repo.AddHotelAsync(hotel);
    }
    public async Task<Hotel?> GetHotelById(int id)
    {
        var Hotel = await _repo.GetHotelById(id);
        return Hotel;
    }
    public async Task<Hotel> UpdateHotelAsync(int id,Hotel UpdatedHotel)
    {
        var hotel = new Hotel
        {
            HotelAddress = UpdatedHotel.HotelAddress,
            HotelMail = UpdatedHotel.HotelMail,
            HotelName = UpdatedHotel.HotelName,
            HotelPhoneNo = UpdatedHotel.HotelPhoneNo,
            AvailableRooms = UpdatedHotel.AvailableRooms,
            TotalRooms = UpdatedHotel.TotalRooms,
            OwnerName = UpdatedHotel.OwnerName
        };
        return await _repo.UpdateHotelAsync(hotel);
    }
}
