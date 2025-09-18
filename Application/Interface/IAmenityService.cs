using Application.DTO;

namespace Application.Interface;
public interface IAmenityService
{
    public Task<int> Create( AmenityDTO amenity );
    public Task Update( int id, AmenityDTO amenity );
    public Task<AmenityDTO?> GetById( int id );
    public Task<List<AmenityDTO>> GetAll();
}
