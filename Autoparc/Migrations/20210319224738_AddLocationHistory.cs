using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class AddLocationHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "driverLocationsHistory",
                columns: table => new
                {
                    idLocation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_driverLocationsHistory", x => x.idLocation);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "driverLocationsHistory");
        }
    }
}
