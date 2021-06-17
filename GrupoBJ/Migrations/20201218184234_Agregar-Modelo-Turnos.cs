using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AgregarModeloTurnos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    idTurno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroTurno = table.Column<int>(nullable: false),
                    nombre = table.Column<string>(maxLength: 40, nullable: true),
                    horas = table.Column<float>(nullable: false),
                    tipoJornadas = table.Column<string>(maxLength: 2, nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.idTurno);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.CreateTable(
                name: "Turno",
                columns: table => new
                {
                    idTurno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(type: "bit", nullable: true),
                    fechaCr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaUm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fkUsuarioCr = table.Column<int>(type: "int", nullable: false),
                    fkUsuarioUm = table.Column<int>(type: "int", nullable: false),
                    horas = table.Column<float>(type: "real", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    numeroTurno = table.Column<int>(type: "int", nullable: false),
                    tipoJornadas = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turno", x => x.idTurno);
                });
        }
    }
}
