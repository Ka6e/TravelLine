using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure( EntityTypeBuilder<Amenity> builder )
    {
        builder.ToTable( "Amenity" );

        builder.HasKey( a => a.Id );

        builder.Property( a => a.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
