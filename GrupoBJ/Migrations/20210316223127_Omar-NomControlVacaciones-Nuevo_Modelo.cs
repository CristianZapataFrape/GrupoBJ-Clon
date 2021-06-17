using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNomControlVacacionesNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_ControlVacaciones",
                columns: table => new
                {
                    idControlVacaciones = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEmpleado = table.Column<int>(nullable: false),
                    Ejercicio = table.Column<int>(nullable: true),
                    diasVacaciones = table.Column<int>(nullable: true),
                    diasPrimaVacacional = table.Column<double>(nullable: true),
                    fechaInicio = table.Column<DateTime>(nullable: true),
                    fechaFin = table.Column<DateTime>(nullable: true),
                    diasDescanso = table.Column<int>(nullable: true),
                    fechaPago = table.Column<DateTime>(nullable: true),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_ControlVacaciones", x => x.idControlVacaciones);
                    table.ForeignKey(
                        name: "FK_Nom_ControlVacaciones_Empleado_fkEmpleado",
                        column: x => x.fkEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nom_ControlVacaciones_fkEmpleado",
                table: "Nom_ControlVacaciones",
                column: "fkEmpleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nom_ControlVacaciones");
        }
    }
}
