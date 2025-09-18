using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure( EntityTypeBuilder<Property> builder )
    {
        builder.ToTable( "Property" );

        builder.HasKey( p => p.Id );

        builder.Property( p => p.Name )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( p => p.Country )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( p => p.City )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( p => p.Address )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( p => p.Latitude )
            .IsRequired();

        builder.Property( p => p.Longitude )
            .IsRequired();

        builder.HasMany( p => p.RoomTypes )
            .WithOne( r => r.Property )
            .HasForeignKey( r => r.PropertyId );

        builder.HasMany( p => p.Reservations )
            .WithOne( res => res.Property )
            .HasForeignKey( res => res.PropertyId );
    }
}
