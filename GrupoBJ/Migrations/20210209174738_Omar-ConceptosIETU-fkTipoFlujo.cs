using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarConceptosIETUfkTipoFlujo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkTipoFlujo",
                table: "ConceptosIETU",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ConceptosIETU_fkTipoFlujo",
                table: "ConceptosIETU",
                column: "fkTipoFlujo");

            migrationBuilder.AddForeignKey(
                name: "FK_ConceptosIETU_Tipo_ConceptosIETU_fkTipoFlujo",
                table: "ConceptosIETU",
                column: "fkTipoFlujo",
                principalTable: "Tipo_ConceptosIETU",
                principalColumn: "idTipoConceptoIETU",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConceptosIETU_Tipo_ConceptosIETU_fkTipoFlujo",
                table: "ConceptosIETU");

            migrationBuilder.DropIndex(
                name: "IX_ConceptosIETU_fkTipoFlujo",
                table: "ConceptosIETU");

            migrationBuilder.DropColumn(
                name: "fkTipoFlujo",
                table: "ConceptosIETU");
        }
    }
}
