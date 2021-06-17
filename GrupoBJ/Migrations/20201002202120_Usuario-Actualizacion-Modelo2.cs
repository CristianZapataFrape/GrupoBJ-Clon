using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class UsuarioActualizacionModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empleado_fkEmpleado",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_fkEmpleado",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "fkEmpleado",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Usuario",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "fkEmpleado",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_fkEmpleado",
                table: "Usuario",
                column: "fkEmpleado");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empleado_fkEmpleado",
                table: "Usuario",
                column: "fkEmpleado",
                principalTable: "Empleado",
                principalColumn: "idEmpleado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
