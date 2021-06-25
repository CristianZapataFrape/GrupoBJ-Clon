using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class ClienteCls
    {
        [Key]
        
        [Display(Name = "Código")]
        public int codigo { get; set; }

     //   [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

      //  [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Apellido paterno")]
        public string apPaterno { get; set; }

       // [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Apellido materno")]
        public string apMaterno { get; set; }

     //   [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Email")]
        public string email { get; set; }


      //  [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }


      //  [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Pais")]
        public string pais { get; set; }

       // [Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Nombre copañia")]

        public string nombreCompania { get; set; }

        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Código postal")]

        public string CP { get; set; }

        //[Required(ErrorMessage = "(A)El nombre del permiso es obligatorio.")]
        [StringLength(150, ErrorMessage = "(A)La longitud máxima del permiso es 150 caracteres")]
        [Display(Name = "Telefono")]

        public string telefono { get; set; }


        public bool? Habilitado { get; set; }


        public DateTime FechaCr { get; set; }
    }
}
