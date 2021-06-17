using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Carateristicas_Valores
    {
        [Key]
        public int id_Carateristica_Valores{ get; set; }
        public int id_Cararteristica { get; set; }
        [ForeignKey("id_Cararteristica")]
        public Carateristicas Carateristicas { get; set; }

        [Required(ErrorMessage = "(A)El valor es obligatorio.")]
        [StringLength(35, ErrorMessage = "(A)La longitud máxima del valor de carateristica es 35 caracteres")]
        [Display(Name = "Valor")]
        public string Valor { get; set; }
        public bool Venta { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }     
        public DateTime fechaUm { get; set; }
    }
}
