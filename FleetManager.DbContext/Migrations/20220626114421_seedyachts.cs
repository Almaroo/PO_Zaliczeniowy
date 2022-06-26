using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManager.YachtsContext.Migrations
{
    public partial class seedyachts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                "Yachts",
                new[] { "YachtId", "Name", "YearBuilt", "Make" },
                new object[,]
                {
                    { 1, "Antibes", 2008, "Oceanis" },
                    { 2, "Big Blue", 2005, "Sun Odyssey" },
                    { 3, "Alegro", 2018, "Dufour" },
                    { 4, "Bella", 2022, "Bavaria" },
                }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "Yachts",
                "YachtId",
                1
                );
            migrationBuilder.DeleteData(
                "Yachts",
                "YachtId",
                2
                );
            migrationBuilder.DeleteData(
                "Yachts",
                "YachtId",
                3
                );
            migrationBuilder.DeleteData(
                "Yachts",
                "YachtId",
                4
                );
            migrationBuilder.DeleteData(
                "Yachts",
                "YachtId",
                5
                );
        }
    }
}
