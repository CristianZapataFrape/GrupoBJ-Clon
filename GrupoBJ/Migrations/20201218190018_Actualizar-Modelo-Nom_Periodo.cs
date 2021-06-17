using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class ActualizarModeloNom_Periodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkTipoPeriodo",
                table: "Nom_Periodo",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nom_Periodo_fkTipoPeriodo",
                table: "Nom_Periodo",
                column: "fkTipoPeriodo");

            migrationBuilder.AddForeignKey(
                name: "FK_Nom_Periodo_Nom_TipoPeriodo_fkTipoPeriodo",
                table: "Nom_Periodo",
                column: "fkTipoPeriodo",
                principalTable: "Nom_TipoPeriodo",
                principalColumn: "idTipoPeriodo",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nom_Periodo_Nom_TipoPeriodo_fkTipoPeriodo",
                table: "Nom_Periodo");

            migrationBuilder.DropIndex(
                name: "IX_Nom_Periodo_fkTipoPeriodo",
                table: "Nom_Periodo");

            migrationBuilder.DropColumn(
                name: "fkTipoPeriodo",
                table: "Nom_Periodo");
        }
    }
}
