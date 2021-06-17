using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Relacion_Articulo_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Articulos_fkUsuarioUm",
                table: "Articulos",
                column: "fkUsuarioUm");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Usuario_fkUsuarioUm",
                table: "Articulos",
                column: "fkUsuarioUm",
                principalTable: "Usuario",
                principalColumn: "idUsuario");
               // onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Usuario_fkUsuarioUm",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_fkUsuarioUm",
                table: "Articulos");
        }
    }
}
