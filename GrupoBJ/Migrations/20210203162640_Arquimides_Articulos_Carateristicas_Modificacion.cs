using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Articulos_Carateristicas_Modificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "id_Cararteristica",
                table: "Articulos_Carateristicas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Carateristicas_id_Cararteristica",
                table: "Articulos_Carateristicas",
                column: "id_Cararteristica");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Carateristicas_Carateristicas_id_Cararteristica",
                table: "Articulos_Carateristicas",
                column: "id_Cararteristica",
                principalTable: "Carateristicas",
                principalColumn: "id_Cararteristica");
               // onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Carateristicas_Carateristicas_id_Cararteristica",
                table: "Articulos_Carateristicas");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_Carateristicas_id_Cararteristica",
                table: "Articulos_Carateristicas");

            migrationBuilder.DropColumn(
                name: "id_Cararteristica",
                table: "Articulos_Carateristicas");
        }
    }
}
