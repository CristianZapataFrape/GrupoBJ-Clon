using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class ActualizarModeloUsuarioEmpresaSucursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Empresa_fkEmpresa",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Sucursal_fkSucursal",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Usuario_fkUsuario",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.AlterColumn<int>(
                name: "fkUsuario",
                table: "Usuario_Empresa_Sucursal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fkSucursal",
                table: "Usuario_Empresa_Sucursal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fkEmpresa",
                table: "Usuario_Empresa_Sucursal",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Empresa_fkEmpresa",
                table: "Usuario_Empresa_Sucursal",
                column: "fkEmpresa",
                principalTable: "Empresa",
                principalColumn: "idEmpresa",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Sucursal_fkSucursal",
                table: "Usuario_Empresa_Sucursal",
                column: "fkSucursal",
                principalTable: "Sucursal",
                principalColumn: "idSucursal",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Usuario_fkUsuario",
                table: "Usuario_Empresa_Sucursal",
                column: "fkUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Empresa_fkEmpresa",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Sucursal_fkSucursal",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Usuario_fkUsuario",
                table: "Usuario_Empresa_Sucursal");

            migrationBuilder.AlterColumn<int>(
                name: "fkUsuario",
                table: "Usuario_Empresa_Sucursal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fkSucursal",
                table: "Usuario_Empresa_Sucursal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fkEmpresa",
                table: "Usuario_Empresa_Sucursal",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Empresa_fkEmpresa",
                table: "Usuario_Empresa_Sucursal",
                column: "fkEmpresa",
                principalTable: "Empresa",
                principalColumn: "idEmpresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Sucursal_fkSucursal",
                table: "Usuario_Empresa_Sucursal",
                column: "fkSucursal",
                principalTable: "Sucursal",
                principalColumn: "idSucursal",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Empresa_Sucursal_Usuario_fkUsuario",
                table: "Usuario_Empresa_Sucursal",
                column: "fkUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
