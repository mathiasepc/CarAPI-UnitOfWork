using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queries.Core.Domain;

namespace Queries.Persistence.EntityConfigurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(v => v.Id).IsRequired();
        builder.Property(v => v.ModelId).IsRequired();

        builder.OwnsOne(v => v.Contact, contact =>
        {
            contact.Property(c => c.Name).IsRequired();
            contact.Property(c => c.Email).IsRequired();
        });

        builder.HasMany(v => v.VehicleFeatures)
            .WithOne(vf => vf.Vehicle)
            .HasForeignKey(vf => vf.VehicleId);

    }
}