using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class MonedaEliminarCamposMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Moneda");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Moneda",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Moneda",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
