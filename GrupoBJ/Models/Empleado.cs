using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Empleado
    {
        [Key]
        public int idEmpleado { get; set; }

        [Required(ErrorMessage = "(A)El nombre del empleado es obligatorio.")]
        [StringLength(100, ErrorMessage = "(A)La longitud máxima del nombre es 100 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "(B)El primer apellido del empleado es obligatorio.")]
        [StringLength(50, ErrorMessage = "(B)La longitud máxima del primer apellido es 50 caracteres")]
        [Display(Name = "Primer apellido")]
        public string apPaterno { get; set; }


        //[Required(ErrorMessage = "(C)El apellido materno del empleado es obligatorio.")]
        [StringLength(50, ErrorMessage = "(C)La longitud máxima del segundo apellido es 50 caracteres")]
        [Display(Name = "Segundo apellido")]
        public string apMaterno { get; set; }


        [Required(ErrorMessage = "(D)La CURP es obligatoria.")]
        [StringLength(18, ErrorMessage = "(D)La longitud máxima de la CURP es 18 caracteres")]
        [RegularExpression(@"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$", ErrorMessage = "(D)La CURP es inválida")]
        [Display(Name = "CURP")]
        public string CURP { get; set; }


        [Required(ErrorMessage = "(E)El número de seguridad social es obligatorio.")]
        [StringLength(11, ErrorMessage = "(E)La longitud máxima del número de seguridad social es 11 caracteres")]
        [RegularExpression(@"^(\d{2})(\d{2})(\d{2})\d{5}$", ErrorMessage = "(E)El número de seguridad social es inválido")]
        [Display(Name = "IMSS")]
        public string IMSS { get; set; }


        [Required(ErrorMessage = "(F)El estado civil es obligatorio.")]
        public int? fkEstadoCivil { get; set; }


        [Required(ErrorMessage = "(G)La fecha de nacimiento del empleado es obligatoria.")]
        [Display(Name = "Fecha de nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[RegularExpression("(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d", ErrorMessage = "(G)La fecha de nacimiento es inválida")]
        public System.DateTime? fechaNacimiento { get; set; }


        //[Required(ErrorMessage = "(H)La fotografía es obligatoria.")]
        [Display(Name = "Fotografia")]
        public string Fotografia { get; set; }


        [Required(ErrorMessage = "(I)El teléfono es obligatorio.")]
        [StringLength(10, ErrorMessage = "(I)La longitud máxima del teléfono es 10 caracteres")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(I)Favor de verificar el formato del teléfono.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "(J)El celular es obligatorio.")]
        [StringLength(10, ErrorMessage = "(J)La longitud máxima del celular es 10 caracteres")]
        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(J)Favor de verificar el formato del celular.")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        [RegularExpression("^[2-9]{1}[0-9]{9}$", ErrorMessage = "(K)Favor de verificar el formato del fax.")]
        [StringLength(50, ErrorMessage = "(K)La longitud máxima del fax es 50 caracteres")]
        [Display(Name = "Fax")]
        public string Fax { get; set; }


        [StringLength(150, ErrorMessage = "(L)La longitud máxima del correo electrónico es 150 caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.([a-zA-Z]{2,4})+$", ErrorMessage = "(L)Favor de verificar el formato del correo electrónico.")]
        [Display(Name = "Correo electrónico")]
        public string correoElectronico { get; set; }

        //------------------------

        [Required(ErrorMessage = "(M)La colonia es obligatoria.")]
        [StringLength(100, ErrorMessage = "(M)La longitud máxima de la colonia es 100 caracteres")]
        [Display(Name = "Colonia")]
        public string Colonia { get; set; }


        [Required(ErrorMessage = "(N)La calle es obligatoria.")]
        [StringLength(150, ErrorMessage = "(N)La longitud máxima de la calle es 150 caracteres")]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        
        //[Required(ErrorMessage = "(O)El número interior es obligatorio.")]
        [StringLength(8, ErrorMessage = "(O)La longitud máxima del número interior es 8 caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(O)El número interior solo permite números.")]
        [Display(Name = "Número interior")]
        public string numeroInterior { get; set; }


        [Required(ErrorMessage = "(P)El número exterior es obligatorio.")]
        [StringLength(8, ErrorMessage = "(P)La longitud máxima del número exterior es 8 caracteres")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(P)El número exterior solo permite números.")]
        [Display(Name = "Número exterior")]

        public string numeroExterior { get; set; }


        [Required(ErrorMessage = "(Q)El código postal es obligatorio.")]
        [StringLength(5, ErrorMessage = "(Q)La longitud máxima del código postal es 5 caracteres")]
        [RegularExpression(@"^(?:0[1-9]\d{3}|[1-4]\d{4}|5[0-2]\d{3})$", ErrorMessage = "(Q)Favor de verificar el formato del código postal.")]
        [Display(Name = "Código Postal")]
        public string codigoPostal { get; set; }

        [Display(Name = "Cardinalidad")]
        [StringLength(10, ErrorMessage = "(R)La longitud máxima de la cardinalidad es 10 caracteres")]
        public string Cardinalidad { get; set; }

        [Required(ErrorMessage = "(S)Favor de seleccionar una ciudad de origen.")]
        [Display(Name = "Ciudad")]
        public int? fkCiudad { get; set; }

        //------------
        [Required(ErrorMessage = "(T)El banco es obligatorio.")]
        public int? fkBanco { get; set; }


        [Required(ErrorMessage = "(U)La cuenta bancaria es obligatoria.")]
        [StringLength(20, ErrorMessage = "(U)La longitud máxima de la cuenta bancaria es 20 caracteres")]
        [RegularExpression(@"^([0-9]){20}$", ErrorMessage = "(U)Favor de verificar el formato de la cuenta bancaria.")]
        [Display(Name = "Cuenta bancaria")]
        public string cuentaBancaria { get; set; }


       
        [Required(ErrorMessage = "(V)La CLABE interbancaria es obligatoria.")]
        [StringLength(18, ErrorMessage = "(V)La longitud máxima de la CLABE interbancaria es 18 caracteres")]
        [RegularExpression("^([0-9]){18}$", ErrorMessage = "(V)Favor de verificar el formato de la CLABE interbancaria.")]
        [Display(Name = "Cuenta bancaria")]
        public string clabeInterbancaria { get; set; }


        [Required(ErrorMessage = "(W)La sucursal es obligatoria.")]
        [Display(Name = "Sucursal")]
        public int? fkSucursal { get; set; }
        [ForeignKey("fkSucursal")]
        public Sucursal Sucursal { get; set; }


        [Required(ErrorMessage = "(X)El puesto es obligatorio.")]
        [Display(Name = "Puesto")]
        public int? fkPuesto { get; set; }
        [ForeignKey("fkPuesto")]
        public Puesto Puesto { get; set; }


        //[Required(ErrorMessage = "(Y)El horario es obligatorio.")]
        //[Display(Name = "Horario")]
        //public int? fkHorario { get; set; }

        //------------------------------------------------------------------
        
        //_-------------------------------------------------------------------

        [Required(ErrorMessage = "(Z)El sueldo diario es obligatorio.")]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "(Z)El sueldo diario solo permite números.")]
        [Display(Name = "Sueldo diario")]
        public double? sueldoDiario { get; set; }

        [StringLength(20)]
        [RegularExpression(@"^([A-ZÑ\x26]{3,4}([0-9]{2})(0[1-9]|1[0-2])(0[1-9]|1[0-9]|2[0-9]|3[0-1]))([A-Z\d]{3})?$")]
        [Display(Name = "RFC")]
        public string RFC { get; set; }


        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public bool? Habilitado { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }

        //Nomina

        //fkTurno
        [Required(ErrorMessage = "(Y)El turno es obligatorio.")]
        [Display(Name = "Turno")]
        public int? fkTurno { get; set; }
        [ForeignKey("fkTurno")]
        public Nominas.Turnos Turnos { get; set; }



        public char estadoEmpleado { get; set; }
        public int? fkDepartamento { get; set; }
        [ForeignKey("fkDepartamento")]
        public Departamento Departamento { get; set; }

        //fkTipoPeriodo
        public int? fkTipoPeriodo { get; set; }
        [ForeignKey("fkTipoPeriodo")]
        public Nominas.Nom_TipoPeriodo Nom_TipoPeriodo { get; set; }

        


        [StringLength(10)]
        public string codigoEmpleado { get; set; }

        [StringLength(70)]
        public string lugarNacimiento { get; set; }

        public char sexo { get; set; }

        public int umf { get; set; }

        [StringLength(3)]
        public string sucursalBanco { get; set; }

        public DateTime? fechaSueldoDiario { get; set; }

        public double? sueldoVariable { get; set; } //--

        public DateTime? fechaSueldoVariable { get; set; }

        public double? sueldoPromedio { get; set; } //--

        public DateTime? fechaSueldoPromedio { get; set; }
        public double? sueldoIntegrado { get; set; } //--
        public DateTime? fechaSueldoIntegrado { get; set; }
        public bool? calculado { get; set; }
        public bool? afectado { get; set; }
        public bool? calculadoExtraordinario { get; set; }
        public bool? afectadoExtraordinario { get; set; }
        public DateTime fechaAlta { get; set; }
        public char tipoContrato { get; set; }
        public char baseCotizacionImss { get; set; }
        public char tipoEmpleado { get; set; }
        public char basePago { get; set; }

        [StringLength(2)]
        public string formaPago { get; set; }

        public char zonaSalario { get; set; }

        public bool? calculoptu { get; set; }
        public bool? calculoAguinaldo { get; set; }
        public bool? altaImss { get; set; }
        public bool? bajaImss { get; set; }
        public bool? modificacionSalarioImss { get; set; }
        public bool? cambioCotizacionImss { get; set; }

        [StringLength(100)]
        public string nombrePadre { get; set; }

        [StringLength(100)]
        public string nombreMadre { get; set; }

        [StringLength(20)]
        public string numeroAfore { get; set; }

        public DateTime fechaBaja { get; set; }

        [StringLength(100)]
        public string causaBaja { get; set; }
        public double? sueldoBaseLiquidacion { get; set; } //--

        [StringLength(50)]
        public string centroCosto { get; set; }

        [StringLength(100)]
        public string iut { get; set; }
        public double? sueldoNetoMensual { get; set; } //--
        public double porcentajePensionAlimenticia { get; set; } //--
        public double ajusteAlNeto { get; set; } //--

        //fkRegistroPatronal
        public int? fkRegistroPatronal { get; set; }
        [ForeignKey("fkRegistroPatronal")]
        public Nominas.Nom_RegistroPatronal RegistroPatronal { get; set; }

        [StringLength(4)]
        public string estadoEmpleadoPeriodo { get; set; }
        public double? sueldoMixto { get; set; } //--
        public DateTime? fechaSueldoMixto { get; set; }

        [StringLength(15)]
        public string numeroFonacot { get; set; }

        [StringLength(2)]
        public string tipoRegimen { get; set; }
        public bool? subcontratacion { get; set; }
        public bool? extranjeroSinCurp { get; set; }
        public int tipoPrestacion { get; set; }
        public double diasVacacionesTomadasAntesDeAlta { get; set; } //--
        public double diasPrimaVacTomadasAntesDeAlta { get; set; } //--

    }
}
