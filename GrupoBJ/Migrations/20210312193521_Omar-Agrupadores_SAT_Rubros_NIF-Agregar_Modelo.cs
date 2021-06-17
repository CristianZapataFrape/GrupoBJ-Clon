using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarAgrupadores_SAT_Rubros_NIFAgregar_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agrupadores_SAT_Rubros_NIF",
                columns: table => new
                {
                    idAgrupadoresSATRubrosNIF = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkAgrupadoresSAT = table.Column<int>(nullable: false),
                    fkRubrosNIF = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agrupadores_SAT_Rubros_NIF", x => x.idAgrupadoresSATRubrosNIF);
                    table.ForeignKey(
                        name: "FK_Agrupadores_SAT_Rubros_NIF_Agrupadores_SAT_fkAgrupadoresSAT",
                        column: x => x.fkAgrupadoresSAT,
                        principalTable: "Agrupadores_SAT",
                        principalColumn: "idAgrupadorSAT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agrupadores_SAT_Rubros_NIF_Rubros_NIF_fkRubrosNIF",
                        column: x => x.fkRubrosNIF,
                        principalTable: "Rubros_NIF",
                        principalColumn: "idRubroNIF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agrupadores_SAT_Rubros_NIF_fkAgrupadoresSAT",
                table: "Agrupadores_SAT_Rubros_NIF",
                column: "fkAgrupadoresSAT");

            migrationBuilder.CreateIndex(
                name: "IX_Agrupadores_SAT_Rubros_NIF_fkRubrosNIF",
                table: "Agrupadores_SAT_Rubros_NIF",
                column: "fkRubrosNIF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agrupadores_SAT_Rubros_NIF");
        }
    }
}
