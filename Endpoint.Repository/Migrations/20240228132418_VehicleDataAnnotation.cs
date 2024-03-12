using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Endpoint.Repository.Migrations
{
    /// <inheritdoc />
    public partial class VehicleDataAnnotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedVehicle_Vehicle_VehiclesId",
                table: "FeaturedVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Vehicle_VehicleId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedVehicle_Vehicles_VehiclesId",
                table: "FeaturedVehicle",
                column: "VehiclesId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Vehicles_VehicleId",
                table: "Models",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeaturedVehicle_Vehicles_VehiclesId",
                table: "FeaturedVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Vehicles_VehicleId",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeaturedVehicle_Vehicle_VehiclesId",
                table: "FeaturedVehicle",
                column: "VehiclesId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Vehicle_VehicleId",
                table: "Models",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id");
        }
    }
}
