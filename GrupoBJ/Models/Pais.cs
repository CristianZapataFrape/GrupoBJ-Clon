using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Pais
    {
        [Key]
        public int idPais { get; set; }


        [Required(ErrorMessage = "(1)El nombre del país es obligatorio.")]
        [StringLength(100, ErrorMessage = "(1)La longitud máxima del país es 100 caracteres")]
        [Display(Name = "País")]
        public string Nombre { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
