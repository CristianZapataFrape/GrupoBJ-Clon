using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Empresa
    {
        [Key]
        public int idEmpresa { get; set; }

        [Required(ErrorMessage ="(A)El nombre de la empresa es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del nombre es 150 caracteres")]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "(B)La razón social es obligatoria.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima de la razón social es 100 caracteres")]
        [Display(Name = "Razón social")]
        public string razonSocial { get; set; }

        [Required(ErrorMessage = "(C)El RFC es obligatorio.")]
        [StringLength(13, ErrorMessage = "(C)La longitud máxima del RFC es 13 caracteres")]
        [RegularExpression(@"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$", ErrorMessage = "(C)El RFC es inválido")]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "(D)El tipo de moneda es obligatorio.")]
        public int? fkMoneda { get; set; }


        [Required(ErrorMessage = "(E)El teléfono es obligatorio.")]
        [StringLength(10, ErrorMessage = "(E)La longitud máxima del teléfono es 10 caracteres")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(E)Favor de verificar el formato del teléfono.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "(F)El celular es obligatorio.")]
        [StringLength(10, ErrorMessage = "(F)La longitud máxima del celular es 10 caracteres")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(F)Favor de verificar el formato del celular.")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(G)Favor de verificar el formato del fax.")]
        [StringLength(50, ErrorMessage = "(G)La longitud máxima del fax es 50 caracteres")]
        [Display(Name = "Fax")]
        public string Fax { get; set; }


        [Required(ErrorMessage = "(H)El código postal es obligatorio.")]
        [StringLength(5, ErrorMessage = "(H)La longitud máxima del código postal es 5 caracteres")]
        [RegularExpression(@"^(?:0[1-9]\d{3}|[1-4]\d{4}|5[0-2]\d{3})$", ErrorMessage = "(H)Favor de verificar el formato del código postal.")]
        [Display(Name = "Código Postal")]
        public string codigoPostal { get; set; }

        [Required(ErrorMessage = "(I)La calle es obligatoria.")]
        [StringLength(150, ErrorMessage = "(I)La longitud máxima de la calle es 150 caracteres")]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "(J)La colonia es obligatoria.")]
        [StringLength(100, ErrorMessage = "(J)La longitud máxima de la colonia es 100 caracteres")]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        //[Required(ErrorMessage = "(K)El número interior es obligatorio.")]
        [StringLength(8, ErrorMessage = "(K)La longitud máxima del número interior es 8 caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(K)El número interior solo permite números.")]
        [Display(Name = "Número interior")]
        public string numeroInterior { get; set; }

        [Required(ErrorMessage = "(L)El número exterior es obligatorio.")]
        [StringLength(8, ErrorMessage = "(L)La longitud máxima del número exterior es 8 caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(L)El número exterior solo permite números.")]
        [Display(Name = "Número exterior")]
        public string numeroExterior { get; set; }

        [Display(Name = "Cardinalidad")]
        [StringLength(10, ErrorMessage = "(M)La longitud máxima de la cardinalidad es 10 caracteres")]
        public string Cardinalidad { get; set; }

        //Nuevas modificaciones
        [Required(ErrorMessage = "(N)La localización de la empresa es obligatoria.")]
        [Display(Name = "Ciudad")]
        public int? fkCiudad { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }





    }
}
