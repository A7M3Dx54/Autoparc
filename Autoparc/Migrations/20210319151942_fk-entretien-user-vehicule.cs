using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fkentretienuservehicule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "entretiens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registrationNumber",
                table: "entretiens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_cin",
                table: "entretiens",
                column: "cin");

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_registrationNumber",
                table: "entretiens",
                column: "registrationNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_users_cin",
                table: "entretiens",
                column: "cin",
                principalTable: "users",
                principalColumn: "cin",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_vehicules_registrationNumber",
                table: "entretiens",
                column: "registrationNumber",
                principalTable: "vehicules",
                principalColumn: "registrationNumber",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_users_cin",
                table: "entretiens");

            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_vehicules_registrationNumber",
                table: "entretiens");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_cin",
                table: "entretiens");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_registrationNumber",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "registrationNumber",
                table: "entretiens");
        }
    }
}
