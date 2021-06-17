using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Articulos_Campos
    {
        [Key]
        public int idArticulos_Campos { get; set; }

        [Required(ErrorMessage = "(A)El nombre del artículo es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del nombre del articulo es 150 caracteres")]
        [Display(Name = "Artículo Campos")]
        public string Nombre_Articulo_Campos { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
