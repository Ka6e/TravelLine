using Application.DTO;
using Application.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class PropertyService : IPropertySevice
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService( IPropertyRepository propertyRepository )
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<int> Create( PropertyDTO propertyDTO )
    {
        Property property = propertyDTO.ConvertToEntity();
        _propertyRepository.Create( property );

        return property.Id;
    }

    public async Task Delete( int id )
    {
        Property property = await _propertyRepository.GetById( id );
        if ( property == null )
        {
            throw new KeyNotFoundException( $"Property with {nameof( id )} {id} not found." );
        }

        _propertyRepository.Delete( property );
    }

    public async Task<List<PropertyDTO>> GetAll()
    {
        List<Property> properties = await _propertyRepository.GetAll();

        return properties.Select( p => p.ConvertToDto() ).ToList();
    }

    public async Task<PropertyDTO?> GetById( int id )
    {
        Property property = await _propertyRepository.GetById( id );
        return property == null ? null : property.ConvertToDto();
    }

    public async Task Update( int id, PropertyDTO propertyDTO )
    {
        Property property = await _propertyRepository.GetById( id );
        if ( property == null )
        {
            throw new KeyNotFoundException( $"Property with id {id} not found." );
        }
        UpdateProperty( property, propertyDTO );
    }

    public async Task<List<RoomTypeDTO>> GetRoomTypesProperty( int id )
    {
        List<RoomType> rooms = await _propertyRepository.GetRoomsByProperty( id );
        if ( rooms == null )
        {
            throw new KeyNotFoundException( $"Property with id {id} not found." );
        }

        return rooms == null ? null : rooms.Select( r => r.ConvertToDto() ).ToList();
    }


    private void UpdateProperty( Property property, PropertyDTO propertyDTO )
    {
        property.SetName( propertyDTO.Name );
        property.SetCountry( propertyDTO.Country );
        property.SetCity( propertyDTO.City );
        property.SetAddress( propertyDTO.Address );
        property.SetCoordinats( propertyDTO.Latitude, propertyDTO.Longitude );
    }
}
