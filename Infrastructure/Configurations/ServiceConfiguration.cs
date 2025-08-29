using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;
public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure( EntityTypeBuilder<Service> builder )
    {
        builder.ToTable( "Service" );

        builder.HasKey( s => s.Id );

        builder.Property( s => s.Name )
            .HasMaxLength( 100 )
            .IsRequired();

        builder.Property( s => s.Price )
            .HasPrecision( 18, 2 )
            .IsRequired();

        builder.Property( s => s.Currency)
            .HasConversion<string>()
            .IsRequired();

        builder.Property( s => s.IsActive )
            .IsRequired();
    }
}
