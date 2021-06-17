using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarNominasTablaNom_FraccionesImss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_FraccionesImss",
                columns: table => new
                {
                    idFraccionesImss = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(maxLength: 5, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: false),
                    Clase = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_FraccionesImss", x => x.idFraccionesImss);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nom_FraccionesImss");
        }
    }
}
