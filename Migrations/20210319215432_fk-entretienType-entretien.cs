using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fkentretienTypeentretien : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idType",
                table: "entretiens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_idType",
                table: "entretiens",
                column: "idType");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_entretienTypes_idType",
                table: "entretiens",
                column: "idType",
                principalTable: "entretienTypes",
                principalColumn: "idType",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_entretienTypes_idType",
                table: "entretiens");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_idType",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "idType",
                table: "entretiens");
        }
    }
}
