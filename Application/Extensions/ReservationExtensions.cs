using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class ReservationExtensions
{
    public static Reservation ConvertToEntity( this ReservationDTO reservationDTO )
    {
        return new Reservation(
            reservationDTO.PropertyId,
            reservationDTO.RoomTypeId,
            reservationDTO.ArrivalDate,
            reservationDTO.DepartureDate,
            reservationDTO.ArrivalTime,
            reservationDTO.DepartureTime,
            reservationDTO.GuestName,
            reservationDTO.GuestPhoneNumber,
            reservationDTO.Currency
            );
    }

    public static ReservationDTO ConvertToDto( this Reservation reservation )
    {
        return new ReservationDTO
        {
            PropertyId = reservation.PropertyId,
            RoomTypeId = reservation.RoomTypeId,
            ArrivalDate = reservation.ArrivalDate,
            DepartureDate = reservation.DepartureDate,
            ArrivalTime = reservation.ArrivalTime,
            DepartureTime = reservation.DepartureTime,
            GuestName = reservation.GuestName,
            GuestPhoneNumber = reservation.GuestPhoneNumber,
            Currency = reservation.Currency
        };
    }

    public static ReservationResponseDTO ConvertToResponseDto(this Reservation reservation )
    {
        return new ReservationResponseDTO
        {
            PropertyId = reservation.PropertyId,
            RoomTypeId = reservation.RoomTypeId,
            ArrivalDate = reservation.ArrivalDate,
            DepartureDate = reservation.DepartureDate,
            ArrivalTime = reservation.ArrivalTime,
            DepartureTime = reservation.DepartureTime,
            GuestName = reservation.GuestName,
            Total = reservation.Total,
            Currency = reservation.Currency
        };
    }
}
