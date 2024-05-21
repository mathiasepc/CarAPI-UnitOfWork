using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Queries.Migrations
{
    /// <inheritdoc />
    public partial class FluentAPI13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures");

            migrationBuilder.RenameTable(
                name: "VehicleFeatures",
                newName: "VehicleFeature");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleFeatures_FeatureId",
                table: "VehicleFeature",
                newName: "IX_VehicleFeature_FeatureId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleFeature",
                table: "VehicleFeature",
                columns: new[] { "VehicleId", "FeatureId" });

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeature_Features_FeatureId",
                table: "VehicleFeature",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeature_Vehicles_VehicleId",
                table: "VehicleFeature",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeature_Features_FeatureId",
                table: "VehicleFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleFeature_Vehicles_VehicleId",
                table: "VehicleFeature");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleFeature",
                table: "VehicleFeature");

            migrationBuilder.DropColumn(
                name: "Contact_Email",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Contact_Name",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Contact_Phone",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "VehicleFeature",
                newName: "VehicleFeatures");

            migrationBuilder.RenameIndex(
                name: "IX_VehicleFeature_FeatureId",
                table: "VehicleFeatures",
                newName: "IX_VehicleFeatures_FeatureId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleFeatures",
                table: "VehicleFeatures",
                columns: new[] { "VehicleId", "FeatureId" });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Features_FeatureId",
                table: "VehicleFeatures",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleFeatures_Vehicles_VehicleId",
                table: "VehicleFeatures",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
