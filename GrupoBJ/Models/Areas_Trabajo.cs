using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrupoBJ.Models
{
    public class Areas_Trabajo
    {
        [Key]
        public int id_Areas_Trabajo { get; set; }

        public int idEmpresa { get; set; }
        [ForeignKey("idEmpresa")]
        public Empresa Empresa { get; set; }

        public int idHorario { get; set; }
        [ForeignKey("idHorario")]
        public Horario Horario { get; set; }        

        [Required(ErrorMessage = "(B)El nombre de la área de trabajo es obligatorio.")]
        [StringLength(150, ErrorMessage = "(B)La longitud máxima del nombre de la área de trabajo es 150 caracteres")]
        [Display(Name = "Nombre área trabajo")]
        public string Nombre_Area_Trabajo { get; set; }

        //public int Id_Concepto_Salida_Cpc { get; set; }
        public int Transferencias_Por_Articulo { get; set; }

        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }


    }
}
