using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Usuario_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario_Empresa_Sucursal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario_Empresa_Sucursal",
                columns: table => new
                {
                    idUsuarioEmpresaSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(type: "bit", nullable: true),
                    fechaCr = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fechaMod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fkEmpresa = table.Column<int>(type: "int", nullable: true),
                    fkSucursal = table.Column<int>(type: "int", nullable: true),
                    fkUsuario = table.Column<int>(type: "int", nullable: true),
                    fkUsuarioCr = table.Column<int>(type: "int", nullable: false),
                    fkUsuarioMod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Empresa_Sucursal", x => x.idUsuarioEmpresaSucursal);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Empresa_fkEmpresa",
                        column: x => x.fkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sucursal_fkSucursal",
                        column: x => x.fkSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "idSucursal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Usuario_fkUsuario",
                        column: x => x.fkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_fkEmpresa",
                table: "Usuario_Empresa_Sucursal",
                column: "fkEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_fkSucursal",
                table: "Usuario_Empresa_Sucursal",
                column: "fkSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Sucursal_fkUsuario",
                table: "Usuario_Empresa_Sucursal",
                column: "fkUsuario");
        }
    }
}
