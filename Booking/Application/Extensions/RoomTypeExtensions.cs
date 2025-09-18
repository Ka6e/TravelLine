using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class RoomTypeExtensions
{
    public static RoomType ConvertToEntity( this RoomTypeRequestDTO requestDTO )
    {

        return new RoomType(
            requestDTO.PropertyId,
            requestDTO.Name,
            requestDTO.DailyPrice,
            requestDTO.Currency,
            requestDTO.MinPersonCount,
            requestDTO.MaxPersonCount
            );
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
            Servicies = roomType.RoomServices.Select( s => s.Service.ConvertToDto() ).ToList(),
            Amenities = roomType.RoomAmenities.Select( a => a.Amenity.ConvertToDto() ).ToList()
        };
    }
}
