using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GrupoBJ.Migrations
{
    public partial class AgregarModeloNom_RegistroPatronal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nom_RegistroPatronal",
                columns: table => new
                {
                    idRegistroPatronal = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rfc = table.Column<string>(maxLength: 13, nullable: true),
                    fechaConstitucion = table.Column<DateTime>(nullable: false),
                    registroImss = table.Column<string>(maxLength: 13, nullable: true),
                    claseRiesgoTrabajo = table.Column<int>(nullable: false),
                    fraccionRiesgoTrabajo = table.Column<int>(nullable: false),
                    fkCiudadRegistroPatronal = table.Column<int>(nullable: true),
                    codigoPostal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nom_RegistroPatronal", x => x.idRegistroPatronal);
                    table.ForeignKey(
                        name: "FK_Nom_RegistroPatronal_Ciudad_fkCiudadRegistroPatronal",
                        column: x => x.fkCiudadRegistroPatronal,
                        principalTable: "Ciudad",
                        principalColumn: "idCiudad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nom_RegistroPatronal_fkCiudadRegistroPatronal",
                table: "Nom_RegistroPatronal",
                column: "fkCiudadRegistroPatronal");
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "Nom_RegistroPatronal");
        //}
    }
}
