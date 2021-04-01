using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fkuserlocatioHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "driverLocationsHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_driverLocationsHistory_cin",
                table: "driverLocationsHistory",
                column: "cin");

            migrationBuilder.AddForeignKey(
                name: "FK_driverLocationsHistory_users_cin",
                table: "driverLocationsHistory",
                column: "cin",
                principalTable: "users",
                principalColumn: "cin",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_driverLocationsHistory_users_cin",
                table: "driverLocationsHistory");

            migrationBuilder.DropIndex(
                name: "IX_driverLocationsHistory_cin",
                table: "driverLocationsHistory");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "driverLocationsHistory");
        }
    }
}
