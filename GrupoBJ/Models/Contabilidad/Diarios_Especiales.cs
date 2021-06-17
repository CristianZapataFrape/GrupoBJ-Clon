using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Diarios_Especiales
    {
        [Key]
        public int idDiariosEspeciales { get; set; }


        [Required(ErrorMessage = "(A)El código del diario especial es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del código del diario especial es 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre del diario especial es obligatorio.")]
        [StringLength(200, ErrorMessage = "(B)La longitud máxima del nombre del diario especial es 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)El tipo de diario es obligatorio.")]
        [Display(Name = "Tipo de diario")]
        public int? fkTipoDiario { get; set; }
        [ForeignKey("fkTipoDiario")]
        public Tipo_Diario Tipo_Diario { get; set; }

        public bool Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }



    }
}
