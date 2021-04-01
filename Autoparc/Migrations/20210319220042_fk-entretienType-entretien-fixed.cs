using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fkentretienTypeentretienfixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_entretienTypes_idType",
                table: "entretiens");

            migrationBuilder.AlterColumn<int>(
                name: "idType",
                table: "entretiens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_entretienTypes_idType",
                table: "entretiens",
                column: "idType",
                principalTable: "entretienTypes",
                principalColumn: "idType",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_entretienTypes_idType",
                table: "entretiens");

            migrationBuilder.AlterColumn<int>(
                name: "idType",
                table: "entretiens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_entretienTypes_idType",
                table: "entretiens",
                column: "idType",
                principalTable: "entretienTypes",
                principalColumn: "idType",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
