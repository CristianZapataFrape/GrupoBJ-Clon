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
    [Migration("20201009174424_Acceso_Usuario_Sistema_Pefil-Actualizar-Modelo")]
    partial class Acceso_Usuario_Sistema_PefilActualizarModelo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrupoBJ.Models.Acceso_Perfil", b =>
                {
                    b.Property<int>("idPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkSistema")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idPerfil");

                    b.HasIndex("fkSistema");

                    b.ToTable("Acceso_Perfil");
                });

            modelBuilder.Entity("GrupoBJ.Models.Acceso_Sistema", b =>
                {
                    b.Property<int>("idSistema")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idSistema");

                    b.ToTable("Acceso_Sistema");
                });

            modelBuilder.Entity("GrupoBJ.Models.Acceso_Usuario_Sistema_Perfil", b =>
                {
                    b.Property<int>("idAccesoUsuarioSistemaPerfil")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkPerfil")
                        .HasColumnType("int");

                    b.Property<int?>("fkSistema")
                        .HasColumnType("int");

                    b.Property<int?>("fkUsuario")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idAccesoUsuarioSistemaPerfil");

                    b.HasIndex("fkPerfil");

                    b.HasIndex("fkSistema");

                    b.HasIndex("fkUsuario");

                    b.ToTable("Acceso_Usuario_Sistema_Perfil");
                });

            modelBuilder.Entity("GrupoBJ.Models.Banco", b =>
                {
                    b.Property<int>("idBanco")
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

                    b.HasKey("idBanco");

                    b.ToTable("Banco");
                });

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

            modelBuilder.Entity("GrupoBJ.Models.Departamento", b =>
                {
                    b.Property<int>("idDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkEmpresa")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idDepartamento");

                    b.HasIndex("fkEmpresa");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("GrupoBJ.Models.Empleado", b =>
                {
                    b.Property<int>("idEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CURP")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

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
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Fotografia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("IMSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("apMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("apPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("clabeInterbancaria")
                        .IsRequired()
                        .HasColumnType("nvarchar(18)")
                        .HasMaxLength(18);

                    b.Property<string>("codigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)")
                        .HasMaxLength(5);

                    b.Property<string>("correoElectronico")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("cuentaBancaria")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("fechaNacimiento")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkBanco")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkCiudad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkEstadoCivil")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkHorario")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkPuesto")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkSucursal")
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

                    b.Property<double?>("sueldoDiario")
                        .IsRequired()
                        .HasColumnType("float");

                    b.HasKey("idEmpleado");

                    b.HasIndex("fkPuesto");

                    b.HasIndex("fkSucursal");

                    b.ToTable("Empleado");
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

            modelBuilder.Entity("GrupoBJ.Models.Estado_Civil", b =>
                {
                    b.Property<int>("idEstadoCivil")
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

                    b.HasKey("idEstadoCivil");

                    b.ToTable("Estado_Civil");
                });

            modelBuilder.Entity("GrupoBJ.Models.Horario", b =>
                {
                    b.Property<int>("idHorario")
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

                    b.HasKey("idHorario");

                    b.ToTable("Horario");
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

            modelBuilder.Entity("GrupoBJ.Models.Puesto", b =>
                {
                    b.Property<int>("idPuesto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkDepartamento")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idPuesto");

                    b.HasIndex("fkDepartamento");

                    b.ToTable("Puesto");
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

                    b.Property<int?>("fkCiudad")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("fkEmpresa")
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
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("idSucursal");

                    b.HasIndex("fkEmpresa");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("GrupoBJ.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("correoElectronico")
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("fechaCaducidad")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("menuProduccion")
                        .HasColumnType("bit");

                    b.Property<string>("nombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool?>("nuncaCaduca")
                        .HasColumnType("bit");

                    b.HasKey("idUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("GrupoBJ.Models.Usuario_Empresa_Sucursal", b =>
                {
                    b.Property<int>("idUsuarioEmpresaSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaCr")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaMod")
                        .HasColumnType("datetime2");

                    b.Property<int?>("fkEmpresa")
                        .HasColumnType("int");

                    b.Property<int?>("fkSucursal")
                        .HasColumnType("int");

                    b.Property<int?>("fkUsuario")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioCr")
                        .HasColumnType("int");

                    b.Property<int>("fkUsuarioMod")
                        .HasColumnType("int");

                    b.HasKey("idUsuarioEmpresaSucursal");

                    b.HasIndex("fkEmpresa");

                    b.HasIndex("fkSucursal");

                    b.HasIndex("fkUsuario");

                    b.ToTable("Usuario_Empresa_Sucursal");
                });

            modelBuilder.Entity("GrupoBJ.Models.Acceso_Perfil", b =>
                {
                    b.HasOne("GrupoBJ.Models.Acceso_Sistema", "Acceso_Sistema")
                        .WithMany()
                        .HasForeignKey("fkSistema")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoBJ.Models.Acceso_Usuario_Sistema_Perfil", b =>
                {
                    b.HasOne("GrupoBJ.Models.Acceso_Perfil", "Acceso_Perfil")
                        .WithMany()
                        .HasForeignKey("fkPerfil");

                    b.HasOne("GrupoBJ.Models.Acceso_Sistema", "Acceso_Sistema")
                        .WithMany()
                        .HasForeignKey("fkSistema");

                    b.HasOne("GrupoBJ.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("fkUsuario");
                });

            modelBuilder.Entity("GrupoBJ.Models.Ciudad", b =>
                {
                    b.HasOne("GrupoBJ.Models.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("fkEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoBJ.Models.Departamento", b =>
                {
                    b.HasOne("GrupoBJ.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("fkEmpresa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GrupoBJ.Models.Empleado", b =>
                {
                    b.HasOne("GrupoBJ.Models.Puesto", "Puesto")
                        .WithMany()
                        .HasForeignKey("fkPuesto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GrupoBJ.Models.Sucursal", "Sucursal")
                        .WithMany()
                        .HasForeignKey("fkSucursal")
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

            modelBuilder.Entity("GrupoBJ.Models.Puesto", b =>
                {
                    b.HasOne("GrupoBJ.Models.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("fkDepartamento")
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

            modelBuilder.Entity("GrupoBJ.Models.Usuario_Empresa_Sucursal", b =>
                {
                    b.HasOne("GrupoBJ.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("fkEmpresa");

                    b.HasOne("GrupoBJ.Models.Sucursal", "Sucursal")
                        .WithMany()
                        .HasForeignKey("fkSucursal");

                    b.HasOne("GrupoBJ.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("fkUsuario");
                });
#pragma warning restore 612, 618
        }
    }
}
