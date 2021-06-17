using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Acceso_Sistema
    {
        [Key]
        public int idSistema { get; set; }


        [Required(ErrorMessage = "(A)La empresa es obligatoria.")]
        [Display(Name = "Empresa")]
        public int? fkEmpresa { get; set; }
        [ForeignKey("fkEmpresa")]
        public Empresa Empresa { get; set; }



        [Required(ErrorMessage = "(B)El nombre del sistema es obligatorio.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima del nombre del sistema es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }

        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
