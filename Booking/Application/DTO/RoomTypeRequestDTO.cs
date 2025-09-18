using Domain.Enums;

namespace Application.DTO;
public class RoomTypeRequestDTO
{
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public decimal DailyPrice { get; set; }
    public Currency Currency { get; set; }
    public int MinPersonCount { get; set; }
    public int MaxPersonCount { get; set; }
}
