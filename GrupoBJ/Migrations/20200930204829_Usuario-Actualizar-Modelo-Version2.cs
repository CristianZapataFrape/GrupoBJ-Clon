using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class UsuarioActualizarModeloVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contrasena",
                table: "Usuario",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "correoElectronico",
                table: "Usuario",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCaducidad",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imagePath",
                table: "Usuario",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "menuProduccion",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "nuncaCaduca",
                table: "Usuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasena",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "correoElectronico",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "fechaCaducidad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "imagePath",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "menuProduccion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "nuncaCaduca",
                table: "Usuario");
        }
    }
}
