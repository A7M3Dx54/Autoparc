using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fixingStuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "registrationNumber",
                table: "taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_taches_registrationNumber",
                table: "taches",
                column: "registrationNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_taches_users_registrationNumber",
                table: "taches",
                column: "registrationNumber",
                principalTable: "vehicules",
                principalColumn: "registrationNumber",
                onDelete: ReferentialAction.Restrict);
        }
    

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_taches_users_registrationNumber",
                table: "taches");

            migrationBuilder.DropIndex(
                name: "IX_taches_registrationNumber",
                table: "taches");

            migrationBuilder.DropColumn(
                name: "registrationNumber",
                table: "taches");
        }
    }
}
