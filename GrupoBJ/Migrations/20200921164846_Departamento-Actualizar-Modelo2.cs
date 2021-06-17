using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class DepartamentoActualizarModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioCreo",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioModifico",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCreo",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fkUsuarioModifico",
                table: "Departamento");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Departamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Departamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Departamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Departamento",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Departamento");

            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Departamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioCreo",
                table: "Departamento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioModifico",
                table: "Departamento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCreo",
                table: "Departamento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioModifico",
                table: "Departamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
