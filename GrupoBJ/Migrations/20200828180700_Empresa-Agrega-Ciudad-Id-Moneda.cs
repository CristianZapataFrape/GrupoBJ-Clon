using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class EmpresaAgregaCiudadIdMoneda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkCiudad",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkMoneda",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "sIdEmpresa",
                table: "Empresa",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fkCiudad",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "fkMoneda",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "sIdEmpresa",
                table: "Empresa");
        }
    }
}
