using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class MigracionPais2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    idPais = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sNombrePais = table.Column<string>(nullable: false),
                    fkUsuarioCreo = table.Column<int>(nullable: false),
                    dFechaUsuarioCreo = table.Column<DateTime>(nullable: false),
                    fkUsuarioModifico = table.Column<int>(nullable: false),
                    dFechaUsuarioModifico = table.Column<DateTime>(nullable: false),
                    bHabilitado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.idPais);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
