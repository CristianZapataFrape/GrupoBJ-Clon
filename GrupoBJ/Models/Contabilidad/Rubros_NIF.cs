using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Contabilidad
{
    public class Rubros_NIF
    {
        [Key]
        public int idRubroNIF { get; set; }


        [Required(ErrorMessage = "(A)El código del rubro NIF es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del código del rubro NIF es 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "(B)El nombre del rubro NIF es obligatorio.")]
        [StringLength(200, ErrorMessage = "(B)La longitud máxima del nombre del rubro NIF es 200 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(C)El tipo NIF es obligatorio.")]
        [Display(Name = "Tipo NIF")]
        public int? fkNIFTipo { get; set; }
        [ForeignKey("fkNIFTipo")]
        public NIF_Tipo NIF_Tipo { get; set; }



        [Required(ErrorMessage = "(D)El nivel NIF es obligatorio.")]
        [Display(Name = "Nivel NIF")]
        public int? fkNIFNivel { get; set; }
        [ForeignKey("fkNIFNivel")]
        public NIF_Nivel NIF_Nivel { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
