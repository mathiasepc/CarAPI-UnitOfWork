using Endpoint.Utilities.Models;
using Endpoint.Utilities.Models.LinkTables;
using Microsoft.EntityFrameworkCore;

namespace Endpoint.Repository.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Make> Makes { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Model> Models { get; set; }
    public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Her fortæller jeg, at det er en complex type, som tilhører vehicle.
        modelBuilder.Entity<Vehicle>()
            .ComplexProperty(v => v.Contact);

        modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
        new { vf.VehicleId, vf.FeatureId });

        modelBuilder.Entity<VehicleFeature>()
            .HasOne(v => v.Vehicle)
            .WithMany(s => s.Features)
            .HasForeignKey(sc => sc.VehicleId);


        modelBuilder.Entity<VehicleFeature>()
            .HasOne(sc => sc.Feature)
            .WithMany(s => s.Vehicles)
            .HasForeignKey(sc => sc.FeatureId);

        //// Definerer data for Features
        //modelBuilder.Entity<Feature>().HasData(
        //    new Feature { Id = Guid.NewGuid(), Name = "Feature 1" },
        //    new Feature { Id = Guid.NewGuid(), Name = "Feature 2" },
        //    new Feature { Id = Guid.NewGuid(), Name = "Feature 3" }
        //// Tilføj flere features her
        //);

        //// Definerer data for Makes
        //modelBuilder.Entity<Make>().HasData(
        //    new Make { Id = Guid.NewGuid(), Name = "Make 1" },
        //    new Make { Id = Guid.NewGuid(), Name = "Make 2" },
        //    new Make { Id = Guid.NewGuid(), Name = "Make 3" }
        //// Tilføj flere makes her
        //);

        //// Definerer data for Models
        //modelBuilder.Entity<Model>().HasData(
        //    new Model { Id = Guid.NewGuid(), Name = "Model 1", MakeId = /* ID for Make 1 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 1", MakeId = /* ID for Make 1 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 1", MakeId = /* ID for Make 1 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 2", MakeId = /* ID for Make 2 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 2", MakeId = /* ID for Make 2 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 2", MakeId = /* ID for Make 2 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 3", MakeId = /* ID for Make 3 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 3", MakeId = /* ID for Make 3 */ },
        //    new Model { Id = Guid.NewGuid(), Name = "Model 3", MakeId = /* ID for Make 3 */ }
        //// Tilføj flere models her
        //);

        //// Definerer data for Vehicles
        //modelBuilder.Entity<Vehicle>().HasData(
        //    new Vehicle { Id = Guid.NewGuid(), MakeId = /* ID for Make 1 */, ModelId = /* ID for Model 1 */, Contact_Name = "Contact Name 1", Contact_Email = "contact1@example.com", Contact_Phone = "12345678" },
        //    new Vehicle { Id = Guid.NewGuid(), MakeId = /* ID for Make 2 */, ModelId = /* ID for Model 2 */, Contact_Name = "Contact Name 2", Contact_Email = "contact2@example.com", Contact_Phone = "98765432" },
        //    new Vehicle { Id = Guid.NewGuid(), MakeId = /* ID for Make 3 */, ModelId = /* ID for Model 3 */, Contact_Name = "Contact Name 3", Contact_Email = "contact3@example.com", Contact_Phone = "11234567" }
        //// Tilføj flere køretøjer her
        //);
    }
}
