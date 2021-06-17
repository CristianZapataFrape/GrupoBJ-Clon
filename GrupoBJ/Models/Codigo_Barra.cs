using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Codigo_Barra
    {
        [Key]
        public int id_Codigo_Barra { get; set; }

        [Required(ErrorMessage = "(B)El nombre del código de barra es obligatorio.")]
        [StringLength(50, ErrorMessage = "(B)La longitud máxima del nombre del código de barra es 50 caracteres")]
        [Display(Name = "Nombre código barra ")]
        public string Nombre_Codigo_Barra{ get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
