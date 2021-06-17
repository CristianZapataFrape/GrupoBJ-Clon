using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Tipo_Diario
    {
        [Key]
        public int idTipoDiario { get; set; }


        [Required(ErrorMessage = "(A)El código del diario es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del código del diario es 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre del tipo de diario es obligatorio.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima del nombre del tipo de diario es 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public bool Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
