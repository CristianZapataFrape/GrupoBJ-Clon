using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Usuario_Sistema_PerfilEliminarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceso_Usuario_Sistema_Perfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceso_Usuario_Sistema_Perfil",
                columns: table => new
                {
                    idAccesoUsuarioSistemaPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(type: "bit", nullable: true),
                    fechaCr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaMod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fkPerfil = table.Column<int>(type: "int", nullable: true),
                    fkSistema = table.Column<int>(type: "int", nullable: true),
                    fkUsuario = table.Column<int>(type: "int", nullable: true),
                    fkUsuarioCr = table.Column<int>(type: "int", nullable: false),
                    fkUsuarioMod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceso_Usuario_Sistema_Perfil", x => x.idAccesoUsuarioSistemaPerfil);
                    table.ForeignKey(
                        name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Perfil_fkPerfil",
                        column: x => x.fkPerfil,
                        principalTable: "Acceso_Perfil",
                        principalColumn: "idPerfil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Sistema_fkSistema",
                        column: x => x.fkSistema,
                        principalTable: "Acceso_Sistema",
                        principalColumn: "idSistema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acceso_Usuario_Sistema_Perfil_Usuario_fkUsuario",
                        column: x => x.fkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Usuario_Sistema_Perfil_fkPerfil",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Usuario_Sistema_Perfil_fkSistema",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Usuario_Sistema_Perfil_fkUsuario",
                table: "Acceso_Usuario_Sistema_Perfil",
                column: "fkUsuario");
        }
    }
}
