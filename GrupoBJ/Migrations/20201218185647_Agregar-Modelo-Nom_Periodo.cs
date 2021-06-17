using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AgregarModeloNom_Periodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_Periodo",
                columns: table => new
                {
                    idPeriodo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroPeriodo = table.Column<int>(nullable: false),
                    ejercicio = table.Column<int>(nullable: false),
                    mes = table.Column<int>(nullable: false),
                    diasPago = table.Column<float>(nullable: false),
                    septimos = table.Column<float>(nullable: false),
                    calculado = table.Column<bool>(nullable: true),
                    afectado = table.Column<bool>(nullable: true),
                    fechaInicio = table.Column<DateTime>(nullable: false),
                    fechaFin = table.Column<DateTime>(nullable: false),
                    inicioEjercicio = table.Column<bool>(nullable: true),
                    inicioMes = table.Column<bool>(nullable: true),
                    finMes = table.Column<bool>(nullable: true),
                    finEjercicio = table.Column<bool>(nullable: true),
                    inicioBimestreImss = table.Column<bool>(nullable: true),
                    finBimestreImss = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_Periodo", x => x.idPeriodo);
                });
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Nom_Periodo");
        //}
    }
}
