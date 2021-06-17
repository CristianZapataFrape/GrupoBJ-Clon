using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarUsuario_Tabla_ColumnaEliminar_Obligatorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Obligatorio",
                table: "Usuario_Tabla_Columna");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Obligatorio",
                table: "Usuario_Tabla_Columna",
                type: "bit",
                nullable: true);
        }
    }
}
