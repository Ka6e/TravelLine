using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extension;
public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration )
    {
        string? connectionString = configuration.GetConnectionString( "DefaultConnection" );
        if ( String.IsNullOrWhiteSpace( connectionString ) )
        {
            throw new ArgumentNullException( "Connection string must not be null or empty" );
        }

        services.AddDbContext<BookingManagerDbContext>( op => op.UseSqlServer(connectionString:  connectionString) );
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        
        return services;
    }
}
