using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class CiudadActualizarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioCreo",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioModifico",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCreo",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "fkUsuarioModifico",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "sNombreCiudad",
                table: "Ciudad");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Ciudad",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Ciudad",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Ciudad",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Ciudad",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Ciudad",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Ciudad",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Ciudad");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Ciudad");

            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Ciudad",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioCreo",
                table: "Ciudad",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioModifico",
                table: "Ciudad",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCreo",
                table: "Ciudad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioModifico",
                table: "Ciudad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sNombreCiudad",
                table: "Ciudad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
