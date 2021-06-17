using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Modelos_Articulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    idArticulos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Articulo = table.Column<string>(maxLength: 20, nullable: false),
                    Nombre_Articulo = table.Column<string>(maxLength: 150, nullable: false),
                    Costo_Estandar = table.Column<double>(nullable: false),
                    Producto_Venta = table.Column<bool>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.idArticulos);
                });

            migrationBuilder.CreateTable(
                name: "Articulos_Campos",
                columns: table => new
                {
                    idArticulos_Campos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Articulo_Campos = table.Column<string>(maxLength: 150, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos_Campos", x => x.idArticulos_Campos);
                });

            migrationBuilder.CreateTable(
                name: "Articulos_Valores",
                columns: table => new
                {
                    idArticulos_Valores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idArticulos_Campos = table.Column<int>(nullable: false),
                    idArticulos = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(maxLength: 35, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos_Valores", x => x.idArticulos_Valores);
                    table.ForeignKey(
                        name: "FK_Articulos_Valores_Articulos_idArticulos",
                        column: x => x.idArticulos,
                        principalTable: "Articulos",
                        principalColumn: "idArticulos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Valores_Articulos_Campos_idArticulos_Campos",
                        column: x => x.idArticulos_Campos,
                        principalTable: "Articulos_Campos",
                        principalColumn: "idArticulos_Campos",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Valores_idArticulos",
                table: "Articulos_Valores",
                column: "idArticulos");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Valores_idArticulos_Campos",
                table: "Articulos_Valores",
                column: "idArticulos_Campos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos_Valores");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Articulos_Campos");
        }
    }
}
