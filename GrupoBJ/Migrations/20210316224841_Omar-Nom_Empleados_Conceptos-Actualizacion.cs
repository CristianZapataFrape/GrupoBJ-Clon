using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNom_Empleados_ConceptosActualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Nom_Empleados_Conceptos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Nom_Empleados_Conceptos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUm",
                table: "Nom_Empleados_Conceptos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkConcepto",
                table: "Nom_Empleados_Conceptos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Nom_Empleados_Conceptos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioUm",
                table: "Nom_Empleados_Conceptos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nom_Empleados_Conceptos_fkConcepto",
                table: "Nom_Empleados_Conceptos",
                column: "fkConcepto");

            migrationBuilder.AddForeignKey(
                name: "FK_Nom_Empleados_Conceptos_Nom_Conceptos_fkConcepto",
                table: "Nom_Empleados_Conceptos",
                column: "fkConcepto",
                principalTable: "Nom_Conceptos",
                principalColumn: "idConcepto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nom_Empleados_Conceptos_Nom_Conceptos_fkConcepto",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropIndex(
                name: "IX_Nom_Empleados_Conceptos_fkConcepto",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropColumn(
                name: "fechaUm",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropColumn(
                name: "fkConcepto",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Nom_Empleados_Conceptos");

            migrationBuilder.DropColumn(
                name: "fkUsuarioUm",
                table: "Nom_Empleados_Conceptos");
        }
    }
}
