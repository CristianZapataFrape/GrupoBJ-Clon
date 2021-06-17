using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Ciudad
    {
        [Key]
        public int idCiudad { get; set; }


        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Display(Name = "Estado")]
        public int fkEstado { get; set; }
        [ForeignKey("fkEstado")]
        public Estado Estado { get; set; }


        [Required(ErrorMessage = "(1)El nombre de la ciudad es obligatorio.")]
        [StringLength(100, ErrorMessage = "(1)La longitud máxima del nombre de la ciudad es 100 caracteres")]
        [Display(Name = "Ciudad")]
        public string Nombre { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
