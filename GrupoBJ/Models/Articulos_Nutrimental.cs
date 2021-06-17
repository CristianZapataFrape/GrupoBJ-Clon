using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Articulos_Nutrimental
    {
        [Key]
        public int id_Articulos_Nutrimental { get; set; }

        public int id_Tabla_Nutrimental { get; set; }
        [ForeignKey("id_Tabla_Nutrimental")]
        public Tabla_Nutrimental Tabla_Nutrimental { get; set; }

        public int id_Articulos { get; set; }
        [ForeignKey("id_Articulos")]
        public Articulos Articulos { get; set; }

        public string Caracteristicas { get; set; }
        public string Presentacion { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }

    }
}
