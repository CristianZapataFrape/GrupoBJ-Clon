using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_OpcionEliminarCamposMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Acceso_Opcion");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Acceso_Opcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Acceso_Opcion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Acceso_Opcion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
