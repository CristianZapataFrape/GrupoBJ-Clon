using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNom_HistorialQuitar_Campos_Um : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaUm",
                table: "Nom_HistorialSueldos");

            migrationBuilder.DropColumn(
                name: "fkUsuarioUm",
                table: "Nom_HistorialSueldos");

            migrationBuilder.DropColumn(
                name: "fechaUm",
                table: "Nom_HistorialAltaBajaReingreso");

            migrationBuilder.DropColumn(
                name: "fkUsuarioUm",
                table: "Nom_HistorialAltaBajaReingreso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUm",
                table: "Nom_HistorialSueldos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioUm",
                table: "Nom_HistorialSueldos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUm",
                table: "Nom_HistorialAltaBajaReingreso",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioUm",
                table: "Nom_HistorialAltaBajaReingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
