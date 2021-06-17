using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarModeloTipo_ConceptosIETU_IVA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo_ConceptosIETU_IVA",
                columns: table => new
                {
                    idTipoConceptoIETU_IVA = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    fkTipoConceptoIETU = table.Column<int>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_ConceptosIETU_IVA", x => x.idTipoConceptoIETU_IVA);
                    table.ForeignKey(
                        name: "FK_Tipo_ConceptosIETU_IVA_Tipo_ConceptosIETU_fkTipoConceptoIETU",
                        column: x => x.fkTipoConceptoIETU,
                        principalTable: "Tipo_ConceptosIETU",
                        principalColumn: "idTipoConceptoIETU",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_ConceptosIETU_IVA_fkTipoConceptoIETU",
                table: "Tipo_ConceptosIETU_IVA",
                column: "fkTipoConceptoIETU");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tipo_ConceptosIETU_IVA");
        }
    }
}
