using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Modelos_Carateristicas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Valores_Articulos_idArticulos",
                table: "Articulos_Valores");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_Valores_idArticulos",
                table: "Articulos_Valores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "idArticulos",
                table: "Articulos_Valores");

            migrationBuilder.DropColumn(
                name: "idArticulos",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "id_Articulos",
                table: "Articulos_Valores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id_Articulos",
                table: "Articulos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "id_Articulos");

            migrationBuilder.CreateTable(
                name: "Carateristicas",
                columns: table => new
                {
                    id_Cararteristica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Carateristica = table.Column<string>(maxLength: 35, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carateristicas", x => x.id_Cararteristica);
                });

            migrationBuilder.CreateTable(
                name: "Carateristica_Valores",
                columns: table => new
                {
                    id_Carateristica_Valores = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Cararteristica = table.Column<int>(nullable: false),
                    Valor = table.Column<string>(maxLength: 35, nullable: false),
                    Venta = table.Column<bool>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carateristica_Valores", x => x.id_Carateristica_Valores);
                    table.ForeignKey(
                        name: "FK_Carateristica_Valores_Carateristicas_id_Cararteristica",
                        column: x => x.id_Cararteristica,
                        principalTable: "Carateristicas",
                        principalColumn: "id_Cararteristica",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articulos_Carateristicas",
                columns: table => new
                {
                    id_Articulos_Carateristicas = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Carateristica_Valores = table.Column<int>(nullable: false),
                    id_Articulos = table.Column<int>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos_Carateristicas", x => x.id_Articulos_Carateristicas);
                    table.ForeignKey(
                        name: "FK_Articulos_Carateristicas_Articulos_id_Articulos",
                        column: x => x.id_Articulos,
                        principalTable: "Articulos",
                        principalColumn: "id_Articulos",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Carateristicas_Carateristica_Valores_id_Carateristica_Valores",
                        column: x => x.id_Carateristica_Valores,
                        principalTable: "Carateristica_Valores",
                        principalColumn: "id_Carateristica_Valores",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Valores_id_Articulos",
                table: "Articulos_Valores",
                column: "id_Articulos");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Carateristicas_id_Articulos",
                table: "Articulos_Carateristicas",
                column: "id_Articulos");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Carateristicas_id_Carateristica_Valores",
                table: "Articulos_Carateristicas",
                column: "id_Carateristica_Valores");

            migrationBuilder.CreateIndex(
                name: "IX_Carateristica_Valores_id_Cararteristica",
                table: "Carateristica_Valores",
                column: "id_Cararteristica");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Valores_Articulos_id_Articulos",
                table: "Articulos_Valores",
                column: "id_Articulos",
                principalTable: "Articulos",
                principalColumn: "id_Articulos",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Valores_Articulos_id_Articulos",
                table: "Articulos_Valores");

            migrationBuilder.DropTable(
                name: "Articulos_Carateristicas");

            migrationBuilder.DropTable(
                name: "Carateristica_Valores");

            migrationBuilder.DropTable(
                name: "Carateristicas");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_Valores_id_Articulos",
                table: "Articulos_Valores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "id_Articulos",
                table: "Articulos_Valores");

            migrationBuilder.DropColumn(
                name: "id_Articulos",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "idArticulos",
                table: "Articulos_Valores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idArticulos",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articulos",
                table: "Articulos",
                column: "idArticulos");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_Valores_idArticulos",
                table: "Articulos_Valores",
                column: "idArticulos");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Valores_Articulos_idArticulos",
                table: "Articulos_Valores",
                column: "idArticulos",
                principalTable: "Articulos",
                principalColumn: "idArticulos",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
