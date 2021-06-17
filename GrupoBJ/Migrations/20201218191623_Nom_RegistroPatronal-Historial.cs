using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Nom_RegistroPatronalHistorial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Nom_RegistroPatronal",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Nom_RegistroPatronal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUm",
                table: "Nom_RegistroPatronal",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Nom_RegistroPatronal",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioUm",
                table: "Nom_RegistroPatronal",
                nullable: false,
                defaultValue: 0);
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropColumn(
        //        name: "Habilitado",
        //        table: "Nom_RegistroPatronal");

        //    migrationBuilder.DropColumn(
        //        name: "fechaCr",
        //        table: "Nom_RegistroPatronal");

        //    migrationBuilder.DropColumn(
        //        name: "fechaUm",
        //        table: "Nom_RegistroPatronal");

        //    migrationBuilder.DropColumn(
        //        name: "fkUsuarioCr",
        //        table: "Nom_RegistroPatronal");

        //    migrationBuilder.DropColumn(
        //        name: "fkUsuarioUm",
        //        table: "Nom_RegistroPatronal");
        //}
    }
}
