using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Cuentas
    {
        [Key]
        public int idCuenta { get; set; }


        [Required(ErrorMessage = "(A)El código de la cuenta es obligatorio.")]
        [StringLength(50, ErrorMessage = "(A)La longitud máxima del codigo de la cuenta es 50 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre de la cuenta es obligatoria.")]
        [StringLength(200, ErrorMessage = "(B)La longitud máxima del nombre de la cuenta es 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)La clasificación es obligatoria.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "(C)La clasificación es obligatoria.")]
        [Display(Name = "Clasificación")]
        public int Clasificacion { get; set; }


        [Required(ErrorMessage = "(D)La naturaleza es obligatoria.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "(D)La naturaleza es obligatoria.")]
        [Display(Name = "Naturaleza")]
        public int Naturaleza { get; set; }


        [Required(ErrorMessage = "(E)La cuenta de mayor obligatoria.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "(E)La cuenta de mayor obligatoria.")]
        [Display(Name = "Cuenta mayor")]
        public int ctaMayor { get; set; }


        [Required(ErrorMessage = "(F)La subcuenta es obligatoria.")]
        [Display(Name = "Subcuenta")]
        public int Subcuenta { get; set; }


        [Required(ErrorMessage = "(G)El agrupador SAT es obligatorio.")]
        [Display(Name = "Agrupador SAT")]
        public int? fkAgrupadoresSAT { get; set; }
        [ForeignKey("fkAgrupadoresSAT")]
        public Agrupadores_SAT Agrupadores_SAT { get; set; }


        [Required(ErrorMessage = "(H)El tipo de cuenta es obligatoria.")]
        [Display(Name = "Tipo de cuenta")]
        public int? fkTipoCuenta { get; set; }
        [ForeignKey("fkTipoCuenta")]
        public Tipo_Cuenta Tipo_Cuenta { get; set; }


        [Display(Name = "Nivel")]
        public int? Nivel { get; set; }


        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
