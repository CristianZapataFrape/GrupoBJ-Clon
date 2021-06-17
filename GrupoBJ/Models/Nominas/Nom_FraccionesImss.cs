using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_FraccionesImss
    {
        [Key]
        public int idFraccionesImss { get; set; }

        [Required(ErrorMessage = "(A)El código de la fracción es obligatorio.")]
        [StringLength(5, ErrorMessage = "(A)La longitud máxima del código de la fracción es 5 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)La descripción es obligatoria.")]
        [StringLength(200, ErrorMessage = "(B)La longitud máxima de la descripción es 200 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "(C)La clase es obligatoria.")]
        [StringLength(2, ErrorMessage = "(C)La longitud máxima de la clase es 2 caracteres")]
        [Display(Name = "Clase")]
        public string Clase { get; set; }



    }
}
