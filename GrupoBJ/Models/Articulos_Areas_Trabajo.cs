using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Articulos_Areas_Trabajo
    {
        [Key]
        public int id_Articulos_Areas_Trabajo { get; set; }

        public int id_Articulos { get; set; }
        [ForeignKey("id_Articulos")]
        public Articulos Articulos { get; set; }

        public int id_Areas_Trabajo { get; set; }
        [ForeignKey("id_Areas_Trabajo")]
        public Areas_Trabajo Areas_Trabajo { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
    }
}
