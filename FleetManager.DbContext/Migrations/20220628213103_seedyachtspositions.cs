using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FleetManager.YachtsContext.Migrations
{
    public partial class seedyachtspositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                1,
                "Latitude",
                37.913251
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                1,
                "Longitude",
                23.703336
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                2,
                "Latitude",
                44.050251
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                2,
                "Longitude",
                15.300985
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                3,
                "Latitude",
                43.514732
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                3,
                "Longitude",
                16.247167
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                4,
                "Latitude",
                42.659013
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                4,
                "Longitude",
                18.083186
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                1,
                "Latitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                1,
                "Longitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                2,
                "Latitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                2,
                "Longitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                3,
                "Latitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                3,
                "Longitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                4,
                "Latitude",
                0
                );

            migrationBuilder.UpdateData(
                "Yachts",
                "YachtId",
                4,
                "Longitude",
                0
                );
        }
    }
}
