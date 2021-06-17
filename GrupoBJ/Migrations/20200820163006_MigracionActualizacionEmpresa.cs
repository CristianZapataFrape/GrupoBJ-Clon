using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class MigracionActualizacionEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Empresa",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUsuarioCreo",
                table: "Empresa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUsuarioModifico",
                table: "Empresa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCreo",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioModifico",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fechaUsuarioCreo",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fechaUsuarioModifico",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCreo",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioModifico",
                table: "Empresa");
        }
    }
}
