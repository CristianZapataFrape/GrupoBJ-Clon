using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Departamento
    {
        [Key]
        public int idDepartamento { get; set; }


        [Required(ErrorMessage = "(A)El nombre del departamento es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del departamento es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(B)La empresa es obligatoria.")]
        [Display(Name = "Empresa")]
        public int? fkEmpresa { get; set; }
        [ForeignKey("fkEmpresa")]
        public Empresa Empresa { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
