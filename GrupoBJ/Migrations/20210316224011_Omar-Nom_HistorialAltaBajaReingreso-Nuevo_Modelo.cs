using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNom_HistorialAltaBajaReingresoNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_HistorialAltaBajaReingreso",
                columns: table => new
                {
                    idAltaBajaReingreso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEmpleado = table.Column<int>(nullable: false),
                    Clave = table.Column<string>(nullable: true),
                    fkPeriodo = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_HistorialAltaBajaReingreso", x => x.idAltaBajaReingreso);
                    table.ForeignKey(
                        name: "FK_Nom_HistorialAltaBajaReingreso_Empleado_fkEmpleado",
                        column: x => x.fkEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nom_HistorialAltaBajaReingreso_Nom_Periodo_fkPeriodo",
                        column: x => x.fkPeriodo,
                        principalTable: "Nom_Periodo",
                        principalColumn: "idPeriodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nom_HistorialAltaBajaReingreso_fkEmpleado",
                table: "Nom_HistorialAltaBajaReingreso",
                column: "fkEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Nom_HistorialAltaBajaReingreso_fkPeriodo",
                table: "Nom_HistorialAltaBajaReingreso",
                column: "fkPeriodo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nom_HistorialAltaBajaReingreso");
        }
    }
}
