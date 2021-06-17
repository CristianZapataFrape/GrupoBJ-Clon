using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Turnos
    {
        [Key]
        public int idTurno { get; set; }
        public int numeroTurno { get; set; }

        [StringLength(40)]
        public string nombre { get; set; }
        public float horas { get; set; }

        [StringLength(2)]
        public string tipoJornadas { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
