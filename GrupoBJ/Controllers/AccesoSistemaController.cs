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
using Microsoft.EntityFrameworkCore;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class AccesoSistemaController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        #endregion

        #region "Constructor"
        public AccesoSistemaController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método de inicio donde se cargan los datos iniciales para la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboEmpresa();
                listarComboFiltro();
                List<Acceso_Sistema> liListaAccesoSistema = new List<Acceso_Sistema>();
                liListaAccesoSistema = _context.Acceso_Sistema.Include(c => c.Empresa).Where(p => p.Habilitado == true).ToList();
                return View(liListaAccesoSistema);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Carga de datos"

        //Método para llenar el combo de empresa del modal
        public void listarComboEmpresa()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Empresa.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idEmpresa.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una empresa--",
                    Value = ""
                });
                ViewBag.listaEmpresa = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para llenar el combo filtro de empresa
        public void listarComboFiltro()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Empresa.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idEmpresa.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem { Text = "Todas las empresas", Value = "" });
                ViewBag.listaFiltro = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Método para filtrar contenido de la tabla
        public ActionResult Filtro(string BuscadorAccesoSistema, int? filtroCombo, string datosFiltro)
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Acceso_Sistema> liListarAccesoSistema = new List<Acceso_Sistema>();
                //Creación de la consulta de filtro dinámica sin combo filtro
                string consultaLike = "SELECT Sis.idSistema, Sis.Nombre, Sis.fkUsuarioCr, Sis.fechaCr, Sis.Habilitado, " +
                    "Sis.fkEmpresa, Sis.fechaUm, Sis.fkUsuarioUm FROM Acceso_Sistema AS Sis " +
                    "INNER JOIN Empresa AS E ON Sis.fkEmpresa = E.idEmpresa WHERE Sis.Habilitado = 1 AND ";

                if (filtroCombo == null)
                {
                    consultaLike = consultaLike + "(";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoSistema + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoSistema + "%')";
                    }
                    liListarAccesoSistema = _context.Acceso_Sistema.FromSqlRaw(consultaLike).Include(c => c.Empresa).ToList();
                }
                else
                {
                    consultaLike = consultaLike + "fkEmpresa = " + filtroCombo + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoSistema + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoSistema + "%')";
                    }
                    liListarAccesoSistema = _context.Acceso_Sistema.FromSqlRaw(consultaLike).Include(c => c.Empresa).ToList();
                }
                return PartialView("_TablaAccesoSistema", liListarAccesoSistema);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar (Insertar o editar)
        [HttpPost]
        public string Guardar(Acceso_Sistema Acceso_Sistema, int? id, int fkEmpresa)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Acceso_Sistema> liListaAccesoSistema = new List<Acceso_Sistema>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaAccesoSistema = _context.Acceso_Sistema.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaAccesoSistema.Where(p => p.Nombre.ToUpper() == Acceso_Sistema.Nombre.ToUpper()
                                && p.fkEmpresa == fkEmpresa).Count();
                        if (inCantidad >= 1) //Registro repetido
                            return "-1";
                        else
                        {
                            Acceso_Sistema.Habilitado = true;
                            Acceso_Sistema.fechaCr = DateTime.Now;
                            Acceso_Sistema.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Acceso_Sistema.Add(Acceso_Sistema);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListaAccesoSistema = _context.Acceso_Sistema.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaAccesoSistema.Where(p => p.Nombre.ToUpper() == Acceso_Sistema.Nombre.ToUpper()
                                    && p.fkEmpresa == fkEmpresa
                                    && p.idSistema != id).Count();
                        if (inCantidad >= 1) //Registro repetido
                            return "-1";
                        else
                        {
                            var varObj = _context.Acceso_Sistema.Find(id);
                            varObj.Nombre = Acceso_Sistema.Nombre;
                            varObj.fkEmpresa = Acceso_Sistema.fkEmpresa;
                            varObj.fechaUm = DateTime.Now;
                            varObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    var varQuery = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    stRpta += "<ul class='list-group'>";
                    varQuery.Sort();
                    stRpta += "<li class='list-group-item'>" + varQuery[0].ToString() + "</li>";
                    stRpta += "</ul>";
                    return stRpta;
                }
            }
            catch (Exception)
            {
                return "";
            }
        }

        //Método para eliminar un registro
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var varObj = _context.Acceso_Sistema.Find(id);
                varObj.Habilitado = false;
                varObj.fechaUm = DateTime.Now;
                varObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }

        #endregion

        #region "Querys"
        //Método para obtener los datos de un registro (Modificar)
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaAccesoSistema = _context.Acceso_Sistema.Find(id);
                return Ok(vaAccesoSistema);
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        //Método para validar las relaciones que tiene Acceso_Sistema
        public int verificarRelacionesSistema(int id)
        {
            try
            {
                var vaAccesoPerfil = _context.Acceso_Perfil.Where(p => p.fkSistema == id && p.Habilitado == true).Count();
                if (vaAccesoPerfil == 0)
                {
                    var vaAccesoOpcion = _context.Acceso_Opcion.Where(p => p.fkSistema == id && p.Habilitado == true).Count();
                    if (vaAccesoOpcion == 0)
                    {
                        var vaColeccion = _context.Usuario_Empresa_Sucursal_Sis_Per.Where
                         (p => p.fkSistema == id && p.Habilitado == true).Count();
                        return vaColeccion;
                    }
                    else
                        return vaAccesoOpcion;

                }
                else
                    return vaAccesoPerfil;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Recuperar datos de la empresa
        public IActionResult recuperarDatosEmpresa(int id)
        {
            try
            {
                var vaEmpresa = _context.Empresa.Find(id);
                return Ok(vaEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Obtener los datos del registro a eliminar
        public IActionResult recuperarDatosEliminar(int id)
        {
            try
            {
                var vaPuesto = _context.Acceso_Sistema.Include(c => c.Empresa).Where(p => p.idSistema == id && p.Habilitado == true).ToList();
                return Ok(vaPuesto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
