using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Diarios_Especiales_Rubros_NIF
    {
        [Key]
        public int idDiariosEspecialesRubrosNIF { get; set; }


        [Required(ErrorMessage = "(A)El rubro NIF es obligatorio.")]
        [Display(Name = "Rubro NIF")]
        public int? fkRubrosNIF { get; set; }
        [ForeignKey("fkRubrosNIF")]
        public Rubros_NIF Rubros_NIF { get; set; }



        [Required(ErrorMessage = "(B)El diario especial es obligatorio.")]
        [Display(Name = "Diario especial")]
        public int? fkDiariosEspeciales { get; set; }
        [ForeignKey("fkDiariosEspeciales")]
        public Diarios_Especiales Diarios_Especiales { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
