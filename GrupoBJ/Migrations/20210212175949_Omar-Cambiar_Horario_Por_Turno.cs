using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarCambiar_Horario_Por_Turno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Turnos_fkTurno",
                table: "Empleado");

            migrationBuilder.DropColumn(
                name: "fkHorario",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "fkTurno",
                table: "Empleado",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Turnos_fkTurno",
                table: "Empleado",
                column: "fkTurno",
                principalTable: "Turnos",
                principalColumn: "idTurno",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Turnos_fkTurno",
                table: "Empleado");

            migrationBuilder.AlterColumn<int>(
                name: "fkTurno",
                table: "Empleado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "fkHorario",
                table: "Empleado",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Turnos_fkTurno",
                table: "Empleado",
                column: "fkTurno",
                principalTable: "Turnos",
                principalColumn: "idTurno",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
