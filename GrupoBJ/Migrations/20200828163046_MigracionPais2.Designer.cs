﻿// <auto-generated />
using System;
using GrupoBJ.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GrupoBJ.Migrations
{
    [DbContext(typeof(GrupoBJDBContext))]
    [Migration("20200828163046_MigracionPais2")]
    partial class MigracionPais2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrupoBJ.Models.Empresa", b =>
                {
                    b.Property<int>("idEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("bHabilitado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaUsuarioCreo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaUsuarioModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkUsuarioCreo")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioModifico")
                        .HasColumnType("int");

                    b.Property<string>("sCalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sCardinalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sCelular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sCodigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sColonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sFax")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sNumeroExterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sNumeroInterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sRFC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sRazonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idEmpresa");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("GrupoBJ.Models.Pais", b =>
                {
                    b.Property<int>("idPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("bHabilitado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("dFechaUsuarioCreo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("dFechaUsuarioModifico")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkUsuarioCreo")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioModifico")
                        .HasColumnType("int");

                    b.Property<string>("sNombrePais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPais");

                    b.ToTable("Pais");
                });
#pragma warning restore 612, 618
        }
    }
}
