using Application.DTO;

namespace Application.Interface;
public interface IServiceService
{
    public Task<int> Create( ServiceDTO serviceDto );
    public Task Update( int id, ServiceDTO serviceDTO );
    public Task<ServiceDTO?> GetById( int id );
    public Task<List<ServiceDTO>> GetAll();
}
