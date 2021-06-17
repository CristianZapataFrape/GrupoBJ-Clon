using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Usuario_Empresa_Sucursal_Sis_Per
    {
        [Key]
        public int idUsuEmpSucSisPer { get; set; }

        [Display(Name = "Usuario")]
        public int? fkUsuario { get; set; }
        [ForeignKey("fkUsuario")]
        public Usuario Usuario { get; set; }


        [Display(Name = "Empresa")]
        public int? fkEmpresa { get; set; }
        [ForeignKey("fkEmpresa")]
        public Empresa Empresa { get; set; }


        [Display(Name = "Sucursal")]
        public int? fkSucursal { get; set; }
        [ForeignKey("fkSucursal")]
        public Sucursal Sucursal { get; set; }


        [Display(Name = "Sistema")]
        public int? fkSistema { get; set; }
        [ForeignKey("fkSistema")]
        public Acceso_Sistema Acceso_Sistema { get; set; }


        [Display(Name = "Perfil")]
        public int? fkPerfil { get; set; }
        [ForeignKey("fkPerfil")]
        public Acceso_Perfil Acceso_Perfil { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }
    }
}
