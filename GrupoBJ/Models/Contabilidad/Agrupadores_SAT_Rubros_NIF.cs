using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Agrupadores_SAT_Rubros_NIF
    {
        [Key]
        public int idAgrupadoresSATRubrosNIF { get; set; }


        [Required(ErrorMessage = "(A)El agrupador SAT es obligatorio.")]
        [Display(Name = "Agrupador SAT")]
        public int? fkAgrupadoresSAT { get; set; }
        [ForeignKey("fkAgrupadoresSAT")]
        public Agrupadores_SAT Agrupadores_SAT { get; set; }



        [Required(ErrorMessage = "(B)El rubro NIF es obligatorio.")]
        [Display(Name = "Rubro NIF")]
        public int? fkRubrosNIF { get; set; }
        [ForeignKey("fkRubrosNIF")]
        public Rubros_NIF Rubros_NIF { get; set; }

        
    }
}
