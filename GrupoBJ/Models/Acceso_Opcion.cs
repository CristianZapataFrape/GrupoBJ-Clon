using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Acceso_Opcion
    {
        [Key]
        public int idOpcion { get; set; }


        [Required(ErrorMessage = "(A)El sistema es obligatorio.")]
        [Display(Name = "Sistema")]
        public int? fkSistema { get; set; }
        [ForeignKey("fkSistema")]
        public Acceso_Sistema Acceso_Sistema { get; set; }


        [Required(ErrorMessage = "(B)El nombre de la opción es obligatoria.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima del nombre de la opción es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Display(Name = "Opción padre")]
        public int idOpcionPadre { get; set; }


        [Display(Name = "Posición")]
        public int? Posicion { get; set; }


        [Required(ErrorMessage = "(E)El tipo es obligatorio.")]
        [Display(Name = "Tipo")]
        public int? fkTipoArchivo { get; set; }
        [ForeignKey("fkTipoArchivo")]
        public Acceso_Tipo_Archivo Acceso_Tipo_Archivo { get; set; }

        [StringLength(150, ErrorMessage = "(F)La longitud máxima del nombre del controlador es 150 caracteres")]
        [Display(Name = "Controlador")]
        public string? Controlador { get; set; }


        [Display(Name = "Tipo de sistema")]
        public int? tipoSistema { get; set; }

        public string? nombrePadre { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }











    }
}
