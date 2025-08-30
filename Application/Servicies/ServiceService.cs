using Application.DTO;
using Application.Extensions;
using Application.Interface;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Servicies;
public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repository;

    public ServiceService(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> Create( ServiceDTO serviceDto )
    {
        Service service = serviceDto.ConvertToEntity();
        _repository.Create( service );

        return service.Id;
    }

    public async Task<List<ServiceDTO>> GetAll()
    {
        List<Service> services = await _repository.GetAll();
        return services.Select( s => s.ConvertToDto() ).ToList(); 
    }

    public async Task<ServiceDTO?> GetById( int id )
    {
        Service service = await _repository.GetById( id );
        if ( service == null )
        {
            throw new KeyNotFoundException( "Service doesn't exist." );
        }

        return service.ConvertToDto();
    }

    public async Task Update( int id, ServiceDTO serviceDTO )
    {
        Service service = await _repository.GetById( id );

        if ( service == null )
        {
            throw new KeyNotFoundException( "Service doesn't exist." );
        }

        service.SetName( serviceDTO.Name );
        service.SetPrice( serviceDTO.Price );
    }
}
