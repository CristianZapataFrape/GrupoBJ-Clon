using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Acceso_Opcion_Permiso
    {
        [Key]
        public int idOpcionPermiso{ get; set; }

        [Display(Name = "Opción")]
        public int? fkOpcion { get; set; }
        [ForeignKey("fkOpcion")]
        public Acceso_Opcion Acceso_Opcion { get; set; }


        [Display(Name = "Permiso")]
        public int? fkPermiso { get; set; }
        [ForeignKey("fkPermiso")]
        public Acceso_Permiso Acceso_Permiso { get; set; }


        [Display(Name = "Clase")]
        public string Clase { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }

        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
