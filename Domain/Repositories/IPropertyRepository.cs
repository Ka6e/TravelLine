using Domain.Entities;

namespace Domain.Repositories;
public interface IPropertyRepository
{
    public void Create( Property property );
    public Task<List<Property>> GetAll();
    public Task<Property?> GetById( int id );
    public void Delete( Property property );
}
