using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class AmenityExtensions
{
    public static Amenity ConvertToEntity( this AmenityDTO amenityDTO )
    {
        return new Amenity( amenityDTO.Name, amenityDTO.IsActive );
    }

    public static AmenityDTO ConvertToDto( this Amenity amenity )
    {
        return new AmenityDTO
        {
            Name = amenity.Name,
            IsActive = amenity.IsActive,
        };
    }
}
