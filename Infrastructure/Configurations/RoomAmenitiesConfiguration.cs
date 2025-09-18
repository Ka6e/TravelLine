using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class RoomAmenitiesConfiguration : IEntityTypeConfiguration<RoomAmenities>
{
    public void Configure( EntityTypeBuilder<RoomAmenities> builder )
    {
        builder.ToTable( "RoomAmenity" );

        builder.HasKey( ra => new { ra.RoomTypeId, ra.AmenityId } );

        builder.HasOne( ra => ra.RoomType )
            .WithMany( ra => ra.RoomAmenities );

        builder.HasOne( ra => ra.Amenity )
            .WithMany( a => a.RoomAmenities );
    }
}
