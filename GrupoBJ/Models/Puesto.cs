using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Puesto
    {
        [Key]
        public int idPuesto { get; set; }

        [Required(ErrorMessage = "(A)El nombre del puesto es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del nombre es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(B)El departamento es obligatorio.")]
        [Display(Name = "Departamento")]
        public int? fkDepartamento { get; set; }
        [ForeignKey("fkDepartamento")]
        public Departamento Departamento { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
