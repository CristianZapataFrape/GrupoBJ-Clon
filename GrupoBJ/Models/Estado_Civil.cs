using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Estado_Civil
    {
        [Key]
        public int idEstadoCivil { get; set; }


        [Required(ErrorMessage = "(A)El estado civil es obligatorio.")]
        [StringLength(100, ErrorMessage = "(A)La longitud máxima del estado civil es 100 caracteres")]
        [Display(Name = "Estado civil")]
        public string Nombre { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
