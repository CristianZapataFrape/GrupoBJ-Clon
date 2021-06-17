using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace GrupoBJ.Models
{
    public class Tabla_Nutrimental_Valores
    {
        [Key]
        public int id_Tabla_Nutrimental_Valores { get; set; }

        public int id_Tabla_Nutrimental_Campos { get; set; }
        [ForeignKey("id_Tabla_Nutrimental_Campos")]
        public Tabla_Nutrimental_Campos Tabla_Nutrimental_Campos { get; set; }

        public int id_Articulos_Nutrimental { get; set; }
        [ForeignKey("id_Articulos_Nutrimental")]
        public Articulos_Nutrimental Articulos_Nutrimental { get; set; }

        [Required(ErrorMessage = "(A)El valor es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del valor es 150 caracteres")]
        [Display(Name = "Valor")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "(B)la unidad es obligatorio.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima de la unidad  150 caracteres")]
        [Display(Name = "Unidad")]
        public string Unidad { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
