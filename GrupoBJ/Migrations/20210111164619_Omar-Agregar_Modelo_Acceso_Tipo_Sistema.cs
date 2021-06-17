using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarAgregar_Modelo_Acceso_Tipo_Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.CreateTable(
        //        name: "Acceso_Tipo_Sistema",
        //        columns: table => new
        //        {
        //            idTipoSistema = table.Column<int>(nullable: false)
        //                .Annotation("SqlServer:Identity", "1, 1"),
        //            Nombre = table.Column<string>(maxLength: 150, nullable: false),
        //            fkUsuarioCr = table.Column<int>(nullable: false),
        //            fechaCr = table.Column<DateTime>(nullable: false),
        //            Habilitado = table.Column<bool>(nullable: true),
        //            fkUsuarioUm = table.Column<int>(nullable: false),
        //            fechaUm = table.Column<DateTime>(nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_Acceso_Tipo_Sistema", x => x.idTipoSistema);
        //        });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Acceso_Tipo_Sistema");
        }
    }
}
