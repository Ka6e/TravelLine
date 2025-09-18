using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class ReservationExtensions
{
    public static Reservation ConvertToEntity( this ReservationRequestDTO request )
    {
        return new Reservation(
            request.PropertyId,
            request.RoomTypeId,
            request.ArrivalDate,
            request.DepartureDate,
            request.ArrivalTime,
            request.DepartureTime,
            request.Guest.ConvertToEntity(),
            request.Currency );
    }

    public static ReservationResponseDTO ConvertToResponseDto( this Reservation reservation )
    {
        return new ReservationResponseDTO
        {
            PropertyId = reservation.PropertyId,
            RoomTypeId = reservation.RoomTypeId,
            ArrivalDate = reservation.ArrivalDate,
            DepartureDate = reservation.DepartureDate,
            ArrivalTime = reservation.ArrivalTime,
            DepartureTime = reservation.DepartureTime,
            Guest = reservation.Guest.ConvertToDto(),
            Total = reservation.Total,
            Currency = reservation.Currency
        };
    }
}
