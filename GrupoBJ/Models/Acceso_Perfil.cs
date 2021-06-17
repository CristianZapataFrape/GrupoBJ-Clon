using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Acceso_Perfil
    {
        [Key]
        public int idPerfil { get; set; }


        [Required(ErrorMessage = "(B)El nombre del perfil es obligatorio.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima del nombre del perfil es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }



        [Required(ErrorMessage = "(A)El sistema es obligatorio.")]
        [Display(Name = "Sistema")]
        public int? fkSistema { get; set; }
        [ForeignKey("fkSistema")]
        public Acceso_Sistema Acceso_Sistema { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }

        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
