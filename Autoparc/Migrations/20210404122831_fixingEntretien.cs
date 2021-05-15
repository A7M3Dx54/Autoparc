using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fixingEntretien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.AddColumn<string>(
                name: "registrationNumber",
                table: "entretiens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_registrationNumber",
                table: "entretiens",
                column: "registrationNumber");*/

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_users_registrationNumber",
                table: "entretiens",
                column: "registrationNumber",
                principalTable: "vehicules",
                principalColumn: "registrationNumber",
                onDelete: ReferentialAction.Restrict);
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_users_registrationNumber",
                table: "entretiens");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_registrationNumber",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "registrationNumber",
                table: "entretiens");
        }
    }
}
