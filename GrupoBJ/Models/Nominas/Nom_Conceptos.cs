using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models.Nominas
{
    public class Nom_Conceptos
    {
        [Key]
        public int idConcepto { get; set; }


        [Display(Name = "Número de concepto")]
        public int? numeroConcepto { get; set; }


        [Display(Name = "Tipo concepto")]
        public char? tipoConcepto { get; set; }


        [StringLength(40, ErrorMessage = "(A)La longitud máxima del nombre es 40 caracteres")]
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }


        [Display(Name = "Especie")]
        public bool? Especie { get; set; }


        [Display(Name = "Automático global")]
        public bool? automaticoGlobal { get; set; }


        [Display(Name = "Automático liquidación")]
        public bool? automaticoLiquidacion { get; set; }


        [Display(Name = "Imprimir")]
        public bool? Imprimir { get; set; }


        [Display(Name = "Artículo 86")]
        public bool? Articulo86 { get; set; }


        [StringLength(40, ErrorMessage = "(B)La longitud máxima de la leyenda importe 1 es 40 caracteres")]
        [Display(Name = "Leyenda importe 1")]
        public string? leyendaImporte1 { get; set; }


        [StringLength(40, ErrorMessage = "(C)La longitud máxima de la leyenda importe 2 es 40 caracteres")]
        [Display(Name = "Leyenda importe 2")]
        public string? leyendaImporte2 { get; set; }


        [StringLength(40, ErrorMessage = "(D)La longitud máxima de la leyenda importe 3 es 40 caracteres")]
        [Display(Name = "Leyenda importe 3")]
        public string? leyendaImporte3 { get; set; }


        [StringLength(40, ErrorMessage = "(E)La longitud máxima de la leyenda importe 4 es 40 caracteres")]
        [Display(Name = "Leyenda importe 4")]
        public string? leyendaImporte4 { get; set; }


        [StringLength(30, ErrorMessage = "(F)La longitud máxima de la cuenta contable es 30 caracteres")]
        [Display(Name = "Cuenta contable")]
        public string? cuentaContable { get; set; }


        [StringLength(30, ErrorMessage = "(F)La longitud máxima de la contra cuenta contable es 30 caracteres")]
        [Display(Name = "Contra cuenta contable")]
        public string? contraCuentaContable { get; set; }


        [Display(Name = "Tipo de movimiento contable")]
        public char? tipoMovimientoContable { get; set; }


        [Display(Name = "Contabilización de cuenta")]
        public char? contabilizacionCuenta { get; set; }


        [Display(Name = "Contabilización de contra cuenta")]
        public char? contabilizacionContraCuenta { get; set; }


        [StringLength(40, ErrorMessage = "(G)La longitud máxima de la leyenda de valor es 40 caracteres")]
        [Display(Name = "Leyenda de valor")]
        public string? leyendaValor { get; set; }


        [Display(Name = "Fórmula importe total")]
        public string? formulaImporteTotal { get; set; }


        [Display(Name = "Fórmula importe 1")]
        public string? formulaImporte1 { get; set; }


        [Display(Name = "Fórmula importe 2")]
        public string? formulaImporte2 { get; set; }


        [Display(Name = "Fórmula importe 3")]
        public string? formulaImporte3 { get; set; }


        [Display(Name = "Fórmula importe 4")]
        public string? formulaImporte4 { get; set; }


        [Display(Name = "Fórmula valor")]
        public string? formulaValor { get; set; }


        [StringLength(2, ErrorMessage = "(H)La longitud máxima de la clave agrupador SAT es 2 caracteres")]
        [Display(Name = "Leyenda de valor")]
        public string? claveAgrupadoraSAT { get; set; }


        [StringLength(30, ErrorMessage = "(I)La longitud máxima de la cuenta gravado es 30 caracteres")]
        [Display(Name = "Cuenta gravado")]
        public string? cuentaGravado { get; set; }


        [StringLength(30, ErrorMessage = "(J)La longitud máxima de la cuenta excento deducible es 30 caracteres")]
        [Display(Name = "Cuenta excento deducible")]
        public string? cuentaExcentoDeduc { get; set; }


        [StringLength(30, ErrorMessage = "(K)La longitud máxima de la cuenta excento no deducible es 30 caracteres")]
        [Display(Name = "Cuenta excento no deducible")]
        public string? cuentaExcentoNoDeduc { get; set; }


        [StringLength(2, ErrorMessage = "(L)La longitud máxima del método de pago es 2 caracteres")]
        [Display(Name = "Método de pago")]
        public string? metodoPago { get; set; }


        [StringLength(2, ErrorMessage = "(M)La longitud máxima del tipo clave SAT es 2 caracteres")]
        [Display(Name = "Tipo clave SAT")]
        public string? tipoClaveSAT { get; set; }


        [StringLength(12, ErrorMessage = "(N)La longitud máxima del tipo de horas es 12 caracteres")]
        [Display(Name = "Tipo horas")]
        public string? tipoHoras { get; set; }


        public bool? Habilitado { get; set; }
        public int fkUsuarioCr { get; set; }
        public DateTime fechaCr { get; set; }
        public int fkUsuarioUm { get; set; }
        public DateTime fechaUm { get; set; }





















    }
}
