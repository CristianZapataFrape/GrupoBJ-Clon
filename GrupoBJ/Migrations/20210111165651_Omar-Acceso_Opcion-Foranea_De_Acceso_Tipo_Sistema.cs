using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class OmarAcceso_OpcionForanea_De_Acceso_Tipo_Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "fkTipoSistema",
            //    table: "Acceso_Opcion",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Acceso_Opcion_fkTipoSistema",
            //    table: "Acceso_Opcion",
            //    column: "fkTipoSistema");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Acceso_Opcion_Acceso_Tipo_Sistema_fkTipoSistema",
            //    table: "Acceso_Opcion",
            //    column: "fkTipoSistema",
            //    principalTable: "Acceso_Tipo_Sistema",
            //    principalColumn: "idTipoSistema",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Acceso_Opcion_Acceso_Tipo_Sistema_fkTipoSistema",
            //    table: "Acceso_Opcion");

            //migrationBuilder.DropIndex(
            //    name: "IX_Acceso_Opcion_fkTipoSistema",
            //    table: "Acceso_Opcion");

            //migrationBuilder.DropColumn(
            //    name: "fkTipoSistema",
            //    table: "Acceso_Opcion");
        }
    }
}
