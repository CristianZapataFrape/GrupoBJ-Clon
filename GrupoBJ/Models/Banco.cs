using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Banco
    {
        [Key]
        public int idBanco { get; set; }

        [Required(ErrorMessage = "(A)El código del banco es obligatorio.")]
        [StringLength(3, ErrorMessage = "(A)La longitud máxima del código del banco es 3 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "(B)El nombre del banco es obligatorio.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima del nombre del banco es 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "(C)La clave del banco es obligatorio.")]
        [StringLength(3, ErrorMessage = "(C)La longitud máxima de la clave del banco es 3 caracteres")]
        [Display(Name = "Clave")]
        public string Clave { get; set; }

        [StringLength(250, ErrorMessage = "(D)La longitud máxima de la página web es 250 caracteres")]
        [Display(Name = "Página web")]
        public string paginaWeb { get; set; }


        private bool esbancoextranjero;
        public bool? esBancoExtranjero
        {
            get { return esbancoextranjero; }
            set { esbancoextranjero = value ?? true; }
        }

        [StringLength(13, ErrorMessage = "(E)La longitud máxima del RFC es 13 caracteres")]
        [RegularExpression(@"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$", ErrorMessage = "(E)El RFC es inválido")]
        [Display(Name = "RFC")]
        public string RFC { get; set; }



        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }

        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
