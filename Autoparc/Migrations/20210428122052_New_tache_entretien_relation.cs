using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class New_tache_entretien_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_users_cin",
                table: "entretiens");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_cin",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "entretiens");

            migrationBuilder.AddColumn<bool>(
                name: "isEntretien",
                table: "taches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "idTask",
                table: "entretiens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_idTask",
                table: "entretiens",
                column: "idTask");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_taches_idTask",
                table: "entretiens",
                column: "idTask",
                principalTable: "taches",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_taches_idTask",
                table: "entretiens");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_idTask",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "isEntretien",
                table: "taches");

            migrationBuilder.DropColumn(
                name: "idTask",
                table: "entretiens");

            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "entretiens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_cin",
                table: "entretiens",
                column: "cin");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_users_cin",
                table: "entretiens",
                column: "cin",
                principalTable: "users",
                principalColumn: "cin",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
