using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
internal class ServiceRepository : IServiceRepository
{
    private readonly BookingManagerDbContext _dbContext;

    public ServiceRepository( BookingManagerDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Create( Service servcie )
    {
        _dbContext.Services.Add( servcie );
    }

    public async Task<List<Service>> GetAll()
    {
        return await _dbContext.Services.ToListAsync();
    }

    public async Task<Service> GetById( int id )
    {
        return await _dbContext.Services.FirstOrDefaultAsync( s => s.Id == id );
    }

    public async Task<List<Service>> GetByIds( List<int> ids )
    {
        return await _dbContext.Services
            .Where( s => ids.Contains( s.Id ) )
            .AsNoTracking()
            .ToListAsync();
    }
}
