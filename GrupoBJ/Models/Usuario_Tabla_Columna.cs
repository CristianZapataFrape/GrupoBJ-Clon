using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Usuario_Tabla_Columna
    {
        [Key]
        public int idUsuarioTablaColumna { get; set; }


        [Required(ErrorMessage = "(A)El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public int? fkUsuario { get; set; }
        [ForeignKey("fkUsuario")]
        public Usuario Usuario { get; set; }


        [Display(Name = "Tabla")]
        [Required(ErrorMessage = "(B)La tabla es obligatoria.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima de la tabla es 100 caracteres")]
        public string Tabla { get; set; }


        [Display(Name = "Columna")]
        [Required(ErrorMessage = "(C)La columna es obligatoria.")]
        [StringLength(100, ErrorMessage = "(B)La longitud máxima de la columa es 100 caracteres")]
        public string Columna { get; set; }


        [Display(Name = "Ancho")]
        public int? Ancho { get; set; }


        //private bool obligatorio;
        //public bool? Obligatorio
        //{
        //    get { return obligatorio; }
        //    set { obligatorio = value ?? true; }
        //}


        private bool visibilidad;
        public bool? Visibilidad
        {
            get { return visibilidad; }
            set { visibilidad = value ?? true; }
        }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }






    }
}
