using Domain.Repositories;

namespace Infrastructure;
public class UnitOfWork : IUnitOfWork
{
    private readonly BookingManagerDbContext _dbContext;

    public UnitOfWork(BookingManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CommitAsync()
    {
        _ = await _dbContext.SaveChangesAsync();
    }
}
