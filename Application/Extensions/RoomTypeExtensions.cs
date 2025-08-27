using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class RoomTypeExtensions
{
    public static RoomType ConvertToEntity( this RoomTypeDTO roomTypeDTO)
    {
        return new RoomType(
            roomTypeDTO.PropertyId,
            roomTypeDTO.Name,
            roomTypeDTO.DailyPrice,
            roomTypeDTO.Currency,
            roomTypeDTO.MinPersonCount,
            roomTypeDTO.MaxPersonCount,
            roomTypeDTO.Servicies,
            roomTypeDTO.Amenities );
    }

    public static RoomTypeDTO ConvertToDto( this RoomType roomType )
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
            Amenities = roomType.Amenities
        };
    }
}
