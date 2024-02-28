using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Endpoint.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ModelsAddedVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Vehicles_VehicleId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_VehicleId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Models");

            migrationBuilder.CreateTable(
                name: "ModelVehicle",
                columns: table => new
                {
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiclesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVehicle", x => new { x.ModelId, x.VehiclesId });
                    table.ForeignKey(
                        name: "FK_ModelVehicle_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModelVehicle_Vehicles_VehiclesId",
                        column: x => x.VehiclesId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelVehicle_VehiclesId",
                table: "ModelVehicle",
                column: "VehiclesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ModelVehicle");

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Models",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_VehicleId",
                table: "Models",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Vehicles_VehicleId",
                table: "Models",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");
        }
    }
}
