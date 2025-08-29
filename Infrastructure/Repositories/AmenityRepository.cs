using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class AmenityRepository : IAmenityRepository
{
    private readonly BookingManagerDbContext _dbContext;

    public AmenityRepository( BookingManagerDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Create( Amenity amenity )
    {
        _dbContext.Amenities.Add( amenity );
    }

    public void Activate( Amenity amenity )
    {
        amenity.SetActive( true );
        _dbContext.Amenities.Update( amenity );
    }

    public void Disactivate( Amenity amenity )
    {
        amenity.SetActive( false );
        _dbContext.Amenities.Update( amenity );
    }

    public async Task<List<Amenity>> GetAll()
    {
        return await _dbContext.Amenities.ToListAsync();
    }

    public async Task<Amenity> GetById( int id )
    {
        return await _dbContext.Amenities.FirstOrDefaultAsync( a => a.Id == id );
    }

    public async Task<List<Amenity>> GetByIds( List<int> ids )
    {
        return await _dbContext.Amenities
            .Where( a => ids.Contains( a.Id ) )
            .AsNoTracking()
            .ToListAsync();
    }
}
