using GrupoBJ.Models;
using GrupoBJ.Models.Nominas;
using GrupoBJ.Models.Contabilidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.DataBase
{
    public class GrupoBJDBContext : DbContext
    {
        public GrupoBJDBContext(DbContextOptions<GrupoBJDBContext> options) : base(options)
        {

        }

        //USUARIOS

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Pais> Pais { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Ciudad> Ciudad { get; set; }

        public DbSet<Moneda> Moneda { get; set; }

        public DbSet<MonedaSAT> MonedaSAT { get; set; }

        public DbSet<Sucursal> Sucursal { get; set; }

        public DbSet<Puesto> Puesto { get; set; }

        public DbSet<Departamento> Departamento { get; set; }

        public DbSet<Empleado> Empleado { get; set; }

        public DbSet<Estado_Civil> Estado_Civil { get; set; }

        public DbSet<Banco> Banco { get; set; }

        //public DbSet<Horario> Horario { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<Usuario_Empresa_Sucursal> Usuario_Empresa_Sucursal { get; set; }

        public DbSet<Acceso_Sistema> Acceso_Sistema { get; set; }

        public DbSet<Acceso_Perfil> Acceso_Perfil { get; set; }

        //public DbSet<Acceso_Usuario_Sistema_Perfil> Acceso_Usuario_Sistema_Perfil { get; set; }

        public DbSet<Acceso_Tipo_Archivo> Acceso_Tipo_Archivo { get; set; }

        public DbSet<Acceso_Opcion> Acceso_Opcion { get; set; }

        public DbSet<Usuario_Empresa_Sucursal_Sis_Per> Usuario_Empresa_Sucursal_Sis_Per { get; set; }

        public DbSet<Acceso_Permiso> Acceso_Permiso { get; set; }

        public DbSet<Acceso_Permiso_Perfil_Opcion> Acceso_Permiso_Perfil_Opcion { get; set; }

        public DbSet<Acceso_Opcion_Permiso> Acceso_Opcion_Permiso { get; set; }

        public DbSet<Usuario_Tabla_Columna> Usuario_Tabla_Columna { get; set; }

        //NÓMINAS

        public DbSet<Turnos> Turnos { get; set; }
        public DbSet<Nom_RegistroPatronal> Nom_RegistroPatronal { get; set; }

        public DbSet<Nom_Periodo> Nom_Periodo { get; set; }
        public DbSet<Nom_TipoPeriodo> Nom_TipoPeriodo { get; set; }


        public DbSet<Nom_FraccionesImss> Nom_FraccionesImss { get; set; }

        public DbSet<Nom_ControlVacaciones> Nom_ControlVacaciones { get; set; }

        public DbSet<Nom_HistorialSueldos> Nom_HistorialSueldos { get; set; }

        public DbSet<Nom_HistorialAltaBajaReingreso> Nom_HistorialAltaBajaReingreso { get; set; }

        public DbSet<Nom_Conceptos> Nom_Conceptos { get; set; }

        public DbSet<Nom_Empleados_Conceptos> Nom_Empleados_Conceptos { get; set; }

        //CONTABILIDAD
        public DbSet<Tipo_ConceptosIETU> Tipo_ConceptosIETU { get; set; }

        public DbSet<Tipo_ConceptosIETU_IVA> Tipo_ConceptosIETU_IVA { get; set; }

        public DbSet<Tipo_ConceptosIETU_IETU> Tipo_ConceptosIETU_IETU { get; set; }
        
        public DbSet<ConceptosIETU> ConceptosIETU { get; set; }

        public DbSet<NIF_Nivel> NIF_Nivel { get; set; }

        public DbSet<NIF_Tipo> NIF_Tipo { get; set; }

        public DbSet<Rubros_NIF> Rubros_NIF { get; set; }

        public DbSet<Tipo_Diario> Tipo_Diario { get; set; }

        public DbSet<Tipo_Diario_Rubros_NIF> Tipo_Diario_Rubros_NIF { get; set; }

        public DbSet<Diarios_Especiales> Diarios_Especiales { get; set; }

        public DbSet<Diarios_Especiales_Rubros_NIF> Diarios_Especiales_Rubros_NIF { get; set; }

        public DbSet<Tipo_Cuenta> Tipo_Cuenta { get; set; }

        public DbSet<Agrupadores_SAT> Agrupadores_SAT { get; set; }

        public DbSet<Agrupadores_SAT_Rubros_NIF> Agrupadores_SAT_Rubros_NIF { get; set; }

        public DbSet<Cuentas> Cuentas { get; set; }


        //Articulos
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Articulos_Campos> Articulos_Campos { get; set; }
        public DbSet<Articulos_Valores> Articulos_Valores { get; set; }

        //Articulos Carateristicas
        public DbSet<Carateristicas> Carateristicas { get; set; }
        public DbSet<Carateristicas_Valores> Carateristica_Valores { get; set; }
        public DbSet<Articulos_Carateristicas> Articulos_Carateristicas { get; set; }

        //Articulos Codigo Barra
        public DbSet<Codigo_Barra> Codigo_Barra { get; set; }
        public DbSet<Codido_Barra_Valores> Codido_Barra_Valores { get; set; }

        //Articulos Tabla Nutrimental
        public DbSet<Articulos_Nutrimental> Articulos_Nutrimental { get; set; }
        public DbSet<Tabla_Nutrimental> Tabla_Nutrimental { get; set; }
        public DbSet<Tabla_Nutrimental_Campos> Tabla_Nutrimental_Campos { get; set; }
        public DbSet<Tabla_Nutrimental_Valores> Tabla_Nutrimental_Valores { get; set; }

        //Articulos Areas Trabajo
        //public DbSet<Areas_Trabajo> Areas_Trabajo { get; set; }
        //public DbSet<Articulos_Areas_Trabajo> Articulos_Areas_Trabajo { get; set; }

        //Articulos Unidades de medida
        public DbSet<Unidades_Medida> Unidades_Medida { get; set; }

        ////Ventas
        public DbSet<ClienteCls> Cliente { get; set; }

    }
}
