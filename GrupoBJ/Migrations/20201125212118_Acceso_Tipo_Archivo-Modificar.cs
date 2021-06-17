using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Tipo_ArchivoModificar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUm",
                table: "Acceso_Tipo_Archivo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioUm",
                table: "Acceso_Tipo_Archivo",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaUm",
                table: "Acceso_Tipo_Archivo");

            migrationBuilder.DropColumn(
                name: "fkUsuarioUm",
                table: "Acceso_Tipo_Archivo");
        }
    }
}
