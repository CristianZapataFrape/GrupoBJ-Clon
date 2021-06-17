using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Sucursal
    {
        [Key]
        public int idSucursal { get; set; }

        [Required(ErrorMessage = "(A)El nombre de la sucursal es obligatoria.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del nombre es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "(B)La empresa es obligatoria.")]
        [Display(Name = "Empresa")]
        public int? fkEmpresa { get; set; }
        [ForeignKey("fkEmpresa")]
        public Empresa Empresa { get; set; }


        [Required(ErrorMessage = "(C)El teléfono es obligatorio.")]
        [StringLength(10, ErrorMessage = "(C)La longitud máxima del teléfono es 10 caracteres")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(C)Favor de verificar el formato del teléfono.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }


        [Display(Name = "Celular")]
        [Required(ErrorMessage = "(D)El celular es obligatorio.")]
        [StringLength(10, ErrorMessage = "(D)La longitud máxima del celular es 10 caracteres")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(D)Favor de verificar el formato del celular.")]
        public string Celular { get; set; }


        [Display(Name = "Fax")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(E)Favor de verificar el formato del fax.")]
        [StringLength(50, ErrorMessage = "(E)La longitud máxima del fax es 50 caracteres")]
        public string Fax { get; set; }


        [Required(ErrorMessage = "(F)El código postal es obligatorio.")]
        [StringLength(5, ErrorMessage = "(F)La longitud máxima del código postal es 5 caracteres")]
        [RegularExpression(@"^(?:0[1-9]\d{3}|[1-4]\d{4}|5[0-2]\d{3})$", ErrorMessage = "(F)Favor de verificar el formato del código postal")]
        [Display(Name = "Código postal")]
        public string codigoPostal { get; set; }


        [Required(ErrorMessage = "(G)El nombre de la calle es obligatoria.")]
        [StringLength(150, ErrorMessage = "(G)La longitud máxima de la calle es 150 caracteres")]
        [Display(Name = "Calle")]
        public string Calle { get; set; }


        [Required(ErrorMessage = "(H)La colonia es obligatoria.")]
        [StringLength(100, ErrorMessage = "(H)La longitud máxima de la colonia es 100 caracteres")]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        //[Required(ErrorMessage = "(I)El número interior es obligatorio.")]
        [Display(Name = "Número interior")]
        [StringLength(8, ErrorMessage = "(I)La longitud máxima del número interior es 8 caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(I)El número interior solo permite números.")]
        public string numeroInterior { get; set; }


        [Required(ErrorMessage = "(J)El número exterior es obligatorio.")]
        [StringLength(8, ErrorMessage = "(J)La longitud máxima del número exterior es 8 caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(J)El número exterior solo permite números.")]
        [Display(Name = "Número exterior")]
        public string numeroExterior { get; set; }


        [Required(ErrorMessage = "(K)La cardinalidad es obligatoria.")]
        [StringLength(10, ErrorMessage = "(K)La longitud máxima de la cardinalidad es 10 caracteres")]
        [Display(Name = "Cardinalidad")]
        public string Cardinalidad { get; set; }

        [Required(ErrorMessage = "(L)La localización de la empresa es obligatoria.")]
        [Display(Name = "Ciudad")]
        public int? fkCiudad { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }

        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


















    }
}
