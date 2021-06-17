using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarUsuario_Tabla_Columna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario_Tabla_Columna",
                columns: table => new
                {
                    idUsuarioTablaColumna = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkUsuario = table.Column<int>(nullable: false),
                    Tabla = table.Column<string>(maxLength: 100, nullable: false),
                    Columna = table.Column<string>(maxLength: 100, nullable: false),
                    Ancho = table.Column<int>(nullable: true),
                    Obligatorio = table.Column<bool>(nullable: true),
                    Visibilidad = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Tabla_Columna", x => x.idUsuarioTablaColumna);
                    table.ForeignKey(
                        name: "FK_Usuario_Tabla_Columna_Usuario_fkUsuario",
                        column: x => x.fkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Tabla_Columna_fkUsuario",
                table: "Usuario_Tabla_Columna",
                column: "fkUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario_Tabla_Columna");
        }
    }
}
