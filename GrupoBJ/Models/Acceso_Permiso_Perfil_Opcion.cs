using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Acceso_Permiso_Perfil_Opcion
    {
        [Key]
        public int idPermisoPerfilOpcion { get; set; }


        [Display(Name = "Perfil")]
        public int? fkPerfil { get; set; }
        [ForeignKey("fkPerfil")]
        public Acceso_Perfil Acceso_Perfil { get; set; }


        [Display(Name = "Opción")]
        public int? fkOpcion { get; set; }
        [ForeignKey("fkOpcion")]
        public Acceso_Opcion Acceso_Opcion { get; set; }


        [Display(Name = "Permiso por opción")]
        public int? fkOpcionPermiso { get; set; }
        [ForeignKey("fkOpcionPermiso")]
        public Acceso_Opcion_Permiso Acceso_Opcion_Permiso { get; set; }



        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }



    }
}
