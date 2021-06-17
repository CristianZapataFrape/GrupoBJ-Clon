using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Modelos_Codgio_Barra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Codigo_Barra",
                columns: table => new
                {
                    id_Codigo_Barra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Codigo_Barra = table.Column<string>(maxLength: 50, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codigo_Barra", x => x.id_Codigo_Barra);
                });

            migrationBuilder.CreateTable(
                name: "Codido_Barra_Valores",
                columns: table => new
                {
                    id_Codido_Barra_Valores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Codigo_Barra = table.Column<int>(nullable: false),
                    id_Articulos = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Codido_Barra_Valores", x => x.id_Codido_Barra_Valores);
                    table.ForeignKey(
                        name: "FK_Codido_Barra_Valores_Articulos_id_Articulos",
                        column: x => x.id_Articulos,
                        principalTable: "Articulos",
                        principalColumn: "id_Articulos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Codido_Barra_Valores_Codigo_Barra_id_Codigo_Barra",
                        column: x => x.id_Codigo_Barra,
                        principalTable: "Codigo_Barra",
                        principalColumn: "id_Codigo_Barra",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Codido_Barra_Valores_id_Articulos",
                table: "Codido_Barra_Valores",
                column: "id_Articulos");

            migrationBuilder.CreateIndex(
                name: "IX_Codido_Barra_Valores_id_Codigo_Barra",
                table: "Codido_Barra_Valores",
                column: "id_Codigo_Barra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Codido_Barra_Valores");

            migrationBuilder.DropTable(
                name: "Codigo_Barra");
        }
    }
}
