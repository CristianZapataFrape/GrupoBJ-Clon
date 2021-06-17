using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class PaisActualizarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioCreo",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioModifico",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCreo",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "fkUsuarioModifico",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "sNombrePais",
                table: "Pais");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Pais",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Pais",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Pais",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Pais",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Pais",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Pais",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Pais");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Pais");

            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Pais",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioCreo",
                table: "Pais",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioModifico",
                table: "Pais",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCreo",
                table: "Pais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioModifico",
                table: "Pais",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sNombrePais",
                table: "Pais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
