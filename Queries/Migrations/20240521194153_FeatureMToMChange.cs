using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Queries.Migrations
{
    /// <inheritdoc />
    public partial class FeatureMToMChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Features_FeatureId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Features");

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FeatureId",
                table: "Vehicles",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Features_FeatureId",
                table: "Vehicles",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Features_FeatureId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_FeatureId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Vehicles");

            migrationBuilder.AddColumn<Guid>(
                name: "FeatureId",
                table: "Features",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureId",
                table: "Features",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Features_FeatureId",
                table: "Features",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }
    }
}
