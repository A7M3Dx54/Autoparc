using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoparc.Migrations
{
    public partial class fixVehiculeID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_vehicules_registrationNumber",
                table: "entretiens");

            migrationBuilder.DropForeignKey(
                name: "FK_taches_users_cin",
                table: "taches");

            migrationBuilder.DropForeignKey(
                name: "FK_taches_vehicules_registrationNumber",
                table: "taches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicules",
                table: "vehicules");

            migrationBuilder.DropIndex(
                name: "IX_taches_cin",
                table: "taches");

            migrationBuilder.DropIndex(
                name: "IX_taches_registrationNumber",
                table: "taches");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_registrationNumber",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "cin",
                table: "taches");

            migrationBuilder.DropColumn(
                name: "registrationNumber",
                table: "taches");

            migrationBuilder.DropColumn(
                name: "registrationNumber",
                table: "entretiens");

            migrationBuilder.AlterColumn<string>(
                name: "registrationNumber",
                table: "vehicules",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "idVehicule",
                table: "vehicules",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "idVehicule",
                table: "taches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idVehicule",
                table: "entretiens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicules",
                table: "vehicules",
                column: "idVehicule");

            migrationBuilder.CreateIndex(
                name: "IX_taches_idVehicule",
                table: "taches",
                column: "idVehicule");

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_idVehicule",
                table: "entretiens",
                column: "idVehicule");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_vehicules_idVehicule",
                table: "entretiens",
                column: "idVehicule",
                principalTable: "vehicules",
                principalColumn: "idVehicule",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_taches_vehicules_idVehicule",
                table: "taches",
                column: "idVehicule",
                principalTable: "vehicules",
                principalColumn: "idVehicule",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entretiens_vehicules_idVehicule",
                table: "entretiens");

            migrationBuilder.DropForeignKey(
                name: "FK_taches_vehicules_idVehicule",
                table: "taches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vehicules",
                table: "vehicules");

            migrationBuilder.DropIndex(
                name: "IX_taches_idVehicule",
                table: "taches");

            migrationBuilder.DropIndex(
                name: "IX_entretiens_idVehicule",
                table: "entretiens");

            migrationBuilder.DropColumn(
                name: "idVehicule",
                table: "vehicules");

            migrationBuilder.DropColumn(
                name: "idVehicule",
                table: "taches");

            migrationBuilder.DropColumn(
                name: "idVehicule",
                table: "entretiens");

            migrationBuilder.AlterColumn<string>(
                name: "registrationNumber",
                table: "vehicules",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cin",
                table: "taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registrationNumber",
                table: "taches",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "registrationNumber",
                table: "entretiens",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_vehicules",
                table: "vehicules",
                column: "registrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_taches_cin",
                table: "taches",
                column: "cin");

            migrationBuilder.CreateIndex(
                name: "IX_taches_registrationNumber",
                table: "taches",
                column: "registrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_entretiens_registrationNumber",
                table: "entretiens",
                column: "registrationNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_entretiens_vehicules_registrationNumber",
                table: "entretiens",
                column: "registrationNumber",
                principalTable: "vehicules",
                principalColumn: "registrationNumber",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_taches_users_cin",
                table: "taches",
                column: "cin",
                principalTable: "users",
                principalColumn: "cin",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_taches_vehicules_registrationNumber",
                table: "taches",
                column: "registrationNumber",
                principalTable: "vehicules",
                principalColumn: "registrationNumber",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
