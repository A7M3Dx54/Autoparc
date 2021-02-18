using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "vehicules",
                columns: table => new
                {
                    registrationNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    totalDistance = table.Column<long>(type: "bigint", nullable: false),
                    reservoir = table.Column<int>(type: "int", nullable: false),
                    kmPerLittre = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicules", x => x.registrationNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicules");
        }
    }
}
