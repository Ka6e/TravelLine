using System.Net.Http.Headers;
using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure;

namespace Application.Servicies;
public class PropertyService : IPropertySevice
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService( IPropertyRepository propertyRepository, IUnitOfWork unitOfWork )
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Create( PropertyDTO propertyDTO )
    {
        Property property = Mapper.Mapper.ToProperty( propertyDTO );
        _propertyRepository.Create( property );
        await _unitOfWork.CommitAsync();

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
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<PropertyDTO>> GetAll()
    {
        List<Property> properties = await _propertyRepository.GetAll();
        var filtered = properties.Where(p => p.IsDeleated ==  false );
        
        return filtered.Select( p => Mapper.Mapper.ToPropertyDTO( p ) ).ToList();
    }

    public async Task<PropertyDTO?> GetById( int id )
    {
        Property property = await _propertyRepository.GetById( id );
        return property == null ? null : Mapper.Mapper.ToPropertyDTO( property );
    }

    public async Task Update( int id, PropertyDTO propertyDTO )
    {
        Property property = await _propertyRepository.GetById( id );
        if ( property == null )
        {
            throw new KeyNotFoundException( $"Property with id {id} not found." );
        }
        UpdateProperty( property, propertyDTO );
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<RoomTypeDTO>> GetRoomTypesProperty( int id )
    {
        List<RoomType> rooms = await _propertyRepository.GetRoomsByProperty( id );
        if ( rooms == null )
        {
            throw new KeyNotFoundException( $"Property with id {id} not found." );
        }

        return rooms == null ? null : rooms.Select( r => Mapper.Mapper.ToRoomTypeDTO( r ) ).ToList();
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
