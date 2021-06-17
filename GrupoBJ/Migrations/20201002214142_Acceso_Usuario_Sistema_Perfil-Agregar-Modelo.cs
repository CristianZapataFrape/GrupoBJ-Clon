using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Usuario_Sistema_PerfilAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceso_Usuario_Sistema_Perfil",
                columns: table => new
                {
                    idAccesoUsuarioSistemaPerfil = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkUsuario = table.Column<int>(nullable: false),
                    fkSistema = table.Column<int>(nullable: false),
                    fkPerfil = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceso_Usuario_Sistema_Perfil", x => x.idAccesoUsuarioSistemaPerfil);
                    table.ForeignKey(
                        name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Perfil_fkPerfil",
                        column: x => x.fkPerfil,
                        principalTable: "Acceso_Perfil",
                        principalColumn: "idPerfil");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acceso_Usuario_Sistema_Perfil_Acceso_Sistema_fkSistema",
                        column: x => x.fkSistema,
                        principalTable: "Acceso_Sistema",
                        principalColumn: "idSistema");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acceso_Usuario_Sistema_Perfil_Usuario_fkUsuario",
                        column: x => x.fkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                        //onDelete: ReferentialAction.Cascade);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceso_Usuario_Sistema_Perfil");
        }
    }
}
