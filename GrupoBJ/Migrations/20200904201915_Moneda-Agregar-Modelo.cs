using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class MonedaAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moneda",
                columns: table => new
                {
                    idMoneda = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sNombreMoneda = table.Column<string>(nullable: false),
                    sSimbolo = table.Column<string>(nullable: false),
                    sTextoPosterior = table.Column<string>(nullable: false),
                    sISO = table.Column<string>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    dFechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMd = table.Column<int>(nullable: false),
                    dFechaMd = table.Column<DateTime>(nullable: false),
                    bHabilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneda", x => x.idMoneda);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moneda");
        }
    }
}
