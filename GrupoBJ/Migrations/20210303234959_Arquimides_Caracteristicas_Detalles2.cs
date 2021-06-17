using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Caracteristicas_Detalles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carateristica_Valores_Usuario_fkUsuarioUm",
                table: "Carateristica_Valores");

            migrationBuilder.DropIndex(
                name: "IX_Carateristica_Valores_fkUsuarioUm",
                table: "Carateristica_Valores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Carateristica_Valores_fkUsuarioUm",
                table: "Carateristica_Valores",
                column: "fkUsuarioUm");

            migrationBuilder.AddForeignKey(
                name: "FK_Carateristica_Valores_Usuario_fkUsuarioUm",
                table: "Carateristica_Valores",
                column: "fkUsuarioUm",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
