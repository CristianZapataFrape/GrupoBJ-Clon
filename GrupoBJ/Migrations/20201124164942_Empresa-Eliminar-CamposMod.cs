using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EmpresaEliminarCamposMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Empresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Empresa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
