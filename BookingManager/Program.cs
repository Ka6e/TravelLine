using Domain.Repositories;
using Infrastructure;
using Application.Interface;
using Infrastructure.Repositories;
using Application.Servicies;
using Microsoft.EntityFrameworkCore;

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
        //builder.Services.AddScoped
        builder.Services.AddDbContext<BookingManagerDbContext>( op => op.UseSqlServer( builder.Configuration.GetConnectionString( "DefaultConnection" ) ) );
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
        builder.Services.AddScoped<IPropertySevice, PropertyService>();
        builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();
        builder.Services.AddScoped<ISearchService, SearchService>();
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
