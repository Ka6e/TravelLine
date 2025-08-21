using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PropertyRepository : IPropertyRepository
{
    private readonly BookingManagerDbContext _dbContext;

    public PropertyRepository( BookingManagerDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Create( Property property )
    {
        _dbContext.Properties.Add( property );
    }

    public void Delete( Property property )
    {
        property.Delete();
        _dbContext.Properties.Update( property );
    }

    public async Task<List<Property>> GetAll()
    {
        return await _dbContext.Properties.ToListAsync();
    }

    public async Task<Property?> GetById( int id )
    {
        return await _dbContext.Properties.FirstOrDefaultAsync( x => x.Id == id );
    }

    public async Task<List<RoomType>> GetRoomsByProperty(int id)
    {
        return await _dbContext.RoomTypes
            .Where(r => r.PropertyId == id)
            .ToListAsync();
    }
}
