using Domain.Entities;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public class BookingManagerDbContext : DbContext
{
    public BookingManagerDbContext( DbContextOptions<BookingManagerDbContext> options )
        : base( options )
    {
    }

    public DbSet<Property> Properties { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }

    public DbSet<Reservation> Reservations { get; set; }
    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new PropertyConfiguration() );
        modelBuilder.ApplyConfiguration( new RoomTypeConfiguration() );
        modelBuilder.ApplyConfiguration( new ReservationConfiuguration() );
    }
}
