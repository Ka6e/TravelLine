namespace Infrastructure;

public interface IUnitOfWork
{
    public Task CommitAsync();
}
