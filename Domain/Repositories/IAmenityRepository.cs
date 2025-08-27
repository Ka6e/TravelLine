using Domain.Entities;

namespace Domain.Repositories;
public interface IAmenityRepository
{
    public void Create( Amenity amenity );
    public Task<Amenity> GetById( int id );
    public Task<List<Amenity>> GetAll();
    public void Activate ( Amenity amenity );
    public void Disactivate( Amenity amenity );
}
