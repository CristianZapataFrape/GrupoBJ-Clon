using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class ConceptosIETU
    {
        [Key]
        public int idConceptoIETU { get; set; }


        [Required(ErrorMessage = "(A)El código  es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del código es 5 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima del nombre es 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)El tipo de flujo es obligatorio.")]
        [Display(Name = "Tipo de flujo")]
        public int? fkTipoFlujo { get; set; }
        [ForeignKey("fkTipoFlujo")]
        public Tipo_ConceptosIETU Tipo_ConceptosIETU { get; set; }


        [Required(ErrorMessage = "(D)El tipo de concepto IVA es obligatorio.")]
        [Display(Name = "Tipo de concepto IVA")]
        public int? fkTipoIVA { get; set; }
        [ForeignKey("fkTipoIVA")]
        public Tipo_ConceptosIETU_IVA Tipo_ConceptosIETU_IVA { get; set; }


        [Required(ErrorMessage = "(E)El tipo de concepto IETU es obligatorio.")]
        [Display(Name = "Tipo de concepto IETU")]
        public int? fkTipoIETU { get; set; }
        [ForeignKey("fkTipoIETU")]
        public Tipo_ConceptosIETU_IETU Tipo_ConceptosIETU_IETU { get; set; }



       


        [StringLength(6, ErrorMessage = "(F)La longitud máxima del tipo es 6 caracteres")]
        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
        public bool Habilitado { get; set; }
    }
}
