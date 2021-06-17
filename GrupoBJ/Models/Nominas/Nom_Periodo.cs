using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_Periodo
    {
        [Key]
        public int idPeriodo { get; set; }
        public int numeroPeriodo { get; set; }

        public int? fkTipoPeriodo { get; set; }
        [ForeignKey("fkTipoPeriodo")]
        public Nom_TipoPeriodo Nom_TipoPeriodo { get; set; }

        public int ejercicio { get; set; }
        public int mes { get; set; }
        public float diasPago { get; set; }
        public float septimos { get; set; }
        public bool? calculado { get; set; }
        public bool? afectado { get; set; }

        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }

        public bool? inicioEjercicio { get; set; }
        public bool? inicioMes { get; set; }
        public bool? finMes { get; set; }

        public bool? finEjercicio { get; set; }
        public bool? inicioBimestreImss { get; set; }
        public bool? finBimestreImss { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }

    }
}
