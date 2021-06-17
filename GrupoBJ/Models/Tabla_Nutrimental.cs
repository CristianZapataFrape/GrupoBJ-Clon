using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Tabla_Nutrimental
    {
        [Key]
        public int id_Tabla_Nutrimental { get; set; }

        public int id_Carateristica_Valores { get; set; }
        [ForeignKey("id_Carateristica_Valores")]
        public Carateristicas_Valores Carateristica_Valores { get; set; }

        [Required(ErrorMessage = "(A)El nombre de la tabla nutrimental es obligatorio.")]
        [StringLength(50, ErrorMessage = "(A)La longitud máxima del nombre de la tabla nutrimental es 50 caracteres")]
        [Display(Name = "Nombre tabla nutrimental")]
        public string Nombre_Tabla_Nutrimental { get; set; }

        public bool Activo { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }




    }
}


