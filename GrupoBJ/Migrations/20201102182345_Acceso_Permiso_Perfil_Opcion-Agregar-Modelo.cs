using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Permiso_Perfil_OpcionAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceso_Permiso_Perfil_Opcion",
                columns: table => new
                {
                    idPermisoPerfilOpcion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkPerfil = table.Column<int>(nullable: true),
                    fkOpcion = table.Column<int>(nullable: true),
                    fkPermiso = table.Column<int>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMod = table.Column<int>(nullable: false),
                    fechaMod = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceso_Permiso_Perfil_Opcion", x => x.idPermisoPerfilOpcion);
                    table.ForeignKey(
                        name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Opcion_fkOpcion",
                        column: x => x.fkOpcion,
                        principalTable: "Acceso_Opcion",
                        principalColumn: "idOpcion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Perfil_fkPerfil",
                        column: x => x.fkPerfil,
                        principalTable: "Acceso_Perfil",
                        principalColumn: "idPerfil",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Permiso_fkPermiso",
                        column: x => x.fkPermiso,
                        principalTable: "Acceso_Permiso",
                        principalColumn: "idPermiso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkOpcion",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkOpcion");

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkPerfil",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkPerfil");

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkPermiso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceso_Permiso_Perfil_Opcion");
        }
    }
}
