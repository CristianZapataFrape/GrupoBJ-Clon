using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GrupoBJ.Models
{
    public class Unidades_Medida
    {
        [Key]
        public int id_Unidades_Medida { get; set; }

        [Required(ErrorMessage = "(B)El nombre de la unidad de medida es obligatorio.")]
        [StringLength(50, ErrorMessage = "(B)La longitud máxima del nombre de la unidad de medida es 50 caracteres")]
        [Display(Name = "Nombre unidad medida")]
        public string Nombre_Unidad_Medida { get; set; }

        [Required(ErrorMessage = "(B)La abreviatura es obligatorio.")]
        [StringLength(5, ErrorMessage = "(B)La longitud máxima de la abreviatura es 5 caracteres")]
        [Display(Name = "Nombre unidad medida")]
        public string Abreviatura { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
