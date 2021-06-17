using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EmpleadoActualizacionNomina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "afectado",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "afectadoExtraordinario",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ajusteAlNeto",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "altaImss",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "bajaImss",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "baseCotizacionImss",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "basePago",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "calculado",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "calculadoExtraordinario",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "calculoAguinaldo",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "calculoptu",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "cambioCotizacionImss",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "causaBaja",
                table: "Empleado",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "centroCosto",
                table: "Empleado",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codigoEmpleado",
                table: "Empleado",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "diasPrimaVacTomadasAntesDeAlta",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "diasVacacionesTomadasAntesDeAlta",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "estadoEmpleado",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "estadoEmpleadoPeriodo",
                table: "Empleado",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "extranjeroSinCurp",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaAlta",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaBaja",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaSueldoDiario",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaSueldoIntegrado",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaSueldoMixto",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaSueldoPromedio",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaSueldoVariable",
                table: "Empleado",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkDepartamento",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fkRegistroPatronal",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fkTipoPeriodo",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fkTurno",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "formaPago",
                table: "Empleado",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "iut",
                table: "Empleado",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lugarNacimiento",
                table: "Empleado",
                maxLength: 70,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "modificacionSalarioImss",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreMadre",
                table: "Empleado",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombrePadre",
                table: "Empleado",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numeroAfore",
                table: "Empleado",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "numeroFonacot",
                table: "Empleado",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "porcentajePensionAlimenticia",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "sexo",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "subcontratacion",
                table: "Empleado",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sucursalBanco",
                table: "Empleado",
                maxLength: 3,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "sueldoBaseLiquidacion",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sueldoIntegrado",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sueldoMixto",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sueldoNetoMensual",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sueldoPromedio",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "sueldoVariable",
                table: "Empleado",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "tipoContrato",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tipoEmpleado",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "tipoPrestacion",
                table: "Empleado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "tipoRegimen",
                table: "Empleado",
                maxLength: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "umf",
                table: "Empleado",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "zonaSalario",
                table: "Empleado",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_fkDepartamento",
                table: "Empleado",
                column: "fkDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_fkRegistroPatronal",
                table: "Empleado",
                column: "fkRegistroPatronal");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_fkTipoPeriodo",
                table: "Empleado",
                column: "fkTipoPeriodo");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_fkTurno",
                table: "Empleado",
                column: "fkTurno");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Departamento_fkDepartamento",
                table: "Empleado",
                column: "fkDepartamento",
                principalTable: "Departamento",
                principalColumn: "idDepartamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Nom_RegistroPatronal_fkRegistroPatronal",
                table: "Empleado",
                column: "fkRegistroPatronal",
                principalTable: "Nom_RegistroPatronal",
                principalColumn: "idRegistroPatronal",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Nom_TipoPeriodo_fkTipoPeriodo",
                table: "Empleado",
                column: "fkTipoPeriodo",
                principalTable: "Nom_TipoPeriodo",
                principalColumn: "idTipoPeriodo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Turnos_fkTurno",
                table: "Empleado",
                column: "fkTurno",
                principalTable: "Turnos",
                principalColumn: "idTurno",
                onDelete: ReferentialAction.Restrict);
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Empleado_Departamento_fkDepartamento",
        //        table: "Empleado");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Empleado_Nom_RegistroPatronal_fkRegistroPatronal",
        //        table: "Empleado");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Empleado_Nom_TipoPeriodo_fkTipoPeriodo",
        //        table: "Empleado");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_Empleado_Turnos_fkTurno",
        //        table: "Empleado");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Empleado_fkDepartamento",
        //        table: "Empleado");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Empleado_fkRegistroPatronal",
        //        table: "Empleado");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Empleado_fkTipoPeriodo",
        //        table: "Empleado");

        //    migrationBuilder.DropIndex(
        //        name: "IX_Empleado_fkTurno",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "afectado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "afectadoExtraordinario",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "ajusteAlNeto",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "altaImss",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "bajaImss",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "baseCotizacionImss",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "basePago",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "calculado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "calculadoExtraordinario",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "calculoAguinaldo",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "calculoptu",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "cambioCotizacionImss",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "causaBaja",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "centroCosto",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "codigoEmpleado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "diasPrimaVacTomadasAntesDeAlta",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "diasVacacionesTomadasAntesDeAlta",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "estadoEmpleado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "estadoEmpleadoPeriodo",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "extranjeroSinCurp",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaAlta",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaBaja",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaSueldoDiario",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaSueldoIntegrado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaSueldoMixto",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaSueldoPromedio",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fechaSueldoVariable",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fkDepartamento",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fkRegistroPatronal",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fkTipoPeriodo",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "fkTurno",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "formaPago",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "iut",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "lugarNacimiento",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "modificacionSalarioImss",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "nombreMadre",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "nombrePadre",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "numeroAfore",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "numeroFonacot",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "porcentajePensionAlimenticia",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sexo",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "subcontratacion",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sucursalBanco",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sueldoBaseLiquidacion",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sueldoIntegrado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sueldoMixto",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sueldoNetoMensual",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sueldoPromedio",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "sueldoVariable",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "tipoContrato",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "tipoEmpleado",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "tipoPrestacion",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "tipoRegimen",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "umf",
        //        table: "Empleado");

        //    migrationBuilder.DropColumn(
        //        name: "zonaSalario",
        //        table: "Empleado");
        //}
    }
}
