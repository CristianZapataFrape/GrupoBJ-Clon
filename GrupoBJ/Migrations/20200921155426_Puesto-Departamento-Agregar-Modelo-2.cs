using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class PuestoDepartamentoAgregarModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    idDepartamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    fkEmpresa = table.Column<int>(nullable: false),
                    fkUsuarioCreo = table.Column<int>(nullable: false),
                    dFechaUsuarioCreo = table.Column<DateTime>(nullable: false),
                    fkUsuarioModifico = table.Column<int>(nullable: false),
                    dFechaUsuarioModifico = table.Column<DateTime>(nullable: false),
                    bHabilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.idDepartamento);
                    table.ForeignKey(
                        name: "FK_Departamento_Empresa_fkEmpresa",
                        column: x => x.fkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    idPuesto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    fkDepartamento = table.Column<int>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMod = table.Column<int>(nullable: false),
                    fechaMod = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.idPuesto);
                    table.ForeignKey(
                        name: "FK_Puesto_Departamento_fkDepartamento",
                        column: x => x.fkDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "idDepartamento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_fkEmpresa",
                table: "Departamento",
                column: "fkEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_fkDepartamento",
                table: "Puesto",
                column: "fkDepartamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
