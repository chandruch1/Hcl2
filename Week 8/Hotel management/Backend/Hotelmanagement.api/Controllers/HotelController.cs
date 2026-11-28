using System.Diagnostics;
using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using Hotelmanagement.api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace Hotelmanagement.api.Controllers;
[ApiController]
[Route("api/hotel")]
public class HotelController(IHotelService _service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> GetHotelAsync()
    {
        var Hotels = await _service.GetHotelAsync();
        return Ok(Hotels);
    }
    [HttpPost("hotel-add")]
    public async Task<ActionResult> AddHotelAsync([FromBody] AddHotelDto dto)
    {
        var exsist = await _service.IsExsist(dto.HotelMail);
        if (exsist)
        {
            return new ConflictObjectResult(new
            {
                Message = "Hotel Already Register"
            });
        }
        var Hotel = new Hotel
        {
            HotelAddress = dto.HotelAddress,
            HotelPhoneNo = dto.HotelPhoneNo,
            HotelMail = dto.HotelMail,
            HotelName = dto.HotelName,
            OwnerName = dto.OwnerName,
            AvailableRooms = dto.AvailableRooms,
            TotalRooms = dto.TotalRooms
        };
        var result = await _service.AddHotelAsync(Hotel);
        return CreatedAtAction(nameof(GetHotelById),new { id = result?.HotelId },result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult?> GetHotelById([FromRoute] int id)
    {
        var Hotel = await _service.GetHotelById(id);
        return Ok(Hotel);
    }
    [HttpPut("update-hotel/{id}")]
    public async Task<IActionResult> UpdateHotel([FromRoute] int id,[FromBody] UpdateHoteldto dto)
    {
        var hotel = await _service.GetHotelById(id);
        if (hotel == null)
        {
            return NotFound(new{Message="Hotel Not Found"});
        }
        var result = await _service.UpdateHotelAsync(id, hotel);
        if(result == null)
        {
            return NotFound(new{Message="Hotel Not Found"});
        }
        return Ok(hotel);
    }
}

