using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class RoomTypeRepository : IRoomTypeRepository
{
    private BookingManagerDbContext _dbContext;

    public RoomTypeRepository( BookingManagerDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Create( RoomType roomType )
    {
        _dbContext.RoomTypes.Add( roomType );
    }

    public void Delete( RoomType roomType )
    {
        roomType.Delete();
        _dbContext.RoomTypes.Update( roomType );
    }

    public async Task<List<RoomType>> GetAll()
    {
        return await _dbContext.RoomTypes
            .Where( rt => rt.IsDeleted == false )
            .Include( rt => rt.Services )
            .Include( rt => rt.Amenities )
            .ToListAsync();
    }

    public async Task<RoomType?> GetById( int id )
    {
        return await _dbContext.RoomTypes.FirstOrDefaultAsync( r => r.Id == id );
    }
}
