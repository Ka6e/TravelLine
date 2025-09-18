using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Migrations;
public class BookingManagerDbContextFactory : IDesignTimeDbContextFactory<BookingManagerDbContext>
{
    public BookingManagerDbContext CreateDbContext( string[] args )
    {
        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath( Directory.GetCurrentDirectory() );
        builder.AddJsonFile( "appsettings.json" );
        IConfigurationRoot config = builder.Build();

        var optionsBuilder = new DbContextOptionsBuilder<BookingManagerDbContext>();
        optionsBuilder.UseSqlServer( config.GetConnectionString( "DefaultConnection" ),
            b => b.MigrationsAssembly( "Infrastructure.Migrations" ) );

        return new BookingManagerDbContext( optionsBuilder.Options );
    }
}