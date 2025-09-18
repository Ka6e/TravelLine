using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class RoomServiceConfiguration : IEntityTypeConfiguration<RoomService>
{
    public void Configure( EntityTypeBuilder<RoomService> builder )
    {
        builder.ToTable( "RoomService" );

        builder.HasKey( rs => new { rs.RoomTypeId, rs.ServiceId } );

        builder.HasOne( rs => rs.RoomType )
            .WithMany( rt => rt.RoomServices );

        builder.HasOne( rs => rs.Service )
            .WithMany( s => s.RoomServices );
    }
}
