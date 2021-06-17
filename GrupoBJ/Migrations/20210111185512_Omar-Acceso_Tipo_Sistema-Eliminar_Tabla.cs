using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarAcceso_Tipo_SistemaEliminar_Tabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Acceso_Tipo_Sistema");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Acceso_Tipo_Sistema",
            //    columns: table => new
            //    {
            //        idTipoSistema = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Habilitado = table.Column<bool>(type: "bit", nullable: true),
            //        Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
            //        fechaCr = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        fechaUm = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        fkUsuarioCr = table.Column<int>(type: "int", nullable: false),
            //        fkUsuarioUm = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Acceso_Tipo_Sistema", x => x.idTipoSistema);
            //    });
        }
    }
}
