using Domain.Enums;

namespace Application.DTO;
public class ReservationResponseDTO
{
    public int PropertyId { get; set; }
    public int RoomTypeId { get; set; }
    public DateOnly ArrivalDate { get; set; }
    public DateOnly DepartureDate { get; set; }
    public TimeOnly ArrivalTime { get; set; }
    public TimeOnly DepartureTime { get; set; }
    public GuestDTO Guest { get; set; }
    public decimal Total { get; set; }
    public Currency Currency { get; set; }
}
