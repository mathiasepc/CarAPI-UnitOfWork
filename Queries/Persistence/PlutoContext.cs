using Microsoft.EntityFrameworkCore;
using Queries.Core.Domain;
using Queries.Persistence.EntityConfigurations;

namespace Queries.Persistence;

public class PlutoContext : DbContext
{

    public PlutoContext(DbContextOptions<PlutoContext> option) : base(option)
    {
    }

    public virtual DbSet<Make> Makes { get; set; }
    public virtual DbSet<Feature> Features { get; set; }
    public virtual DbSet<Vehicle> Vehicles { get; set; }
    public virtual DbSet<Model> Models { get; set; }

    /// <summary>
    /// Konfigurere mine modeller med fluent api.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new FeatureConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleFeatureConfiguration());
    }
}

