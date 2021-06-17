using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarDiarios_EspecialesfkRubrosNIF_Eliminado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diarios_Especiales_Rubros_NIF_fkRubrosNIF",
                table: "Diarios_Especiales");

            migrationBuilder.DropIndex(
                name: "IX_Diarios_Especiales_fkRubrosNIF",
                table: "Diarios_Especiales");

            migrationBuilder.DropColumn(
                name: "fkRubrosNIF",
                table: "Diarios_Especiales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkRubrosNIF",
                table: "Diarios_Especiales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Especiales_fkRubrosNIF",
                table: "Diarios_Especiales",
                column: "fkRubrosNIF");

            migrationBuilder.AddForeignKey(
                name: "FK_Diarios_Especiales_Rubros_NIF_fkRubrosNIF",
                table: "Diarios_Especiales",
                column: "fkRubrosNIF",
                principalTable: "Rubros_NIF",
                principalColumn: "idRubroNIF",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
