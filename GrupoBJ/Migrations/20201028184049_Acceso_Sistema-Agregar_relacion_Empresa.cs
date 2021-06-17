using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_SistemaAgregar_relacion_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkEmpresa",
                table: "Acceso_Sistema",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Sistema_fkEmpresa",
                table: "Acceso_Sistema",
                column: "fkEmpresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Sistema_Empresa_fkEmpresa",
                table: "Acceso_Sistema",
                column: "fkEmpresa",
                principalTable: "Empresa",
                principalColumn: "idEmpresa",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Sistema_Empresa_fkEmpresa",
                table: "Acceso_Sistema");

            migrationBuilder.DropIndex(
                name: "IX_Acceso_Sistema_fkEmpresa",
                table: "Acceso_Sistema");

            migrationBuilder.DropColumn(
                name: "fkEmpresa",
                table: "Acceso_Sistema");
        }
    }
}
