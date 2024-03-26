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

        // Her fortæller jeg, at det er en complex type, som tilhører vehicle.
        modelBuilder.Entity<Vehicle>()
            .ComplexProperty(v => v.Contact);

        //// Definerer data for Features
        //modelBuilder.Entity<Feature>().HasData(
        //    new Feature { Id = Guid.Parse("05968ad9-bcf4-46b9-a309-f6efe17a9e18"), Name = "Feature 1" },
        //    new Feature { Id = Guid.Parse("c5444152-d541-4989-99b2-19ac6ed9125f"), Name = "Feature 2" },
        //    new Feature { Id = Guid.Parse("a62f2406-ef12-48ff-ba14-c2ddb04754d8"), Name = "Feature 3" }
        //// Tilføj flere features her
        //);

        //// Definerer data for Makes
        //modelBuilder.Entity<Make>().HasData(
        //    new Make { Id = Guid.Parse("b7f26ac9-5b71-497f-b0a5-5c683e267181"), Name = "Make 1" },
        //    new Make { Id = Guid.Parse("b9c77744-3064-4d72-b349-ba12a23fecf7"), Name = "Make 2" },
        //    new Make { Id = Guid.Parse("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a"), Name = "Make 3" }
        //// Tilføj flere makes her
        //);

        //// Definerer data for Models
        //modelBuilder.Entity<Model>().HasData(
        //    new Model { Id = Guid.Parse("42532caa-0a7f-4556-bcb2-43113ddb7386"), Name = "ModelA-Make1", MakeId = Guid.Parse("b7f26ac9-5b71-497f-b0a5-5c683e267181") },
        //    new Model { Id = Guid.Parse("acb956e0-7a1f-48c1-b100-7e9f35d9411b"), Name = "ModelB-Make1", MakeId = Guid.Parse("b7f26ac9-5b71-497f-b0a5-5c683e267181") },
        //    new Model { Id = Guid.Parse("e0799875-c7cd-4c34-b119-9ce3d9f5f742"), Name = "ModelC-Make1", MakeId = Guid.Parse("b7f26ac9-5b71-497f-b0a5-5c683e267181") },
        //    new Model { Id = Guid.Parse("5f708c2e-5497-4b8f-a8e2-d393d7ef1540"), Name = "ModelA-Make2", MakeId = Guid.Parse("b9c77744-3064-4d72-b349-ba12a23fecf7") },
        //    new Model { Id = Guid.Parse("c956850a-e488-420f-8611-dd30849aaa8e"), Name = "ModelB-Make2", MakeId = Guid.Parse("b9c77744-3064-4d72-b349-ba12a23fecf7") },
        //    new Model { Id = Guid.Parse("91414760-4cef-4da4-8c91-00e2b18078b2"), Name = "ModelC-Make2", MakeId = Guid.Parse("b9c77744-3064-4d72-b349-ba12a23fecf7") },
        //    new Model { Id = Guid.Parse("e5c7929a-956d-4e29-9b86-22f472430933"), Name = "ModelA-Make3", MakeId = Guid.Parse("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a") },
        //    new Model { Id = Guid.Parse("c06435a9-1913-4a52-a415-01c93753c388"), Name = "ModelB-Make3", MakeId = Guid.Parse("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a") },
        //    new Model { Id = Guid.Parse("c2dc45ee-9bb0-42e9-b625-aeddc53da952"), Name = "ModelC-Make3", MakeId = Guid.Parse("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a") }
        //// Tilføj flere models her
        //);


        // Man kan ikke mappe complex type. Kan derfor heller ikke oprette M-M. Derfor udkommenteret
        //---------------------------------------------------------------------------------------------------------
        //// Definerer data for Vehicles
        //modelBuilder.Entity<Vehicle>().HasData(
        //    new Vehicle { Id = Guid.Parse("b225a9fe-df56-41e5-9183-18d5f43bd947"), ModelId = Guid.Parse("42532caa-0a7f-4556-bcb2-43113ddb7386"), Contact = new Contact() },
        //    new Vehicle { Id = Guid.Parse("a61d1da6-a98b-4d21-9baa-3ad798c19e1f"), ModelId = Guid.Parse("5f708c2e-5497-4b8f-a8e2-d393d7ef1540"), Contact = new Contact() },
        //    new Vehicle { Id = Guid.Parse("6bdb9ebb-1595-4605-b379-78c5bda7da2f"), ModelId = Guid.Parse("e5c7929a-956d-4e29-9b86-22f472430933"), Contact = new Contact() }
        //// Tilføj flere køretøjer her
        //);

        //// Tilføj data til link-tabellen VehicleFeature
        //modelBuilder.Entity<VehicleFeature>().HasData(
        //    new VehicleFeature
        //    {
        //        VehicleId = Guid.Parse("b225a9fe-df56-41e5-9183-18d5f43bd947"), 
        //        FeatureId = Guid.Parse("05968ad9-bcf4-46b9-a309-f6efe17a9e18"), 
        //    },
        //    new VehicleFeature
        //    {
        //        VehicleId = Guid.Parse("a61d1da6-a98b-4d21-9baa-3ad798c19e1f"), 
        //        FeatureId = Guid.Parse("c5444152-d541-4989-99b2-19ac6ed9125f"), 
        //    },
        //    new VehicleFeature
        //    {
        //        VehicleId = Guid.Parse("6bdb9ebb-1595-4605-b379-78c5bda7da2f"), 
        //        FeatureId = Guid.Parse("a62f2406-ef12-48ff-ba14-c2ddb04754d8"), 
        //    }
        //    // Tilføj flere seed-data efter behov
        //);
    }
}
