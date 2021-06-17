using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Agrupadores_SAT
    {
        [Key]
        public int idAgrupadorSAT { get; set; }


        [Required(ErrorMessage = "(A)El código del agrupador SAT es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del agrupador SAT es 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre del agrupador SAT es obligatorio.")]
        [StringLength(200, ErrorMessage = "(B)La longitud máxima del nombre del agrupador SAT es 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)El tipo es obligatorio.")]
        [StringLength(1, ErrorMessage = "(C)La longitud máxima del tipo es 1 caracteres")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "(D)La cuenta mayor es obligatorio.")]
        [Display(Name = "Cuenta mayor")]
        public int ctaMayor { get; set; }

        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
