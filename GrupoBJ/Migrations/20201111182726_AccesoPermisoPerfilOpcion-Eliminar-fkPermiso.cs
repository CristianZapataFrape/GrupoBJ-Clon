using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AccesoPermisoPerfilOpcionEliminarfkPermiso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Permiso_fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion");

            migrationBuilder.DropIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion");

            migrationBuilder.DropColumn(
                name: "fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkPermiso");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Permiso_fkPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkPermiso",
                principalTable: "Acceso_Permiso",
                principalColumn: "idPermiso",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
