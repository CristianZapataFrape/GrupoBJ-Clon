using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarActualizarModeloMoneda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISO",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "textoPosterior",
                table: "Moneda");

            migrationBuilder.AlterColumn<string>(
                name: "Simbolo",
                table: "Moneda",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Moneda",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Decimales",
                table: "Moneda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Posicion",
                table: "Moneda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "fkMonedaSAT",
                table: "Moneda",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nombrePlural",
                table: "Moneda",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "nombreSingular",
                table: "Moneda",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "textoFinal",
                table: "Moneda",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Moneda_fkMonedaSAT",
                table: "Moneda",
                column: "fkMonedaSAT");

            migrationBuilder.AddForeignKey(
                name: "FK_Moneda_MonedaSAT_fkMonedaSAT",
                table: "Moneda",
                column: "fkMonedaSAT",
                principalTable: "MonedaSAT",
                principalColumn: "idMonedaSAT",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneda_MonedaSAT_fkMonedaSAT",
                table: "Moneda");

            migrationBuilder.DropIndex(
                name: "IX_Moneda_fkMonedaSAT",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "Decimales",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "Posicion",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "fkMonedaSAT",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "nombrePlural",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "nombreSingular",
                table: "Moneda");

            migrationBuilder.DropColumn(
                name: "textoFinal",
                table: "Moneda");

            migrationBuilder.AlterColumn<string>(
                name: "Simbolo",
                table: "Moneda",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AddColumn<string>(
                name: "ISO",
                table: "Moneda",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "textoPosterior",
                table: "Moneda",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }
    }
}
