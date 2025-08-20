using Domain.Enum;

namespace Application.DTO;
public class ReservationFilterDTO
{
    public int? PropertyId { get; set; }
    public int? RoomTypeId { get; set; }
    public DateOnly? ArrivalDate { get; set; }
    public DateOnly? DepartureDate { get; set; }
    public TimeOnly? ArrivalTime { get; set; }
    public TimeOnly? DepartureTime { get; set; }
    public string? GuestName { get; set; }
    public string? GuestPhoneNumber { get; set; }
    public decimal? Total { get; set; }
    public Currency? Currency { get; set; }
}
