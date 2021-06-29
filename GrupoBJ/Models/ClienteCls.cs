using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class ClienteCls
    {
        [Key]
        
        [Display(Name = "Código")]
        public int id_Cliente { get; set; }

     //   [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

      //  [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Apellido paterno")]
        public string? apPaterno { get; set; }

       // [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Apellido materno")]
        public string? apMaterno { get; set; }

     //   [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Email")]
        public string? Email { get; set; }


      //  [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Ciudad")]
        public string? fkCiudad { get; set; }


      //  [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Pais")]
        public string? fkPais { get; set; }

       // [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Nombre compañia")]

        public string? nombreCompania { get; set; }

        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Código postal")]

        public string? CP { get; set; }


        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Razon Social")]

        public string? razonSocial { get; set; }


        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(13, ErrorMessage = "(A)La longitud máxima del permiso es 13 caracteres")]
        [Display(Name = "RFC")]

        public string? rfcFacturacion { get; set; }


        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Domicilio")]

        public string? domicilioFacturacion { get; set; }

        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(10, ErrorMessage = "(A)La longitud máxima del permiso es 10 digitos")]
        [Display(Name = "Telefono")]

        public string? Telefono { get; set; }


        public bool? Habilitado { get; set; }


        public decimal? Saldo { get; set; }
        public decimal? limiteCredito { get; set; }

        public decimal? tipoFacturacion { get; set; }


        public DateTime? FechaCr { get; set; }
        public int? fkUsuarioCr { get; set; }
        public int? fkUsuarioUm { get; set; }
        public DateTime? FechaUm { get; set; }


        //public int? fkSucursal { get; set; }
        //[ForeignKey("fkSucursal")]
        //public Sucursal Sucursal { get; set; }

        public int? fkProveedor { get; set; }


        [ForeignKey("fkProveedor")]
        public Proveedorcs Proveedor { get; set; }

        public int? fkMoneda { get; set; }

    }
}
