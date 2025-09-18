using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure( EntityTypeBuilder<Guest> builder )
    {
        builder.ToTable( "Guest" );

        builder.HasKey( g => g.Id );

        builder.Property( g => g.FirstName )
            .HasMaxLength( 50 )
            .IsRequired();

        builder.Property( g => g.LastName )
            .HasMaxLength( 50 )
            .IsRequired();

        builder.Property( g => g.Email )
            .IsRequired();

        builder.HasMany( g => g.Reservations )
            .WithOne( r => r.Guest )
            .HasForeignKey( r => r.GuestId )
            .OnDelete( DeleteBehavior.Cascade );
    }
}
