using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AgregarModeloUsuario_Empresa_Sucursal_Sis_Per : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario_Empresa_Sucursal_Sis_Per",
                columns: table => new
                {
                    idUsuEmpSucSisPer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkUsuario = table.Column<int>(nullable: true),
                    fkEmpresa = table.Column<int>(nullable: true),
                    fkSucursal = table.Column<int>(nullable: true),
                    fkSistema = table.Column<int>(nullable: true),
                    fkPerfil = table.Column<int>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMod = table.Column<int>(nullable: false),
                    fechaMod = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Empresa_Sucursal_Sis_Per", x => x.idUsuEmpSucSisPer);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sis_Per_Empresa_fkEmpresa",
                        column: x => x.fkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sis_Per_Acceso_Perfil_fkPerfil",
                        column: x => x.fkPerfil,
                        principalTable: "Acceso_Perfil",
                        principalColumn: "idPerfil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sis_Per_Acceso_Sistema_fkSistema",
                        column: x => x.fkSistema,
                        principalTable: "Acceso_Sistema",
                        principalColumn: "idSistema",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sis_Per_Sucursal_fkSucursal",
                        column: x => x.fkSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "idSucursal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sis_Per_Usuario_fkUsuario",
                        column: x => x.fkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_Sis_Per_fkEmpresa",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                column: "fkEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_Sis_Per_fkPerfil",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                column: "fkPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_Sis_Per_fkSistema",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                column: "fkSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_Sis_Per_fkSucursal",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                column: "fkSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_Sis_Per_fkUsuario",
                table: "Usuario_Empresa_Sucursal_Sis_Per",
                column: "fkUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario_Empresa_Sucursal_Sis_Per");
        }
    }
}
