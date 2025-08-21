using Domain.Enum;

namespace Application.DTO;
public class RoomTypeRequestDTO
{
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public Currency Currency { get; set; }
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
    public RoomServicie Servicies { get; set; }
    public Amenity Amenities { get; set; }
}
