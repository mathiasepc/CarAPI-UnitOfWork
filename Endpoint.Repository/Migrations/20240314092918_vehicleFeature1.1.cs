using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Endpoint.Repository.Migrations
{
    /// <inheritdoc />
    public partial class vehicleFeature11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Features_FeaturesId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_FeaturesId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FeaturesId",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FeaturesId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FeaturesId",
                table: "Vehicles",
                column: "FeaturesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Features_FeaturesId",
                table: "Vehicles",
                column: "FeaturesId",
                principalTable: "Features",
                principalColumn: "Id");
        }
    }
}
