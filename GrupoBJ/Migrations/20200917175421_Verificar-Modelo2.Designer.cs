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
    [Migration("20200917175421_Verificar-Modelo2")]
    partial class VerificarModelo2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrupoBJ.Models.Ciudad", b =>
                {
                    b.Property<int>("idCiudad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkEstado")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idCiudad");

                    b.HasIndex("fkEstado");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("GrupoBJ.Models.Empresa", b =>
                {
                    b.Property<int>("idEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Cardinalidad")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("RFC")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("codigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkCiudad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkMoneda")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("numeroExterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("numeroInterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("razonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("idEmpresa");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("GrupoBJ.Models.Estado", b =>
                {
                    b.Property<int>("idEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkPais")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idEstado");

                    b.HasIndex("fkPais");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("GrupoBJ.Models.Moneda", b =>
                {
                    b.Property<int>("idMoneda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("ISO")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Simbolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("textoPosterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("idMoneda");

                    b.ToTable("Moneda");
                });

            modelBuilder.Entity("GrupoBJ.Models.Pais", b =>
                {
                    b.Property<int>("idPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idPais");

                    b.ToTable("Pais");
                });

            modelBuilder.Entity("GrupoBJ.Models.Sucursal", b =>
                {
                    b.Property<int>("idSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Cardinalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Colonia")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("codigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkCiudad")
                        .HasColumnType("int");

                    b.Property<int>("fkEmpresa")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("numeroExterior")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("numeroInterior")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("idSucursal");

                    b.HasIndex("fkEmpresa");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("GrupoBJ.Models.Ciudad", b =>
                {
                    b.HasOne("GrupoBJ.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("fkEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoBJ.Models.Estado", b =>
                {
                    b.HasOne("GrupoBJ.Models.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("fkPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoBJ.Models.Sucursal", b =>
                {
                    b.HasOne("GrupoBJ.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("fkEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
