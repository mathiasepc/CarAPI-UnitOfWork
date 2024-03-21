using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Endpoint.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MakeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Contact_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contact_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contact_Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeatures",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeatures", x => new { x.VehicleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeatures_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05968ad9-bcf4-46b9-a309-f6efe17a9e18"), "Feature 1" },
                    { new Guid("a62f2406-ef12-48ff-ba14-c2ddb04754d8"), "Feature 3" },
                    { new Guid("c5444152-d541-4989-99b2-19ac6ed9125f"), "Feature 2" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a"), "Make 3" },
                    { new Guid("b7f26ac9-5b71-497f-b0a5-5c683e267181"), "Make 1" },
                    { new Guid("b9c77744-3064-4d72-b349-ba12a23fecf7"), "Make 2" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[,]
                {
                    { new Guid("42532caa-0a7f-4556-bcb2-43113ddb7386"), new Guid("b7f26ac9-5b71-497f-b0a5-5c683e267181"), "ModelA-Make1" },
                    { new Guid("5f708c2e-5497-4b8f-a8e2-d393d7ef1540"), new Guid("b9c77744-3064-4d72-b349-ba12a23fecf7"), "ModelA-Make2" },
                    { new Guid("91414760-4cef-4da4-8c91-00e2b18078b2"), new Guid("b9c77744-3064-4d72-b349-ba12a23fecf7"), "ModelC-Make2" },
                    { new Guid("acb956e0-7a1f-48c1-b100-7e9f35d9411b"), new Guid("b7f26ac9-5b71-497f-b0a5-5c683e267181"), "ModelB-Make1" },
                    { new Guid("c06435a9-1913-4a52-a415-01c93753c388"), new Guid("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a"), "ModelB-Make3" },
                    { new Guid("c2dc45ee-9bb0-42e9-b625-aeddc53da952"), new Guid("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a"), "ModelC-Make3" },
                    { new Guid("c956850a-e488-420f-8611-dd30849aaa8e"), new Guid("b9c77744-3064-4d72-b349-ba12a23fecf7"), "ModelB-Make2" },
                    { new Guid("e0799875-c7cd-4c34-b119-9ce3d9f5f742"), new Guid("b7f26ac9-5b71-497f-b0a5-5c683e267181"), "ModelC-Make1" },
                    { new Guid("e5c7929a-956d-4e29-9b86-22f472430933"), new Guid("b4b83d92-d0ac-4bf9-8fae-8fe52284dd9a"), "ModelA-Make3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ModelId",
                table: "Vehicles",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleFeatures");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");
        }
    }
}
