using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure( EntityTypeBuilder<RoomType> builder )
    {
        builder.ToTable( "RoomType" );

        builder.HasKey( r => r.Id );

        builder.HasOne( r => r.Property )
            .WithMany( p => p.RoomTypes );

        builder.Property( r => r.Name )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( r => r.DailyPrice )
            .HasPrecision( 18, 2 )
            .IsRequired();

        builder.Property( r => r.Currency)
            .HasConversion<string>()
            .IsRequired();

        builder.Property( r => r.MinPersonCount )
            .IsRequired();

        builder.Property( r => r.MaxPersonCount )
            .IsRequired();

        builder.HasMany( r => r.RoomServices )
            .WithOne( rs => rs.RoomType)
            .HasForeignKey( rs => rs.RoomTypeId);

        builder.HasMany( r => r.RoomAmenities )
            .WithOne( a => a.RoomType )
            .HasForeignKey( a => a.RoomTypeId );

        builder.HasMany( r => r.Reservations )
            .WithOne( res => res.RoomType )
            .HasForeignKey( res => res.RoomTypeId )
            .OnDelete( DeleteBehavior.Restrict );
    }
}
