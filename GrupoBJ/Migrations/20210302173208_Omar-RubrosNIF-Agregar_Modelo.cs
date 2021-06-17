using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarRubrosNIFAgregar_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rubros_NIF",
                columns: table => new
                {
                    idRubroNIF = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    fkNIFTipo = table.Column<int>(nullable: false),
                    fkNIFNivel = table.Column<int>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros_NIF", x => x.idRubroNIF);
                    table.ForeignKey(
                        name: "FK_Rubros_NIF_NIF_Nivel_fkNIFNivel",
                        column: x => x.fkNIFNivel,
                        principalTable: "NIF_Nivel",
                        principalColumn: "idNIFNivel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rubros_NIF_NIF_Tipo_fkNIFTipo",
                        column: x => x.fkNIFTipo,
                        principalTable: "NIF_Tipo",
                        principalColumn: "idNIFTipo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rubros_NIF_fkNIFNivel",
                table: "Rubros_NIF",
                column: "fkNIFNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Rubros_NIF_fkNIFTipo",
                table: "Rubros_NIF",
                column: "fkNIFTipo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rubros_NIF");
        }
    }
}
