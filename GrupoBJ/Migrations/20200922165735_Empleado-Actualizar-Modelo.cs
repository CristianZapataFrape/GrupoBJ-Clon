using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EmpleadoActualizarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkSucursal",
                table: "Empleado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_fkSucursal",
                table: "Empleado",
                column: "fkSucursal");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Sucursal_fkSucursal",
                table: "Empleado",
                column: "fkSucursal",
                principalTable: "Sucursal",
                principalColumn: "idSucursal");
                //onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Sucursal_fkSucursal",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_fkSucursal",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "fkSucursal",
                table: "Empleado");
        }
    }
}
