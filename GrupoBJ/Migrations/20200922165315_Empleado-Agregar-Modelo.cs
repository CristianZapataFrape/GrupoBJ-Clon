using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EmpleadoAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    idEmpleado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    apPaterno = table.Column<string>(maxLength: 50, nullable: false),
                    apMaterno = table.Column<string>(maxLength: 50, nullable: false),
                    CURP = table.Column<string>(maxLength: 18, nullable: false),
                    IMSS = table.Column<string>(maxLength: 11, nullable: false),
                    fkEstadoCivil = table.Column<int>(nullable: false),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    Fotografia = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 10, nullable: false),
                    Celular = table.Column<string>(maxLength: 10, nullable: false),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    correoElectronico = table.Column<string>(maxLength: 150, nullable: true),
                    cuentaBancaria = table.Column<string>(maxLength: 20, nullable: false),
                    fkBanco = table.Column<int>(nullable: false),
                    clabeInterbancaria = table.Column<string>(maxLength: 18, nullable: false),
                    Calle = table.Column<string>(maxLength: 150, nullable: false),
                    Colonia = table.Column<string>(maxLength: 100, nullable: false),
                    numeroInterior = table.Column<string>(maxLength: 8, nullable: false),
                    numeroExterior = table.Column<string>(maxLength: 8, nullable: false),
                    codigoPostal = table.Column<string>(maxLength: 5, nullable: false),
                    Cardinalidad = table.Column<string>(maxLength: 10, nullable: true),
                    fkCiudad = table.Column<int>(nullable: false),
                    fkHorario = table.Column<int>(nullable: false),
                    sueldoDiario = table.Column<double>(nullable: false),
                    fkPuesto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.idEmpleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Puesto_fkPuesto",
                        column: x => x.fkPuesto,
                        principalTable: "Puesto",
                        principalColumn: "idPuesto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_fkPuesto",
                table: "Empleado",
                column: "fkPuesto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
