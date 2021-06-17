using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarDiarios_EspecialesAdecuar_Nombre_Campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diarios_Especiales",
                table: "Diarios_Especiales");

            migrationBuilder.DropColumn(
                name: "idDiariosEpeciales",
                table: "Diarios_Especiales");

            migrationBuilder.AddColumn<int>(
                name: "idDiariosEspeciales",
                table: "Diarios_Especiales",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diarios_Especiales",
                table: "Diarios_Especiales",
                column: "idDiariosEspeciales");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Diarios_Especiales",
                table: "Diarios_Especiales");

            migrationBuilder.DropColumn(
                name: "idDiariosEspeciales",
                table: "Diarios_Especiales");

            migrationBuilder.AddColumn<int>(
                name: "idDiariosEpeciales",
                table: "Diarios_Especiales",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diarios_Especiales",
                table: "Diarios_Especiales",
                column: "idDiariosEpeciales");
        }
    }
}
