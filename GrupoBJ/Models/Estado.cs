using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Estado
    {
        [Key]
        public int idEstado { get; set; }


        [Required(ErrorMessage = "El país es obligatorio.")]
        [Display(Name = "País")]
        public int fkPais { get; set; }
        [ForeignKey("fkPais")]
        public Pais Pais { get; set; }


        [Required(ErrorMessage = "(1)El nombre del estado es obligatorio.")]
        [StringLength(100, ErrorMessage = "(1)La longitud máxima del nombre del estado es 100 caracteres")]
        [Display(Name = "Estado")]
        public string Nombre { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
