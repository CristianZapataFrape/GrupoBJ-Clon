using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Tabla_Nutrimental_Campos_Tipos
    {

        [Key]
        public int id_Tabla_Nutrimental_Campos_Tipos { get; set; }

        [Required(ErrorMessage = "(A)El nombre del tipo de campo de la tabla nutrimental es obligatorio.")]
        [StringLength(50, ErrorMessage = "(A)La longitud máxima del nombre del campo de la tabla nutrimental es 50 caracteres")]
        [Display(Name = "Nombre tabla nutrimental campos")]
        public string Nombre_Tabla_Nutrimental_Campos_Tipos { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
