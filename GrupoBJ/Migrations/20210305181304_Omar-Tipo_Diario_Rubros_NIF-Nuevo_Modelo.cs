using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarTipo_Diario_Rubros_NIFNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo_Diario_Rubros_NIF",
                columns: table => new
                {
                    idTipoDiarioRubrosNIF = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkRubrosNIF = table.Column<int>(nullable: false),
                    fkTipoDiario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Diario_Rubros_NIF", x => x.idTipoDiarioRubrosNIF);
                    table.ForeignKey(
                        name: "FK_Tipo_Diario_Rubros_NIF_Rubros_NIF_fkRubrosNIF",
                        column: x => x.fkRubrosNIF,
                        principalTable: "Rubros_NIF",
                        principalColumn: "idRubroNIF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tipo_Diario_Rubros_NIF_Tipo_Diario_fkTipoDiario",
                        column: x => x.fkTipoDiario,
                        principalTable: "Tipo_Diario",
                        principalColumn: "idTipoDiario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Diario_Rubros_NIF_fkRubrosNIF",
                table: "Tipo_Diario_Rubros_NIF",
                column: "fkRubrosNIF");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Diario_Rubros_NIF_fkTipoDiario",
                table: "Tipo_Diario_Rubros_NIF",
                column: "fkTipoDiario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tipo_Diario_Rubros_NIF");
        }
    }
}
