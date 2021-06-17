using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Tipo_ArchivoEliminarCamposMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Acceso_Tipo_Archivo");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Acceso_Tipo_Archivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Acceso_Tipo_Archivo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Acceso_Tipo_Archivo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
