namespace Hotelmanagement.api.DTOs;

public class UpdateHoteldto
{
    public string HotelName { get; set; } = string.Empty;
    public string HotelMail { get; set; } = string.Empty;
    public long HotelPhoneNo { get; set; }
    public int TotalRooms { get; set; }
    public int AvailableRooms { get; set; }
    public string HotelAddress { get; set; }=string.Empty;
    public string OwnerName { get; set; } = string.Empty;
}
