using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarCon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConceptosIETU",
                columns: table => new
                {
                    idConceptoIETU = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    fkTipoIVA = table.Column<int>(nullable: false),
                    fkTipoIETU = table.Column<int>(nullable: false),
                    Tipo = table.Column<string>(maxLength: 6, nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConceptosIETU", x => x.idConceptoIETU);
                    table.ForeignKey(
                        name: "FK_ConceptosIETU_Tipo_ConceptosIETU_IETU_fkTipoIETU",
                        column: x => x.fkTipoIETU,
                        principalTable: "Tipo_ConceptosIETU_IETU",
                        principalColumn: "idTipoConceptoIETU_IETU");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConceptosIETU_Tipo_ConceptosIETU_IVA_fkTipoIVA",
                        column: x => x.fkTipoIVA,
                        principalTable: "Tipo_ConceptosIETU_IVA",
                        principalColumn: "idTipoConceptoIETU_IVA");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConceptosIETU_fkTipoIETU",
                table: "ConceptosIETU",
                column: "fkTipoIETU");

            migrationBuilder.CreateIndex(
                name: "IX_ConceptosIETU_fkTipoIVA",
                table: "ConceptosIETU",
                column: "fkTipoIVA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConceptosIETU");
        }
    }
}
