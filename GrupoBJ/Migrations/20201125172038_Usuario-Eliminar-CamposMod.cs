using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class UsuarioEliminarCamposMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Usuario_Empresa_Sucursal_Sis_Per");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Usuario_Empresa_Sucursal_Sis_Per");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Usuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
