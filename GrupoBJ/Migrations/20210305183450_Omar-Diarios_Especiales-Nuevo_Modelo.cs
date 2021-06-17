using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarDiarios_EspecialesNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diarios_Especiales",
                columns: table => new
                {
                    idDiariosEpeciales = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    fkTipoDiario = table.Column<int>(nullable: false),
                    fkRubrosNIF = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarios_Especiales", x => x.idDiariosEpeciales);
                    table.ForeignKey(
                        name: "FK_Diarios_Especiales_Rubros_NIF_fkRubrosNIF",
                        column: x => x.fkRubrosNIF,
                        principalTable: "Rubros_NIF",
                        principalColumn: "idRubroNIF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diarios_Especiales_Tipo_Diario_fkTipoDiario",
                        column: x => x.fkTipoDiario,
                        principalTable: "Tipo_Diario",
                        principalColumn: "idTipoDiario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Especiales_fkRubrosNIF",
                table: "Diarios_Especiales",
                column: "fkRubrosNIF");

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Especiales_fkTipoDiario",
                table: "Diarios_Especiales",
                column: "fkTipoDiario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diarios_Especiales");
        }
    }
}
