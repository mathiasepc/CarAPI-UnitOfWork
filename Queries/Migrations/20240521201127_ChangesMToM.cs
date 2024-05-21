using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Queries.Migrations
{
    /// <inheritdoc />
    public partial class ChangesMToM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Vehicles_VehicleId",
                table: "Features");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Features_FeatureId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_FeatureId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Features_VehicleId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "Contact_Email",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Contact_Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Contact_Phone",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Features");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Contact_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "VehicleFeatures");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Email",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Contact_Phone",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "Features",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FeatureId",
                table: "Vehicles",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_VehicleId",
                table: "Features",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Vehicles_VehicleId",
                table: "Features",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Features_FeatureId",
                table: "Vehicles",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }
    }
}
