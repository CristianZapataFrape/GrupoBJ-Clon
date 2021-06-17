using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "(A)El nombre es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del nombre es 150 caracteres")]
        [Display(Name = "Usuario")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(B)El usuario es obligatorio.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima del usuario es 150 caracteres")]
        [Display(Name = "Usuario")]
        public string nombreUsuario { get; set; }


        [Required(ErrorMessage = "(C)La contraseña es obligatoria.")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }


        [StringLength(150, ErrorMessage = "(D)La longitud máxima del correo electrónico es 150 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.([a-zA-Z]{2,4})+$", ErrorMessage = "(D)Favor de verificar el formato del correo electrónico.")]
        [Display(Name = "Correo electrónico")]
        public string correoElectronico { get; set; }

        private bool nuncacaduca;
        public bool? nuncaCaduca
        {
            get { return nuncacaduca; }
            set { nuncacaduca = value ?? true; }
        }


        private bool menuproduccion;
        public bool? menuProduccion
        {
            get { return menuproduccion; }
            set { menuproduccion = value ?? true; }
        }

        [Display(Name = "Fecha de caducidad")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? fechaCaducidad { get; set; }


        [Display(Name = "Fotografia")]
        public string imagePath { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }

        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
