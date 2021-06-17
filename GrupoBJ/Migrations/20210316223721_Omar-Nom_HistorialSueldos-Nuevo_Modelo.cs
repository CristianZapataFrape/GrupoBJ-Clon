using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNom_HistorialSueldosNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_HistorialSueldos",
                columns: table => new
                {
                    idHistorialSueldo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEmpleado = table.Column<int>(nullable: false),
                    tipoSueldo = table.Column<string>(nullable: true),
                    sueldo = table.Column<double>(nullable: true),
                    fkPeriodo = table.Column<int>(nullable: false),
                    fkTipoPeriodo = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_HistorialSueldos", x => x.idHistorialSueldo);
                    table.ForeignKey(
                        name: "FK_Nom_HistorialSueldos_Empleado_fkEmpleado",
                        column: x => x.fkEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nom_HistorialSueldos_Nom_Periodo_fkPeriodo",
                        column: x => x.fkPeriodo,
                        principalTable: "Nom_Periodo",
                        principalColumn: "idPeriodo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nom_HistorialSueldos_Nom_TipoPeriodo_fkTipoPeriodo",
                        column: x => x.fkTipoPeriodo,
                        principalTable: "Nom_TipoPeriodo",
                        principalColumn: "idTipoPeriodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nom_HistorialSueldos_fkEmpleado",
                table: "Nom_HistorialSueldos",
                column: "fkEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Nom_HistorialSueldos_fkPeriodo",
                table: "Nom_HistorialSueldos",
                column: "fkPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_Nom_HistorialSueldos_fkTipoPeriodo",
                table: "Nom_HistorialSueldos",
                column: "fkTipoPeriodo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nom_HistorialSueldos");
        }
    }
}
