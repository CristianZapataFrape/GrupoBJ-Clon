using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Articulos_Campos_Vista
    {

        [Key]
        public int idArticulos_Campos { get; set; }
        public string Nombre_Articulo_Campos { get; set; }
        public string fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public string fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
