using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantWateringAPI.Migrations
{
    /// <inheritdoc />
    public partial class Plantfieldsrename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsWatered",
                table: "Plants",
                newName: "IsStatusWatering");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Plants",
                newName: "LastWatered");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Plants",
                newName: "PlantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastWatered",
                table: "Plants",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "IsStatusWatering",
                table: "Plants",
                newName: "IsWatered");

            migrationBuilder.RenameColumn(
                name: "PlantId",
                table: "Plants",
                newName: "Id");
        }
    }
}
