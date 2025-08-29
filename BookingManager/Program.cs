using Application.Interface;
using Application.Servicies;
using Infrastructure.Extension;

namespace BookingManager;

public class Program
{
    public static void Main( string[] args )
    {
        var builder = WebApplication.CreateBuilder( args );

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddInfrastructure( builder.Configuration );
        builder.Services.AddScoped<IPropertySevice, PropertyService>();
        builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
        builder.Services.AddScoped<ISearchService, SearchService>();
        builder.Services.AddScoped<IReservartionService, ReservationService>();
        builder.Services.AddScoped<IAmenityService, AmenityService>();
        builder.Services.AddScoped<IServiceService, ServiceService>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if ( app.Environment.IsDevelopment() )
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
