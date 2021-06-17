using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AgregarModeloNom_TipoPeriodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_TipoPeriodo",
                columns: table => new
                {
                    idTipoPeriodo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 40, nullable: true),
                    diasPeriodo = table.Column<int>(nullable: false),
                    diaPago = table.Column<int>(nullable: false),
                    fkPeriodoActual = table.Column<int>(nullable: true),
                    ajustarCalendario = table.Column<bool>(nullable: true),
                    periocidad = table.Column<string>(maxLength: 2, nullable: true),
                    septimosDias = table.Column<int>(nullable: false),
                    posicionSeptimos = table.Column<int>(nullable: false),
                    posicionPago = table.Column<int>(nullable: false),
                    ejercicio = table.Column<int>(nullable: false),
                    ajustarMesCalendario = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_TipoPeriodo", x => x.idTipoPeriodo);
                    table.ForeignKey(
                        name: "FK_Nom_TipoPeriodo_Nom_Periodo_fkPeriodoActual",
                        column: x => x.fkPeriodoActual,
                        principalTable: "Nom_Periodo",
                        principalColumn: "idPeriodo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nom_TipoPeriodo_fkPeriodoActual",
                table: "Nom_TipoPeriodo",
                column: "fkPeriodoActual");
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Nom_TipoPeriodo");
        //}
    }
}
