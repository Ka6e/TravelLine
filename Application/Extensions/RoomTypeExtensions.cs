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
