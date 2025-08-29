using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class RoomTypeExtensions
{
    public static RoomType ConvertToEntity( this RoomTypeDTO roomTypeDTO )
    {
        //List<Service> services = roomTypeDTO.Servicies.Select( s => s.ConvertToEntity() ).ToList();
        //List<Amenity> amenities = roomTypeDTO.Amenities.Select( s => s.ConvertToEntity() ).ToList();

        RoomType room = new RoomType(
            roomTypeDTO.PropertyId,
            roomTypeDTO.Name,
            roomTypeDTO.DailyPrice,
            roomTypeDTO.Currency,
            roomTypeDTO.MinPersonCount,
            roomTypeDTO.MaxPersonCount
            );

        //room.SetServicies( services );
        //room.SetAmenities( amenities );

        return room;
    }

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

    public static RoomType ConvertToEntity( this RoomTypeUpdate roomType )
    {
        return new RoomType(
            roomType.PropertyId,
            roomType.Name,
            roomType.DailyPrice,
            roomType.Currency,
            roomType.MinPersonCount,
            roomType.MaxPersonCount
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
            Servicies = roomType.Services.Select( s => s.ConvertToDto() ).ToList(),
            Amenities = roomType.Amenities.Select( a => a.ConvertToDto() ).ToList()
        };
    }
}
