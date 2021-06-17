using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class MonedaSAT
    {
        [Key]
        public int idMonedaSAT { get; set; }

        [Required(ErrorMessage = "(1)El código es obligatorio.")]
        [StringLength(3, ErrorMessage = "(1)La longitud máxima del código es 3 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
