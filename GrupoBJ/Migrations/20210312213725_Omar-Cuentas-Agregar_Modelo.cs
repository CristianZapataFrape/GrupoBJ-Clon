using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarCuentasAgregar_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    idCuenta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Clasificacion = table.Column<int>(nullable: false),
                    Naturaleza = table.Column<int>(nullable: false),
                    ctaMayor = table.Column<int>(nullable: false),
                    Subcuenta = table.Column<int>(nullable: false),
                    fkAgrupadoresSAT = table.Column<int>(nullable: false),
                    fkTipoCuenta = table.Column<int>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.idCuenta);
                    table.ForeignKey(
                        name: "FK_Cuentas_Agrupadores_SAT_fkAgrupadoresSAT",
                        column: x => x.fkAgrupadoresSAT,
                        principalTable: "Agrupadores_SAT",
                        principalColumn: "idAgrupadorSAT",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cuentas_Tipo_Cuenta_fkTipoCuenta",
                        column: x => x.fkTipoCuenta,
                        principalTable: "Tipo_Cuenta",
                        principalColumn: "idTipoCuenta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_fkAgrupadoresSAT",
                table: "Cuentas",
                column: "fkAgrupadoresSAT");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_fkTipoCuenta",
                table: "Cuentas",
                column: "fkTipoCuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuentas");
        }
    }
}
