using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Tipo_Cuenta
    {
        [Key]
        public int idTipoCuenta { get; set; }

        [Required(ErrorMessage = "(A)El nombre del tipo de cuenta es obligatorio.")]
        [StringLength(100, ErrorMessage = "(A)La longitud máxima del nombre del tipo NIF es 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "(B)El nombre del tipo es obligatorio.")]
        [Display(Name = "Tipo")]
        public int Tipo { get; set; }


        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
