using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_Opcion_PermisoAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceso_Opcion_Permiso",
                columns: table => new
                {
                    idOpcionPermiso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkOpcion = table.Column<int>(nullable: true),
                    fkPermiso = table.Column<int>(nullable: true),
                    Clase = table.Column<string>(nullable: true),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMod = table.Column<int>(nullable: false),
                    fechaMod = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceso_Opcion_Permiso", x => x.idOpcionPermiso);
                    table.ForeignKey(
                        name: "FK_Acceso_Opcion_Permiso_Acceso_Opcion_fkOpcion",
                        column: x => x.fkOpcion,
                        principalTable: "Acceso_Opcion",
                        principalColumn: "idOpcion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Acceso_Opcion_Permiso_Acceso_Permiso_fkPermiso",
                        column: x => x.fkPermiso,
                        principalTable: "Acceso_Permiso",
                        principalColumn: "idPermiso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Opcion_Permiso_fkOpcion",
                table: "Acceso_Opcion_Permiso",
                column: "fkOpcion");

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Opcion_Permiso_fkPermiso",
                table: "Acceso_Opcion_Permiso",
                column: "fkPermiso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceso_Opcion_Permiso");
        }
    }
}
