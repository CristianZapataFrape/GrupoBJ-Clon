using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_ControlVacaciones
    {
        [Key]
        public int idControlVacaciones { get; set; }


        [Required(ErrorMessage = "(A)El empleado es obligatorio.")]
        [Display(Name = "Empleado")]
        public int? fkEmpleado { get; set; }
        [ForeignKey("fkEmpleado")]
        public Empleado Empleado { get; set; }


        [Display(Name = "Ejercicio")]
        public int? Ejercicio { get; set; }


        [Display(Name = "Días vacaciones")]
        public int? diasVacaciones { get; set; }


        [Display(Name = "Días prima vacacional")]
        public double? diasPrimaVacacional { get; set; }


        [Display(Name = "Fecha inicio")]
        public DateTime? fechaInicio { get; set; }


        [Display(Name = "Fecha fin")]
        public DateTime? fechaFin { get; set; }


        [Display(Name = "Días descanso")]
        public int? diasDescanso { get; set; }


        [Display(Name = "Fecha pago")]
        public DateTime? fechaPago { get; set; }


        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }










    }
}
