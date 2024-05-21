using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Queries.Core.Domain;
using Queries.Core.Domain.LinkTables;

namespace Queries.Persistence.EntityConfigurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.Property(f => f.Id).IsRequired();

        builder.HasMany(f => f.VehicleFeatures)
            .WithOne(vf => vf.Feature)
            .HasForeignKey(vf => vf.FeatureId);
    }
}