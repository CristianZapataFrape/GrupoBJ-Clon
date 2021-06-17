using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Usuario_Sistema_PefilActualizarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Perfil_fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Sistema_fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Usuario_fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.AlterColumn<int>(
                name: "fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Perfil_fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkPerfil",
                principalTable: "Acceso_Perfil",
                principalColumn: "idPerfil",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Sistema_fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkSistema",
                principalTable: "Acceso_Sistema",
                principalColumn: "idSistema",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Usuario_fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Perfil_fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Sistema_fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Usuario_fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil");

            migrationBuilder.AlterColumn<int>(
                name: "fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Perfil_fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkPerfil",
                principalTable: "Acceso_Perfil",
                principalColumn: "idPerfil",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Sistema_fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkSistema",
                principalTable: "Acceso_Sistema",
                principalColumn: "idSistema",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Usuario_Sistema_Perfil_Usuario_fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkUsuario",
                principalTable: "Usuario",
                principalColumn: "idUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
