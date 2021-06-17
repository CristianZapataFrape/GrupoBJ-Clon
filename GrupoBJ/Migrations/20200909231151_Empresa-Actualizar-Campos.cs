using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EmpresaActualizarCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bHabilitado",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fechaUsuarioCreo",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fechaUsuarioModifico",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCreo",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioModifico",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sCalle",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sCardinalidad",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sCelular",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sCodigoPostal",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sColonia",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sFax",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sIdEmpresa",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sNombre",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sNumeroExterior",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sNumeroInterior",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sRFC",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sRazonSocial",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sTelefono",
                table: "Empresa");

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Empresa",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cardinalidad",
                table: "Empresa",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Empresa",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Colonia",
                table: "Empresa",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "Empresa",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Empresa",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Empresa",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "Empresa",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Empresa",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "codigoPostal",
                table: "Empresa",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCr",
                table: "Empresa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaMod",
                table: "Empresa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCr",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioMod",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "numeroExterior",
                table: "Empresa",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "numeroInterior",
                table: "Empresa",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "razonSocial",
                table: "Empresa",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Cardinalidad",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Colonia",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "codigoPostal",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fechaCr",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fechaMod",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioCr",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkUsuarioMod",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "numeroExterior",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "numeroInterior",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "razonSocial",
                table: "Empresa");

            migrationBuilder.AddColumn<bool>(
                name: "bHabilitado",
                table: "Empresa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUsuarioCreo",
                table: "Empresa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaUsuarioModifico",
                table: "Empresa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioCreo",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkUsuarioModifico",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sCalle",
                table: "Empresa",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sCardinalidad",
                table: "Empresa",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "sCelular",
                table: "Empresa",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sCodigoPostal",
                table: "Empresa",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sColonia",
                table: "Empresa",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sFax",
                table: "Empresa",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "sIdEmpresa",
                table: "Empresa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "sNombre",
                table: "Empresa",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sNumeroExterior",
                table: "Empresa",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sNumeroInterior",
                table: "Empresa",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sRFC",
                table: "Empresa",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sRazonSocial",
                table: "Empresa",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "sTelefono",
                table: "Empresa",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}
