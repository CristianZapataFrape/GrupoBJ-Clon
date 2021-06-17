using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Modelos_Tabla_Nutrimental2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabla_Nutrimental",
                columns: table => new
                {
                    id_Tabla_Nutrimental = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Carateristica_Valores = table.Column<int>(nullable: false),
                    Nombre_Tabla_Nutrimental = table.Column<string>(maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Nutrimental", x => x.id_Tabla_Nutrimental);
                    table.ForeignKey(
                        name: "FK_Tabla_Nutrimental_Carateristica_Valores_id_Carateristica_Valores",
                        column: x => x.id_Carateristica_Valores,
                        principalTable: "Carateristica_Valores",
                        principalColumn: "id_Carateristica_Valores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulos_Nutrimental",
                columns: table => new
                {
                    id_Articulos_Nutrimental = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Tabla_Nutrimental = table.Column<int>(nullable: false),
                    id_Articulos = table.Column<int>(nullable: false),
                    Caracteristicas = table.Column<string>(nullable: true),
                    Presentacion = table.Column<string>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos_Nutrimental", x => x.id_Articulos_Nutrimental);
                    table.ForeignKey(
                        name: "FK_Articulos_Nutrimental_Articulos_id_Articulos",
                        column: x => x.id_Articulos,
                        principalTable: "Articulos",
                        principalColumn: "id_Articulos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Nutrimental_Tabla_Nutrimental_id_Tabla_Nutrimental",
                        column: x => x.id_Tabla_Nutrimental,
                        principalTable: "Tabla_Nutrimental",
                        principalColumn: "id_Tabla_Nutrimental",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Nutrimental_Campos",
                columns: table => new
                {
                    id_Tabla_Nutrimental_Campos = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Tabla_Nutrimental = table.Column<int>(nullable: false),
                    Nombre_Tabla_Nutrimental_Campos = table.Column<string>(maxLength: 50, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Nutrimental_Campos", x => x.id_Tabla_Nutrimental_Campos);
                    table.ForeignKey(
                        name: "FK_Tabla_Nutrimental_Campos_Tabla_Nutrimental_id_Tabla_Nutrimental",
                        column: x => x.id_Tabla_Nutrimental,
                        principalTable: "Tabla_Nutrimental",
                        principalColumn: "id_Tabla_Nutrimental",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Nutrimental_Valores",
                columns: table => new
                {
                    id_Tabla_Nutrimental_Valores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Tabla_Nutrimental_Campos = table.Column<int>(nullable: false),
                    id_Articulos_Nutrimental = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(maxLength: 150, nullable: false),
                    Unidad = table.Column<string>(maxLength: 150, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Nutrimental_Valores", x => x.id_Tabla_Nutrimental_Valores);
                    table.ForeignKey(
                        name: "FK_Tabla_Nutrimental_Valores_Articulos_Nutrimental_id_Articulos_Nutrimental",
                        column: x => x.id_Articulos_Nutrimental,
                        principalTable: "Articulos_Nutrimental",
                        principalColumn: "id_Articulos_Nutrimental",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tabla_Nutrimental_Valores_Tabla_Nutrimental_Campos_id_Tabla_Nutrimental_Campos",
                        column: x => x.id_Tabla_Nutrimental_Campos,
                        principalTable: "Tabla_Nutrimental_Campos",
                        principalColumn: "id_Tabla_Nutrimental_Campos");
                        //onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Nutrimental_id_Articulos",
                table: "Articulos_Nutrimental",
                column: "id_Articulos");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Nutrimental_id_Tabla_Nutrimental",
                table: "Articulos_Nutrimental",
                column: "id_Tabla_Nutrimental");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Nutrimental_id_Carateristica_Valores",
                table: "Tabla_Nutrimental",
                column: "id_Carateristica_Valores");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Nutrimental_Campos_id_Tabla_Nutrimental",
                table: "Tabla_Nutrimental_Campos",
                column: "id_Tabla_Nutrimental");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Nutrimental_Valores_id_Articulos_Nutrimental",
                table: "Tabla_Nutrimental_Valores",
                column: "id_Articulos_Nutrimental");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Nutrimental_Valores_id_Tabla_Nutrimental_Campos",
                table: "Tabla_Nutrimental_Valores",
                column: "id_Tabla_Nutrimental_Campos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabla_Nutrimental_Valores");

            migrationBuilder.DropTable(
                name: "Articulos_Nutrimental");

            migrationBuilder.DropTable(
                name: "Tabla_Nutrimental_Campos");

            migrationBuilder.DropTable(
                name: "Tabla_Nutrimental");
        }
    }
}
