using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Articulos_Valores
    {
        [Key]
        public int idArticulos_Valores { get; set; }

        public int idArticulos_Campos { get; set; }
        [ForeignKey("idArticulos_Campos")]
        public Articulos_Campos Articulos_Campos { get; set; }

        public int id_Articulos { get; set; }
        [ForeignKey("id_Articulos")]
        public Articulos Articulos { get; set; }

        [Required(ErrorMessage = "(A)El valor es obligatorio.")]
        [StringLength(35, ErrorMessage = "(A)La longitud máxima del valor del articulo es 35 caracteres")]
        [Display(Name = "Valor")]
        public string Valor { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
