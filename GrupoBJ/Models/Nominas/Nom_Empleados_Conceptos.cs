using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_Empleados_Conceptos
    {
        [Key]
        public int idEmpleadosConceptos { get; set; }

        [Required(ErrorMessage = "(A)El empleado es obligatorio.")]
        [Display(Name = "Empleado")]
        public int? fkEmpleado { get; set; }
        [ForeignKey("fkEmpleado")]
        public Empleado Empleado { get; set; }


        [Required(ErrorMessage = "(B)El concepto es obligatorio.")]
        [Display(Name = "Concepto")]
        public int? fkConcepto { get; set; }
        [ForeignKey("fkConcepto")]
        public Nom_Conceptos Nom_Conceptos { get; set; }


        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }

    }
}
