using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNom_ConceptosNuevo_Modelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_Conceptos",
                columns: table => new
                {
                    idConcepto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numeroConcepto = table.Column<int>(nullable: true),
                    tipoConcepto = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 40, nullable: true),
                    Especie = table.Column<bool>(nullable: true),
                    automaticoGlobal = table.Column<bool>(nullable: true),
                    automaticoLiquidacion = table.Column<bool>(nullable: true),
                    Imprimir = table.Column<bool>(nullable: true),
                    Articulo86 = table.Column<bool>(nullable: true),
                    leyendaImporte1 = table.Column<string>(maxLength: 40, nullable: true),
                    leyendaImporte2 = table.Column<string>(maxLength: 40, nullable: true),
                    leyendaImporte3 = table.Column<string>(maxLength: 40, nullable: true),
                    leyendaImporte4 = table.Column<string>(maxLength: 40, nullable: true),
                    cuentaContable = table.Column<string>(maxLength: 30, nullable: true),
                    contraCuentaContable = table.Column<string>(maxLength: 30, nullable: true),
                    tipoMovimientoContable = table.Column<string>(nullable: true),
                    contabilizacionCuenta = table.Column<string>(nullable: true),
                    contabilizacionContraCuenta = table.Column<string>(nullable: true),
                    leyendaValor = table.Column<string>(maxLength: 40, nullable: true),
                    formulaImporteTotal = table.Column<string>(nullable: true),
                    formulaImporte1 = table.Column<string>(nullable: true),
                    formulaImporte2 = table.Column<string>(nullable: true),
                    formulaImporte3 = table.Column<string>(nullable: true),
                    formulaImporte4 = table.Column<string>(nullable: true),
                    formulaValor = table.Column<string>(nullable: true),
                    claveAgrupadoraSAT = table.Column<string>(maxLength: 2, nullable: true),
                    cuentaGravado = table.Column<string>(maxLength: 30, nullable: true),
                    cuentaExcentoDeduc = table.Column<string>(maxLength: 30, nullable: true),
                    cuentaExcentoNoDeduc = table.Column<string>(maxLength: 30, nullable: true),
                    metodoPago = table.Column<string>(maxLength: 2, nullable: true),
                    tipoClaveSAT = table.Column<string>(maxLength: 2, nullable: true),
                    tipoHoras = table.Column<string>(maxLength: 12, nullable: true),
                    Habilitado = table.Column<bool>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioUm = table.Column<int>(nullable: false),
                    fechaUm = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_Conceptos", x => x.idConcepto);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nom_Conceptos");
        }
    }
}
