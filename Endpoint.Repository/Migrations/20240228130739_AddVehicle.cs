using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Endpoint.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact_Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contact_Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contact_Phone = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturedVehicle",
                columns: table => new
                {
                    FeaturesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturedVehicle", x => new { x.FeaturesId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_FeaturedVehicle_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturedVehicle_Vehicle_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_VehicleId",
                table: "Models",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_FeaturedVehicle_VehiclesId",
                table: "FeaturedVehicle",
                column: "VehiclesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Vehicle_VehicleId",
                table: "Models",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Vehicle_VehicleId",
                table: "Models");

            migrationBuilder.DropTable(
                name: "FeaturedVehicle");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Models_VehicleId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Models");
        }
    }
}
