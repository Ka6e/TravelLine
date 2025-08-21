using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure( EntityTypeBuilder<Reservation> builder )
    {
        builder.ToTable( "Reservation" );

        builder.HasKey( res => res.Id );

        builder.HasOne( res => res.Property )
            .WithMany( p => p.Reservations )
            .OnDelete( DeleteBehavior.Restrict );

        builder.HasOne( res => res.RoomType )
            .WithMany( r => r.Reservations )
            .OnDelete( DeleteBehavior.Restrict );

        builder.Property( r => r.ArrivalDate )
            .IsRequired();

        builder.Property( res => res.DepartureDate )
            .IsRequired();

        builder.Property( res => res.ArrivalTime )
            .IsRequired();

        builder.Property( res => res.DepartureTime )
            .IsRequired();

        builder.Property( res => res.GuestName )
            .IsRequired();

        builder.Property( res => res.GuestPhoneNumber )
            .IsRequired();

        builder.Property( res => res.Total )
            .HasPrecision( 18, 2 )
            .IsRequired();

        builder.Property( res => res.Currency )
            .HasConversion<string>()
            .IsRequired();

        builder.Property( res => res.IsCanceled )
            .IsRequired();
    }
}
