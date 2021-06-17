using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Horario
    {
        [Key]
        public int idHorario { get; set; }


        [Required(ErrorMessage = "(A)El nombre del horario es obligatorio.")]
        [StringLength(100, ErrorMessage = "(A)La longitud máxima del nombre del horario es 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
