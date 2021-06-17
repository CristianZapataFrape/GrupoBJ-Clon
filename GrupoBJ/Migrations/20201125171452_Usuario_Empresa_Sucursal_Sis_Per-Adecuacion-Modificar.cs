using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Usuario_Empresa_Sucursal_Sis_PerAdecuacionModificar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUm",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioUm",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaUm",
                table: "Usuario_Empresa_Sucursal_Sis_Per");

            migrationBuilder.DropColumn(
                name: "fkUsuarioUm",
                table: "Usuario_Empresa_Sucursal_Sis_Per");
        }
    }
}
