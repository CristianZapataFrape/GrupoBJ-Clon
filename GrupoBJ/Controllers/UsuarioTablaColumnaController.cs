using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Filters;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GrupoBJ.Controllers
{
    public class UsuarioTablaColumnaController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        public string[] asArregloColumnas;
        #endregion

        #region "Constructor"
        public UsuarioTablaColumnaController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion


        #region "Funciones CRUD"
        //Método para guardar los datos (Insersión o modificación)
        [HttpPost]
        public string configurarTabla(string validacionColumnas)
        {
            //--------------------------------Validaciones para la tabla----------------------------------
            //Crear el asArreglo de colección
            asArregloColumnas = validacionColumnas.TrimStart('[').TrimEnd(']').Split(',');

            //Validar rango de números y calcular suma de columnas visibles
            double doSumaAnchoColumna = 0;
            for (int i = 1; i < asArregloColumnas.Length-1; i = i + 3)
            {
                int visible = int.Parse(asArregloColumnas[i + 1]);
                if (visible == 1)
                {
                    if (double.Parse(asArregloColumnas[i]) <= 0 || double.Parse(asArregloColumnas[i]) > 100)
                        return "El rango del ancho de las columnas visibles debe estar entre 1% y 100%";

                    doSumaAnchoColumna = doSumaAnchoColumna + double.Parse(asArregloColumnas[i]);
                }
            }

            //Validación de la suma debe ser 100%
            if (doSumaAnchoColumna != 100)
                return "La suma del ancho de las columnas visibles debe ser 100%";

            //Datos de la tabla y usuario logueado
            string stTabla = asArregloColumnas[asArregloColumnas.Length - 1];
            int inIdUsuarioTabla = (int)HttpContext.Session.GetInt32("UsuarioSession");

            //Obtención de las columnas configuradas para la tabla de ese usuario
            List<Usuario_Tabla_Columna> liUTC;
            liUTC = _context.Usuario_Tabla_Columna.Where(p => p.fkUsuario == inIdUsuarioTabla && p.Tabla == stTabla && p.Habilitado == true).ToList();

            //Buscar los datos de la tabla liUTC en BD y los sobrantes quitarlos de BD (Deshabilitarlos)
            foreach (var item in liUTC)
            {
                bool boBandera = false;
                for (int i = 0; i < asArregloColumnas.Length-1; i = i + 3)
                {
                    if (item.fkUsuario == inIdUsuarioTabla && item.Tabla == stTabla && item.Columna == asArregloColumnas[i]) //Repetidos
                    {
                        //Actualiza el ancho y la visibilidad de los datos encontrados
                        var vaObjetoColumnaAct = _context.Usuario_Tabla_Columna.Find(item.idUsuarioTablaColumna);
                        vaObjetoColumnaAct.Ancho = int.Parse(asArregloColumnas[i + 1]);
                        int inVisibilidadAct = int.Parse(asArregloColumnas[i + 2]);
                        if (inVisibilidadAct == 1)
                            vaObjetoColumnaAct.Visibilidad = true;
                        else
                            vaObjetoColumnaAct.Visibilidad = false;
                        vaObjetoColumnaAct.fechaUm = DateTime.Now;
                        vaObjetoColumnaAct.fkUsuarioUm = inIdUsuarioTabla; //Se reemplaza por el usuario que se logueo                                             
                        _context.SaveChanges();
                        boBandera = true;
                        break;
                    }
                }
                if (boBandera == false) //Los que sobran en liUTC
                {
                    var vaObjetoColumna = _context.Usuario_Tabla_Columna.Find(item.idUsuarioTablaColumna);
                    vaObjetoColumna.Ancho = 0;
                    vaObjetoColumna.Visibilidad = false;
                    vaObjetoColumna.fechaUm = DateTime.Now;
                    vaObjetoColumna.fkUsuarioUm = inIdUsuarioTabla; //Se reemplaza por el usuario que se logueo
                    vaObjetoColumna.Habilitado = false;
                    _context.SaveChanges();
                }
            }

            //Agregar los datos a la tabla de BD que faltan en liUTC
            List<Usuario_Tabla_Columna> liInsertarColumnas = new List<Usuario_Tabla_Columna>();
            for (int i = 0; i < asArregloColumnas.Length-1; i = i + 3)
            {
                bool boBandera = false;
                foreach (var item in liUTC)
                {
                    if (item.fkUsuario == inIdUsuarioTabla && item.Tabla == stTabla && item.Columna == asArregloColumnas[i]) //Repetidos
                    {
                        boBandera = true;
                        break;
                    }
                }
                if (boBandera == false)
                {
                    //Obtener los valores del asArregloColumnas
                    string stColumna = asArregloColumnas[i];
                    int doAnchoColum = int.Parse(asArregloColumnas[i + 1]);
                    int inVisibilidadColum = int.Parse(asArregloColumnas[i + 2]);
                    bool boVisibilidadColum = true;
                    if (inVisibilidadColum == 0)
                        boVisibilidadColum = false;

                    //Verificar que exista algun registro deshabilitado con esos datos
                    int inConsultaColumna = _context.Usuario_Tabla_Columna.Where(p => p.Columna == stColumna && p.Tabla == stTabla
                                    && p.fkUsuario == inIdUsuarioTabla &&
                                    p.Habilitado == false).Count();

                    if (inConsultaColumna > 0) //Habilitar el registro
                    {
                        var vaRegistroEncontrado = _context.Usuario_Tabla_Columna.Where(p => p.Columna == stColumna && p.Tabla == stTabla
                                    && p.fkUsuario == inIdUsuarioTabla &&
                                    p.Habilitado == false).ToList();

                        vaRegistroEncontrado[0].fechaUm = DateTime.Now;
                        vaRegistroEncontrado[0].fkUsuarioUm = inIdUsuarioTabla; //Se reemplaza por el usuario que se logueo
                        vaRegistroEncontrado[0].Habilitado = true;
                        vaRegistroEncontrado[0].Visibilidad = boVisibilidadColum;
                        vaRegistroEncontrado[0].Ancho = doAnchoColum;
                        _context.SaveChanges();

                    }
                    else //Insertarlo
                    {
                        liInsertarColumnas.Add(new Usuario_Tabla_Columna()
                        {
                            Tabla = stTabla,
                            Columna = stColumna,
                            fkUsuario = inIdUsuarioTabla,
                            Ancho = doAnchoColum,
                            Visibilidad = boVisibilidadColum,
                            Habilitado = true,
                            fechaCr = DateTime.Now,
                            fkUsuarioCr = inIdUsuarioTabla
                        });
                    }
                }
            }
            _context.Usuario_Tabla_Columna.AddRange(liInsertarColumnas);
            _context.SaveChanges();

            return "1";
        }


        //Método para guardar las columnas predeterminadas para el usuario
        public string guardarColPredeterminadas(string columnas)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string[] asArregloColPredeterminadas = columnas.TrimStart('[').TrimEnd(']').Split(',');
                string stTablaBD = asArregloColPredeterminadas[asArregloColPredeterminadas.Length - 1];
                //Agregar las columnas predeterminadas para el usuario
                List<Usuario_Tabla_Columna> liColumnasPredeterminadas = new List<Usuario_Tabla_Columna>();
                for (int i = 0; i < asArregloColPredeterminadas.Length-1; i = i + 3)
                {
                    string stAnchoPre = asArregloColPredeterminadas[i + 1];
                    stAnchoPre = stAnchoPre.Substring(0, stAnchoPre.Length - 1);
                    int inVsibilidadPre = int.Parse(asArregloColPredeterminadas[i + 2]);
                    bool boVisibilidadPre = false;
                    if (inVsibilidadPre == 1)
                        boVisibilidadPre = true;

                    liColumnasPredeterminadas.Add(new Usuario_Tabla_Columna()
                    {
                        Tabla = stTablaBD,
                        Columna = asArregloColPredeterminadas[i],
                        fkUsuario = fkUsuarioLogin,
                        Ancho = int.Parse(stAnchoPre),
                        Visibilidad = boVisibilidadPre,
                        Habilitado = true,
                        fechaCr = DateTime.Now,
                        fkUsuarioCr = fkUsuarioLogin
                    });
                }
                _context.Usuario_Tabla_Columna.AddRange(liColumnasPredeterminadas);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }


        //Método para validar las columnas del HTML
        public string validarTablaHTML(string columnas)
        {
            try
            {
                //Obtención de las columnas de BD asociadas a la tabla HTML
                string[] asArregloColumnasHTML = columnas.TrimStart('[').TrimEnd(']').Split(',');
                string stTablaHtml = asArregloColumnasHTML[asArregloColumnasHTML.Length - 1];
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaColumnasBD = _context.Usuario_Tabla_Columna.Where(p => p.Tabla == stTablaHtml && p.fkUsuario == fkUsuarioLogin && p.Habilitado == true).ToList();

                //Validar que solo esten dadas de alta las mismas columnas que en HTML, sino borrarlas
                for (int i = 0; i < vaColumnasBD.Count; i++)
                {
                    string stColumnaBD = vaColumnasBD[i].Columna;
                    bool boEncontradoBD = false;
                    for (int j = 0; j < asArregloColumnasHTML.Length - 1; j++)
                    {
                        if (vaColumnasBD[i].Columna == asArregloColumnasHTML[j])
                        {
                            boEncontradoBD = true;
                            break;
                        }
                    }
                    if (boEncontradoBD == false) //No se encontro eb BD (Deshabilitarlo)
                    {
                        var vaObj = _context.Usuario_Tabla_Columna.Find(vaColumnasBD[i].idUsuarioTablaColumna);
                        vaObj.Ancho = 0;
                        vaObj.Visibilidad = false;
                        vaObj.Habilitado = false;
                        vaObj.fechaUm = DateTime.Now;
                        vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                        _context.SaveChanges();
                    }

                }

                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }

        //Cambiar todas las columnas a visibles ya que no te tiene una configuración
        public string cambiarColumnasVisibles(string tabla)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaColumnasBD = _context.Usuario_Tabla_Columna.Where(p => p.Tabla == tabla && p.fkUsuario == fkUsuarioLogin && p.Habilitado == true).ToList();
                for (int i = 0; i < vaColumnasBD.Count; i++)
                {
                    var vaObj = _context.Usuario_Tabla_Columna.Find(vaColumnasBD[i].idUsuarioTablaColumna);
                    vaObj.Visibilidad = true;
                    vaObj.fechaUm = DateTime.Now;
                    vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                    _context.SaveChanges();
                }

                return "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion


        #region "Querys"
        //Recuperar los datos de la colección para Actualizar
        public IActionResult cargarDatosTabla(string tabla)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaColeccion = _context.Usuario_Tabla_Columna.Where(
                                    p => p.Tabla == tabla
                                    && p.fkUsuario == fkUsuarioLogin
                                    && p.Habilitado == true
                                    && p.Visibilidad == true
                                    ).ToList();
                return Ok(vaColeccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Comprobar registro existente
        public IActionResult buscarRegistroExistente(string tabla)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaColeccion = _context.Usuario_Tabla_Columna.Where(
                                    p => p.Tabla == tabla
                                    && p.fkUsuario == fkUsuarioLogin
                                    && p.Habilitado == true
                                    ).ToList();
                return Ok(vaColeccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
