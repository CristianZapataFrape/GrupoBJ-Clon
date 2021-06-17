using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Articulos_Carateristicas
    {
        [Key]
        public int id_Articulos_Carateristicas { get; set; }

        public int id_Cararteristica { get; set; }
        [ForeignKey("id_Cararteristica")]
        public Carateristicas Carateristicas { get; set; }

        public int id_Carateristica_Valores { get; set; }
        [ForeignKey("id_Carateristica_Valores")]
        public Carateristicas_Valores Carateristica_Valores { get; set; }

        public int id_Articulos { get; set; }
        [ForeignKey("id_Articulos")]
        public Articulos Articulos { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
