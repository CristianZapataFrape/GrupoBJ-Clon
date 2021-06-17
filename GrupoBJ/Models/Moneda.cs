using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Moneda
    {
        [Key]
        public int idMoneda { get; set; }


        [Required(ErrorMessage = "(A)El código de la moneda es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del código de la moneda es 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre de la moneda es obligatorio.")]
        [StringLength(50, ErrorMessage = "(B)La longitud máxima del nombre de la moneda es 50 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)El símbolo es obligatorio.")]
        [StringLength(3, ErrorMessage = "(C)La longitud máxima del símbolo es 3 caracteres")]
        [Display(Name = "Símbolo")]
        public string Simbolo { get; set; }

        
        [Required(ErrorMessage = "(D)La posición del símbolo es obligatorio.")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "(D)La posición del símbolo es obligatorio.")]
        [Display(Name = "Posición")]
        public int Posicion { get; set; }


        [Required(ErrorMessage = "(E)Los dígitos decimales son obligatorios.")]
        [Display(Name = "Decimales")]
        public string Decimales { get; set; }


        [Required(ErrorMessage = "(F)El nombre singular es obligatorio.")]
        [StringLength(30, ErrorMessage = "(3)La longitud máxima del nombre singular es 30 caracteres")]
        [Display(Name = "Nombre en singular")]
        public string nombreSingular { get; set; }


        [Required(ErrorMessage = "(G)El nombre plural es obligatorio.")]
        [StringLength(30, ErrorMessage = "(G)La longitud máxima del nombre plural es 30 caracteres")]
        [Display(Name = "Nombre en plural")]
        public string nombrePlural { get; set; }


        [Required(ErrorMessage = "(H)El texto al final del importe es obligatorio.")]
        [StringLength(30, ErrorMessage = "(H)La longitud máxima del texto al final del importe es 30 caracteres")]
        [Display(Name = "Texto al final del importe")]
        public string textoFinal { get; set; }


        [Required(ErrorMessage = "(I)El código de moneda del SAT es obligatorio.")]
        [Display(Name = "Código de moneda en SAT")]
        public int? fkMonedaSAT { get; set; }
        [ForeignKey("fkMonedaSAT")]
        public MonedaSAT MonedaSAT { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
