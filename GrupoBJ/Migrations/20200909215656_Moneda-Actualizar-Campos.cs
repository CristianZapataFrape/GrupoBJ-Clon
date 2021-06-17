using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class MonedaActualizarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "dFechaCr",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "dFechaMd",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMd",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "sISO",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "sNombreMoneda",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "sSimbolo",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "sTextoPosterior",
                table: "Moneda");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Moneda",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ISO",
                table: "Moneda",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Moneda",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Simbolo",
                table: "Moneda",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Moneda",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Moneda",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Moneda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "textoPosterior",
                table: "Moneda",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "ISO",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "Simbolo",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "textoPosterior",
                table: "Moneda");

            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Moneda",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaCr",
                table: "Moneda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaMd",
                table: "Moneda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMd",
                table: "Moneda",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sISO",
                table: "Moneda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sNombreMoneda",
                table: "Moneda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sSimbolo",
                table: "Moneda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sTextoPosterior",
                table: "Moneda",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
