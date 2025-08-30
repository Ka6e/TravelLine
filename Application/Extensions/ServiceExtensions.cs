using Application.DTO;
using Domain.Entities;

namespace Application.Extensions;
public static class ServiceExtensions
{
    public static Service ConvertToEntity( this ServiceDTO serviceDto )
    {
        return new Service(
            serviceDto.Name,
            serviceDto.Currency,
            serviceDto.Price);
    }

    public static ServiceDTO ConvertToDto(this Service service )
    {
        return new ServiceDTO
        {
            Name = service.Name,
            Currency = service.Currency,
            Price = service.Price,
        };
    }
}
