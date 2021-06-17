using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_RegistroPatronal
    {
        [Key]
        public int idRegistroPatronal { get; set; }

        [StringLength(13)]
        public string rfc { get; set; }
        public DateTime fechaConstitucion { get; set; }

        [StringLength(13)]
        public string registroImss { get; set; }
        public int claseRiesgoTrabajo { get; set; }
        public int fraccionRiesgoTrabajo { get; set; }

        public int? fkCiudadRegistroPatronal { get; set; }
        [ForeignKey("fkCiudadRegistroPatronal")]
        public Ciudad Ciudad { get; set; }
        public int codigoPostal { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
