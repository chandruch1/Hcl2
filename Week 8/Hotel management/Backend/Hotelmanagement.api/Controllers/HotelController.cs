using System.Diagnostics;
using Hotelmanagement.api.DTOs;
using Hotelmanagement.api.Model;
using Hotelmanagement.api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi;
namespace Hotelmanagement.api.Controllers;

[ApiController]
[Route("api/hotel")]
public class HotelController : ControllerBase
{
    private readonly IHotelService _service;
    public HotelController(IHotelService service)
    {
        _service=service;
    }
    [HttpGet]
    public async Task<ActionResult> GetHotelAsync()
    {
        var Hotels = await _service.GetHotelAsync();
        return Ok(Hotels);
    }
    [HttpPost("hotel-add")]
    public async Task<ActionResult> AddHotelAsync(AddHotelDto dto)
    {
        var exsist = await _service.IsExist(dto.HotelMail);
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
        return CreatedAtAction(result);
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult?> GetHotelById(int id)
    {
        
    }

}

