using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class CiudadAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ciudad",
                columns: table => new
                {
                    idCiudad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEstado = table.Column<int>(nullable: false),
                    sNombreCiudad = table.Column<string>(nullable: false),
                    fkUsuarioCreo = table.Column<int>(nullable: false),
                    dFechaUsuarioCreo = table.Column<DateTime>(nullable: false),
                    fkUsuarioModifico = table.Column<int>(nullable: false),
                    dFechaUsuarioModifico = table.Column<DateTime>(nullable: false),
                    bHabilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudad", x => x.idCiudad);
                    table.ForeignKey(
                        name: "FK_Ciudad_Estado_fkEstado",
                        column: x => x.fkEstado,
                        principalTable: "Estado",
                        principalColumn: "idEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudad_fkEstado",
                table: "Ciudad",
                column: "fkEstado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ciudad");
        }
    }
}
