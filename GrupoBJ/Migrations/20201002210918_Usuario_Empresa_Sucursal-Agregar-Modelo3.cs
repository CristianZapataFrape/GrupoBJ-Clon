using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Usuario_Empresa_SucursalAgregarModelo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario_Empresa_Sucursal",
                columns: table => new
                {
                    idUsuarioEmpresaSucursal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fkUsuario = table.Column<int>(nullable: false),
                    fkEmpresa = table.Column<int>(nullable: false),
                    fkSucursal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Empresa_Sucursal", x => x.idUsuarioEmpresaSucursal);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Empresa_fkEmpresa",
                        column: x => x.fkEmpresa,
                        principalTable: "Empresa",
                        principalColumn: "idEmpresa");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Sucursal_fkSucursal",
                        column: x => x.fkSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "idSucursal");
                    //onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Sucursal_Usuario_fkUsuario",
                        column: x => x.fkUsuario,
                        principalTable: "Usuario",
                        principalColumn: "idUsuario");
                        //onDelete: ReferentialAction.Cascade);
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario_Empresa_Sucursal");
        }
    }
}
