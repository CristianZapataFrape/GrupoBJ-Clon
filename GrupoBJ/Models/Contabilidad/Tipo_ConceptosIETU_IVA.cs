using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Tipo_ConceptosIETU_IVA
    {
        [Key]
        public int idTipoConceptoIETU_IVA { get; set; }

        [Required(ErrorMessage = "(A)El código  es obligatorio.")]
        [StringLength(5, ErrorMessage = "(A)La longitud máxima del código es 5 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "(B)El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima del nombre es 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)El tipo de concepto IETU es obligatorio.")]
        [Display(Name = "Tipo de concepto IETU")]
        public int? fkTipoConceptoIETU { get; set; }
        [ForeignKey("fkTipoConceptoIETU")]
        public Tipo_ConceptosIETU Tipo_ConceptosIETU { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
        public bool Habilitado { get; set; }


    }
}
