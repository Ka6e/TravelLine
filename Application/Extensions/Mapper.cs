using Application.DTO;
using Domain.Entities;

namespace Application.Mapper;
public class Mapper
{
    public static PropertyDTO ToPropertyDTO( Property property )
    {
        return new PropertyDTO
        {
            Name = property.Name,
            Country = property.Country,
            City = property.City,
            Address = property.Address,
            Latitude = property.Latitude,
            Longitude = property.Longitude
        };
    }

    public static Property ToProperty(PropertyDTO propertyDTO)
    {
        return new Property(
            propertyDTO.Name,
            propertyDTO.Country,
            propertyDTO.City,
            propertyDTO.Address,
            propertyDTO.Latitude,
            propertyDTO.Longitude
            );
    }

    public static RoomTypeDTO ToRoomTypeDTO( RoomType roomType )
    {
        return new RoomTypeDTO
        {
            PropertyId = roomType.PropertyId,
            Name = roomType.Name,
            DailyPrice = roomType.DailyPrice,
            Currency = roomType.Currency,
            MinPersonCount = roomType.MinPersonCount,
            MaxPersonCount = roomType.MaxPersonCount,
            Servicies = roomType.Servicies,
            Amenities = roomType.Amenities,
        };
    }

    public static RoomType ToRoomType( RoomTypeDTO roomTypeDTO )
    {
        return new RoomType(
            roomTypeDTO.PropertyId,
            roomTypeDTO.Name,
            roomTypeDTO.DailyPrice,
            roomTypeDTO.Currency,
            roomTypeDTO.MinPersonCount,
            roomTypeDTO.MaxPersonCount,
            roomTypeDTO.Servicies,
            roomTypeDTO.Amenities
            );
    }

    public static Reservation ToReservation(ReservationDTO reservationDTO )
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

    public static ReservationResponseDTO ToReservationResponseDTO(Reservation reservation)
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

    public static ReservationDTO ToResevationDTO( Reservation reservation )
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
}
