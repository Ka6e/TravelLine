using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class PropertyExtensions
{
    public static Property ConvertToEntity( this PropertyDTO propertyDTO )
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

    public static PropertyDTO ConvertToDto( this Property property )
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
}
