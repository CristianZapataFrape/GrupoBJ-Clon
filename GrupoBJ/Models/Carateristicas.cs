using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Carateristicas
    {
        [Key]
        public int id_Cararteristica { get; set; }

        [Required(ErrorMessage = "(A)El nombre de la carateristica es obligatorio.")]
        [StringLength(35, ErrorMessage = "(A)La longitud máxima del nombre de la carateristica es 35 caracteres")]
        [Display(Name = "Nombre carateristica")]
        public string Nombre_Carateristica { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        [ForeignKey("fkUsuarioUm")]
        public Usuario Usuario { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
