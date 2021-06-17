using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class SucursalAgregarModelo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    idSucursal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkEmpresa = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    codigoPostal = table.Column<string>(maxLength: 5, nullable: false),
                    Calle = table.Column<string>(maxLength: 150, nullable: false),
                    Colonia = table.Column<string>(maxLength: 100, nullable: false),
                    numeroInterior = table.Column<string>(maxLength: 8, nullable: true),
                    numeroExterior = table.Column<string>(maxLength: 8, nullable: false),
                    Cardinalidad = table.Column<string>(maxLength: 10, nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Celular = table.Column<string>(maxLength: 10, nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: false),
                    fkCiudad = table.Column<int>(nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMod = table.Column<int>(nullable: false),
                    fechaMod = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.idSucursal);
                    table.ForeignKey(
                        name: "FK_Sucursal_Empresa_fkEmpresa",
                        column: x => x.fkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_fkEmpresa",
                table: "Sucursal",
                column: "fkEmpresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sucursal");
        }
    }
}
