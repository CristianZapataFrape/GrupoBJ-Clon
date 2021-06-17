using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Acceso_Permiso
    {
        [Key]
        public int idPermiso { get; set; }

        [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public string Clave { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
