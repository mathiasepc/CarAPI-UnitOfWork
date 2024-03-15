using Endpoint.Utilities.Models;
using Endpoint.Utilities.Models.LinkTables;
using Microsoft.EntityFrameworkCore;


namespace Endpoint.Repository.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Make>  Makes { get; set; }
    public DbSet<Features> Features { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Model> Models { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
        new { vf.VehicleId, vf.FeatureId });

        // Her fortæller jeg, at det er en complex type, som tilhører vehicle.
        modelBuilder.Entity<Vehicle>()
            .ComplexProperty(v => v.Contact);
    }
}
