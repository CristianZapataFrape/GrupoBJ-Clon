using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNom_Empleados_ConceptosNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_Empleados_Conceptos",
                columns: table => new
                {
                    idEmpleadosConceptos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEmpleado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_Empleados_Conceptos", x => x.idEmpleadosConceptos);
                    table.ForeignKey(
                        name: "FK_Nom_Empleados_Conceptos_Empleado_fkEmpleado",
                        column: x => x.fkEmpleado,
                        principalTable: "Empleado",
                        principalColumn: "idEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nom_Empleados_Conceptos_fkEmpleado",
                table: "Nom_Empleados_Conceptos",
                column: "fkEmpleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nom_Empleados_Conceptos");
        }
    }
}
