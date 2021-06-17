using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class MigracionInicialEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    idEmpresa = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sNombre = table.Column<string>(nullable: false),
                    sRazonSocial = table.Column<string>(nullable: false),
                    sRFC = table.Column<string>(nullable: false),
                    sCodigoPostal = table.Column<string>(nullable: false),
                    sCalle = table.Column<string>(nullable: false),
                    sColonia = table.Column<string>(nullable: false),
                    sNumeroInterior = table.Column<string>(nullable: false),
                    sNumeroExterior = table.Column<string>(nullable: false),
                    sCardinalidad = table.Column<string>(nullable: true),
                    sTelefono = table.Column<string>(nullable: false),
                    sCelular = table.Column<string>(nullable: false),
                    sFax = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.idEmpresa);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
