using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AccesoPermisoPerfilOpcionAgregarfkOpcionPermiso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fkOpcionPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkOpcionPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkOpcionPermiso");

            migrationBuilder.AddForeignKey(
                name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Opcion_Permiso_fkOpcionPermiso",
                table: "Acceso_Permiso_Perfil_Opcion",
                column: "fkOpcionPermiso",
                principalTable: "Acceso_Opcion_Permiso",
                principalColumn: "idOpcionPermiso",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acceso_Permiso_Perfil_Opcion_Acceso_Opcion_Permiso_fkOpcionPermiso",
                table: "Acceso_Permiso_Perfil_Opcion");

            migrationBuilder.DropIndex(
                name: "IX_Acceso_Permiso_Perfil_Opcion_fkOpcionPermiso",
                table: "Acceso_Permiso_Perfil_Opcion");

            migrationBuilder.DropColumn(
                name: "fkOpcionPermiso",
                table: "Acceso_Permiso_Perfil_Opcion");
        }
    }
}
