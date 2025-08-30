using Domain.Entities;

namespace Domain.Repositories;
public interface IServiceRepository
{
    public void Create( Service servcie );
    public Task<Service> GetById( int id );
    public Task<List<Service>> GetByIds( List<int> ids );
    public Task<List<Service>> GetAll();
}
