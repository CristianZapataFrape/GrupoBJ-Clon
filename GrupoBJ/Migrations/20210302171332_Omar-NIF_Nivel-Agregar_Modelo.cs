﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNIF_NivelAgregar_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NIF_Nivel",
                columns: table => new
                {
                    idNIFNivel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NIF_Nivel", x => x.idNIFNivel);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NIF_Nivel");
        }
    }
}
