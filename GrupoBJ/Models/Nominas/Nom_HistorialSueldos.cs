using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_HistorialSueldos
    {
        [Key]
        public int idHistorialSueldo { get; set; }


        [Required(ErrorMessage = "(A)El empleado es obligatorio.")]
        [Display(Name = "Empleado")]
        public int? fkEmpleado { get; set; }
        [ForeignKey("fkEmpleado")]
        public Empleado Empleado { get; set; }


        [Display(Name = "Tipo sueldo")]
        public char? tipoSueldo { get; set; }


        [Display(Name = "Sueldo")]
        public double? sueldo { get; set; }


        [Required(ErrorMessage = "(B)El periodo es obligatorio.")]
        [Display(Name = "Periodo")]
        public int? fkPeriodo { get; set; }
        [ForeignKey("fkPeriodo")]
        public Nom_Periodo Nom_Periodo { get; set; }


        [Required(ErrorMessage = "(C)El tipo de periodo es obligatorio.")]
        [Display(Name = "Tipo de periodo")]
        public int? fkTipoPeriodo { get; set; }
        [ForeignKey("fkTipoPeriodo")]
        public Nom_TipoPeriodo Nom_TipoPeriodo { get; set; }


        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        //public int fkUsuarioUm { get; set; }
        //public DateTime fechaUm { get; set; }

    }
}
