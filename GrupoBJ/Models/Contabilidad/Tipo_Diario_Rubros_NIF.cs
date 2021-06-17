using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Tipo_Diario_Rubros_NIF
    {
        [Key]
        public int idTipoDiarioRubrosNIF { get; set; }


        [Required(ErrorMessage = "(A)El rubro NIF es obligatorio.")]
        [Display(Name = "Rubro NIF")]
        public int? fkRubrosNIF { get; set; }
        [ForeignKey("fkRubrosNIF")]
        public Rubros_NIF Rubros_NIF { get; set; }


        [Required(ErrorMessage = "(B)El tipo de diario es obligatorio.")]
        [Display(Name = "Tipo de diario")]
        public int? fkTipoDiario { get; set; }
        [ForeignKey("fkTipoDiario")]
        public Tipo_Diario Tipo_Diario { get; set; }


    }
}
