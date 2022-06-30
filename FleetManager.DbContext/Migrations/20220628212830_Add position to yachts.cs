using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManager.YachtsContext.Migrations
{
    public partial class Addpositiontoyachts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Yachts",
                type: "decimal(8,6)",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Yachts",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Yachts");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Yachts");
        }
    }
}
