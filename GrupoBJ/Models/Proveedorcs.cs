using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Proveedorcs
    {
        [Key]
        public int id_Proveedor { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es un campo obligatorio")]
        [StringLength(100, ErrorMessage = "Longitud maxima de 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido paterno del proveedor es un campo obligatorio")]
        [StringLength(100, ErrorMessage = "Longitud maxima de 50 caracteres")]
        public string ApPaterno { get; set; }

        [Required(ErrorMessage = "El apellido materno del proveedor es un campo obligatorio")]
        [StringLength(100, ErrorMessage = "Longitud maxima de 50 caracteres")]
        public string ApMaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Codigo_Postal { get; set; }
        public string Razon_Social { get; set; }
        public string RFC { get; set; }
        public string Cuenta { get; set; }
        public string Tiempo_Entrega { get; set; }
        public bool? Habilitado { get; set; }
        public DateTime FechaCr { get; set; }
    }
}
