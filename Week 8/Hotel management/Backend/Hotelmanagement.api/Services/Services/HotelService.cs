using Hotelmanagement.api.Model;
using Hotelmanagement.api.Repositories.Interfaces;
using Hotelmanagement.api.Repositories.Repositories;
using Hotelmanagement.api.Services.Interfaces;

namespace Hotelmanagement.api.Services.Services;

public class HotelService : IHotelService
{
    private readonly IHotelRepo _repo;
    public HotelService(IHotelRepo repo)
    {
        _repo=repo;
    }
    public Task<List<Hotel>> GetHotelAsync()
    {
        return  _repo.GetHotelAsync();
    }

    public async Task<bool> IsExist(string email)
    {
        var IsExist = await _repo.IsExsist(email);
        return IsExist;
    }
    public async Task<Hotel?> AddHotelAsync(Hotel hotel)
    {
         return await _repo.AddHotelAsync(hotel);
    }
}
