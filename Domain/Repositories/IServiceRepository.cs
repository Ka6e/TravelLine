using Domain.Entities;

namespace Domain.Repositories;
public interface IServiceRepository
{
    public void Create( Service servcie );
    public Task<Service> GetById( int id );
    public Task<List<Service>> GetAll();
    public void Activate ( Service servcie );
    public void Disactivate( Service service );

}
