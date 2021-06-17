using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class Arquimides_Modelos_Areas_Trabajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Areas_Trabajo",
            //    columns: table => new
            //    {
            //        id_Areas_Trabajo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        idEmpresa = table.Column<int>(nullable: false),
            //        idHorario = table.Column<int>(nullable: false),
            //        Nombre_Area_Trabajo = table.Column<string>(maxLength: 150, nullable: false),
            //        Transferencias_Por_Articulo = table.Column<int>(nullable: false),
            //        fkUsuarioCr = table.Column<int>(nullable: false),
            //        fechaCr = table.Column<DateTime>(nullable: false),
            //        fkUsuarioUm = table.Column<int>(nullable: false),
            //        fechaUm = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Areas_Trabajo", x => x.id_Areas_Trabajo);
            //    table.ForeignKey(
            //        name: "FK_Areas_Trabajo_Empresa_idEmpresa",
            //        column: x => x.idEmpresa,
            //        principalTable: "Empresa",
            //        principalColumn: "idEmpresa");
            //        // onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Areas_Trabajo_Horario_idHorario",
            //            column: x => x.idHorario,
            //            principalTable: "Horario",
            //            principalColumn: "idHorario");
            //            //onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Articulos_Areas_Trabajo",
            //    columns: table => new
            //    {
            //        id_Articulos_Areas_Trabajo = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        id_Articulos = table.Column<int>(nullable: false),
            //        id_Areas_Trabajo = table.Column<int>(nullable: false),
            //        fkUsuarioCr = table.Column<int>(nullable: false),
            //        fechaCr = table.Column<DateTime>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Articulos_Areas_Trabajo", x => x.id_Articulos_Areas_Trabajo);
            //        table.ForeignKey(
            //            name: "FK_Articulos_Areas_Trabajo_Areas_Trabajo_id_Areas_Trabajo",
            //            column: x => x.id_Areas_Trabajo,
            //            principalTable: "Areas_Trabajo",
            //            principalColumn: "id_Areas_Trabajo");
            //    //onDelete: ReferentialAction.Cascade);
            //    table.ForeignKey(
            //        name: "FK_Articulos_Areas_Trabajo_Articulos_id_Articulos",
            //        column: x => x.id_Articulos,
            //        principalTable: "Articulos",
            //        principalColumn: "id_Articulos");
            //          //  onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Areas_Trabajo_idEmpresa",
            //    table: "Areas_Trabajo",
            //    column: "idEmpresa");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Areas_Trabajo_idHorario",
            //    table: "Areas_Trabajo",
            //    column: "idHorario");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Articulos_Areas_Trabajo_id_Areas_Trabajo",
            //    table: "Articulos_Areas_Trabajo",
            //    column: "id_Areas_Trabajo");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Articulos_Areas_Trabajo_id_Articulos",
            //    table: "Articulos_Areas_Trabajo",
            //    column: "id_Articulos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Articulos_Areas_Trabajo");

            //migrationBuilder.DropTable(
            //    name: "Areas_Trabajo");
        }
    }
}
