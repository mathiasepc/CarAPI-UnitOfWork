﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Endpoint.Repository.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Endpoint.Repository.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240228130739_AddVehicle")]
    partial class AddVehicle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Endpoint.Utilities.Models.Featured", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Endpoint.Utilities.Models.Make", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("Endpoint.Utilities.Models.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MakeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("VehicleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MakeId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("Endpoint.Utilities.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsRegistered")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uniqueidentifier");

                    b.ComplexProperty<Dictionary<string, object>>("Contact", "Endpoint.Utilities.Models.Vehicle.Contact#Contact", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasMaxLength(255)
                                .HasColumnType("nvarchar(255)");
                        });

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("FeaturedVehicle", b =>
                {
                    b.Property<Guid>("FeaturesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VehiclesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FeaturesId", "VehiclesId");

                    b.HasIndex("VehiclesId");

                    b.ToTable("FeaturedVehicle");
                });

            modelBuilder.Entity("Endpoint.Utilities.Models.Model", b =>
                {
                    b.HasOne("Endpoint.Utilities.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Endpoint.Utilities.Models.Vehicle", null)
                        .WithMany("Model")
                        .HasForeignKey("VehicleId");

                    b.Navigation("Make");
                });

            modelBuilder.Entity("FeaturedVehicle", b =>
                {
                    b.HasOne("Endpoint.Utilities.Models.Featured", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Endpoint.Utilities.Models.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Endpoint.Utilities.Models.Make", b =>
                {
                    b.Navigation("Models");
                });

            modelBuilder.Entity("Endpoint.Utilities.Models.Vehicle", b =>
                {
                    b.Navigation("Model");
                });
#pragma warning restore 612, 618
        }
    }
}
