using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Usuario_Empresa_SucursalActualizarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Usuario_Empresa_Sucursal",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Usuario_Empresa_Sucursal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Usuario_Empresa_Sucursal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Usuario_Empresa_Sucursal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Usuario_Empresa_Sucursal",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Usuario_Empresa_Sucursal");
        }
    }
}
