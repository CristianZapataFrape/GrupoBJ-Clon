using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarDiarios_Especiales_Rubros_NIFNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diarios_Especiales_Rubros_NIF",
                columns: table => new
                {
                    idDiariosEspecialesRubrosNIF = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkRubrosNIF = table.Column<int>(nullable: false),
                    fkDiariosEspeciales = table.Column<int>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diarios_Especiales_Rubros_NIF", x => x.idDiariosEspecialesRubrosNIF);
                    table.ForeignKey(
                        name: "FK_Diarios_Especiales_Rubros_NIF_Diarios_Especiales_fkDiariosEspeciales",
                        column: x => x.fkDiariosEspeciales,
                        principalTable: "Diarios_Especiales",
                        principalColumn: "idDiariosEspeciales",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diarios_Especiales_Rubros_NIF_Rubros_NIF_fkRubrosNIF",
                        column: x => x.fkRubrosNIF,
                        principalTable: "Rubros_NIF",
                        principalColumn: "idRubroNIF",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Especiales_Rubros_NIF_fkDiariosEspeciales",
                table: "Diarios_Especiales_Rubros_NIF",
                column: "fkDiariosEspeciales");

            migrationBuilder.CreateIndex(
                name: "IX_Diarios_Especiales_Rubros_NIF_fkRubrosNIF",
                table: "Diarios_Especiales_Rubros_NIF",
                column: "fkRubrosNIF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diarios_Especiales_Rubros_NIF");
        }
    }
}
