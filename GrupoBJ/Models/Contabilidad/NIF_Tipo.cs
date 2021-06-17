using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class NIF_Tipo
    {
        [Key]
        public int idNIFTipo { get; set; }


        [Required(ErrorMessage = "(A)El tipo NIF es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del código del tipo NIF es 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre del tipo NIF es obligatorio.")]
        [StringLength(200, ErrorMessage = "(B)La longitud máxima del nombre del tipo NIF es 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
