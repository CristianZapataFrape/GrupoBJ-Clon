using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_TipoPeriodo
    {
        [Key]
        public int idTipoPeriodo { get; set; }

        [StringLength(40)]
        public string nombre { get; set; }

        public int diasPeriodo { get; set; }

        public int diaPago { get; set; }

        public int? fkPeriodoActual { get; set; }
        [ForeignKey("fkPeriodoActual")]
        public Nom_Periodo Nom_Periodo { get; set; }

        public bool? ajustarCalendario { get; set; }

        [StringLength(2)]
        public string periocidad { get; set; }

        public int septimosDias { get; set; }
        public int posicionSeptimos { get; set; }
        public int posicionPago { get; set; }
        public int ejercicio { get; set; }

        public bool? ajustarMesCalendario { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }




    }
}
