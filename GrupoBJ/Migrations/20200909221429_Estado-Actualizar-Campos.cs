using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EstadoActualizarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioCreo",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "dFechaUsuarioModifico",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCreo",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fkUsuarioModifico",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "sNombreEstado",
                table: "Estado");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Estado",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Estado",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Estado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Estado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Estado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Estado",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Estado");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Estado");

            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Estado",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioCreo",
                table: "Estado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dFechaUsuarioModifico",
                table: "Estado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCreo",
                table: "Estado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioModifico",
                table: "Estado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sNombreEstado",
                table: "Estado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
