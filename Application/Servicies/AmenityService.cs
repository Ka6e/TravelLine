using Application.DTO;
using Application.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class AmenityService : IAmenityService
{
    private readonly IAmenityRepository _repository;

    public AmenityService(IAmenityRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Create( AmenityDTO amenityDto )
    {
        Amenity amenity = amenityDto.ConvertToEntity();
        _repository.Create( amenity );

        return amenity.Id;
    }

    public async Task<List<AmenityDTO>> GetAll()
    {
        List<Amenity> amenities = await _repository.GetAll();
        
        return amenities.Select( a => a.ConvertToDto()).ToList();
    }

    public async Task<AmenityDTO?> GetById( int id )
    {
        Amenity amenity = await _repository.GetById( id );

        return amenity == null ? null : amenity.ConvertToDto();
    }

    public async Task Update( int id, AmenityDTO amenityDto )
    {
        Amenity amenity = await _repository.GetById( id );
        if( amenity == null )
        {
            throw new KeyNotFoundException( "This amenity doesnt exist." );
        }

        amenity.ValidateString( amenityDto.Name );
    }
}
