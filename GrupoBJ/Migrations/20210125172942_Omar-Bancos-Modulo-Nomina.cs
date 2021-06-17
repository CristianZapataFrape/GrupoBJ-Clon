using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarBancosModuloNomina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Banco",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RFC",
                table: "Banco",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "esBancoExtranjero",
                table: "Banco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "paginaWeb",
                table: "Banco",
                maxLength: 250,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Banco");

            migrationBuilder.DropColumn(
                name: "RFC",
                table: "Banco");

            migrationBuilder.DropColumn(
                name: "esBancoExtranjero",
                table: "Banco");

            migrationBuilder.DropColumn(
                name: "paginaWeb",
                table: "Banco");
        }
    }
}
