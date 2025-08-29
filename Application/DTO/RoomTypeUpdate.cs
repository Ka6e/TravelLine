using Domain.Enums;

namespace Application.DTO;
public class RoomTypeUpdate
{
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public Currency Currency { get; set; }
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
    public List<ServiceDTO> Servicies { get; set; }
    public List<AmenityDTO> Amenities { get; set; }
}
