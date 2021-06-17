using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Acceso_OpcionAgregarModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acceso_Opcion",
                columns: table => new
                {
                    idOpcion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkSistema = table.Column<int>(nullable: false),
                    idOpcionPadre = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 150, nullable: false),
                    Posicion = table.Column<int>(nullable: false),
                    fkTipoArchivo = table.Column<int>(nullable: false),
                    Controlador = table.Column<string>(maxLength: 150, nullable: false),
                    fkUsuarioCr = table.Column<int>(nullable: false),
                    fechaCr = table.Column<DateTime>(nullable: false),
                    fkUsuarioMod = table.Column<int>(nullable: false),
                    fechaMod = table.Column<DateTime>(nullable: false),
                    Habilitado = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acceso_Opcion", x => x.idOpcion);
                    table.ForeignKey(
                        name: "FK_Acceso_Opcion_Acceso_Sistema_fkSistema",
                        column: x => x.fkSistema,
                        principalTable: "Acceso_Sistema",
                        principalColumn: "idSistema",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acceso_Opcion_Acceso_Tipo_Archivo_fkTipoArchivo",
                        column: x => x.fkTipoArchivo,
                        principalTable: "Acceso_Tipo_Archivo",
                        principalColumn: "idTipoArchivo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Opcion_fkSistema",
                table: "Acceso_Opcion",
                column: "fkSistema");

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Opcion_fkTipoArchivo",
                table: "Acceso_Opcion",
                column: "fkTipoArchivo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acceso_Opcion");
        }
    }
}
