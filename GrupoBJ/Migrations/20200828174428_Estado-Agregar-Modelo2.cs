using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EstadoAgregarModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    idEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkPais = table.Column<int>(nullable: false),
                    sNombreEstado = table.Column<string>(nullable: false),
                    fkUsuarioCreo = table.Column<int>(nullable: false),
                    dFechaUsuarioCreo = table.Column<DateTime>(nullable: false),
                    fkUsuarioModifico = table.Column<int>(nullable: false),
                    dFechaUsuarioModifico = table.Column<DateTime>(nullable: false),
                    bHabilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.idEstado);
                    table.ForeignKey(
                        name: "FK_Estado_Pais_fkPais",
                        column: x => x.fkPais,
                        principalTable: "Pais",
                        principalColumn: "idPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estado_fkPais",
                table: "Estado",
                column: "fkPais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
