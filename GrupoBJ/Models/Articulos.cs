using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Articulos
    {
        [Key]
        public int id_Articulos { get; set; }

        [Required(ErrorMessage = "(A)El ID del artículo es obligatorio.")]
        [StringLength(20, ErrorMessage = "(A)La longitud máxima del ID es 20 caracteres")]
        [Display(Name = "ID")]
        public string id_Articulo { get; set; }

        [Required(ErrorMessage = "(B)El nombre del artículo es obligatorio.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima del nombre del articulo es 150 caracteres")]
        [Display(Name = "Nombre artículo")]
        public string Nombre_Articulo { get; set; }

        [Required(ErrorMessage = "(C)El costo estandar del artículo es obligatorio.")]
        [Display(Name = "Costo estandar")]
        public double Costo_Estandar { get; set; }

        //[Required(ErrorMessage = "(D)El costo estandar del artículo es obligatorio.")]
        [Display(Name = "Producto venta")]
        public bool Producto_Venta { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; }

        public int fkUsuarioCr { get; set; }
    
        public DateTime fechaCr { get; set; }

        public int fkUsuarioUm { get; set; }
        [ForeignKey("fkUsuarioUm")]
        public Usuario Usuario { get; set; }


        public DateTime fechaUm { get; set; }


      

    }
}
