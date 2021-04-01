using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fktacheuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_taches_cin",
                table: "taches",
                column: "cin");

            migrationBuilder.AddForeignKey(
                name: "FK_taches_users_cin",
                table: "taches",
                column: "cin",
                principalTable: "users",
                principalColumn: "cin",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taches_users_cin",
                table: "taches");

            migrationBuilder.DropIndex(
                name: "IX_taches_cin",
                table: "taches");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "taches");
        }
    }
}
