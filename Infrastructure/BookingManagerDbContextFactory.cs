using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure;
public class BookingManagerDbContextFactory : IDesignTimeDbContextFactory<BookingManagerDbContext>
{
    public BookingManagerDbContext CreateDbContext( string[] args )
    {
        var optionsBuilder = new DbContextOptionsBuilder<BookingManagerDbContext>();
        optionsBuilder.UseSqlServer( "Server=127.0.0.1,1433;Database=Booking;User Id=sa;Password=Secret1_;TrustServerCertificate=True;" );

        return new BookingManagerDbContext( optionsBuilder.Options );
    }
}