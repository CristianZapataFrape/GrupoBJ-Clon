using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Imagenes
    {
        [Key]
        public int id_Imagenes { get; set; }

        [Required(ErrorMessage = "(B)El nombre de la imagen es obligatorio.")]
        [StringLength(50, ErrorMessage = "(B)La longitud máxima del nombre de la imagen es 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        /////////////////////////////////////////////////////
        ////////////FALTA EL CAMPO PARA LA IMAGEN////////////
        /////////////////////////////////////////////////////

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
