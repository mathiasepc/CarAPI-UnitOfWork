using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queries.Core.Domain.LinkTables;

namespace Queries.Persistence.EntityConfigurations;

public class VehicleFeatureConfiguration : IEntityTypeConfiguration<VehicleFeature>
{
    public void Configure(EntityTypeBuilder<VehicleFeature> builder)
    {
        builder.HasKey(vf => new { vf.VehicleId, vf.FeatureId });

        builder.HasOne(vf => vf.Vehicle)
            .WithMany(v => v.Features)
            .HasForeignKey(vf => vf.VehicleId);

        builder.HasOne(vf => vf.Feature)
            .WithMany(f => f.Vehicle)
            .HasForeignKey(vf => vf.FeatureId);
    }
}
