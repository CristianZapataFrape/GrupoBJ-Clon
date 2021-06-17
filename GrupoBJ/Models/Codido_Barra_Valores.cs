using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Codido_Barra_Valores
    {
        [Key]
        public int id_Codido_Barra_Valores { get; set; }

        public int id_Codigo_Barra { get; set; }
        [ForeignKey("id_Codigo_Barra")]
        public Codigo_Barra Codigo_Barra { get; set; }

        public int id_Articulos { get; set; }
        [ForeignKey("id_Articulos")]
        public Articulos Articulos { get; set; }

        [Required(ErrorMessage = "(A)El valor es obligatorio.")]
        [StringLength(15, ErrorMessage = "(A)La longitud máxima del valor de codigo de barra es 15 caracteres")]
        [Display(Name = "Valor")]
        public string Valor { get; set; }

    }
}
