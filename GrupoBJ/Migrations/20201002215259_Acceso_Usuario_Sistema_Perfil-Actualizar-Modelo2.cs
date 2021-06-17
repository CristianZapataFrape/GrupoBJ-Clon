using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Usuario_Sistema_PerfilActualizarModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Acceso_Usuario_Sistema_Perfil");
        }
    }
}
