using System;
using System.Text;
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
    public class AccesoPerfilController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion

        #region "Constructor"
        public AccesoPerfilController(GrupoBJDBContext context)
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
                listarComboSistema();
                listarComboFiltroEmpresa();
                listarComboFiltroSistema();
                List<Acceso_Perfil> liListaAccesoPerfil = new List<Acceso_Perfil>();
                liListaAccesoPerfil = _context.Acceso_Perfil.Include(c => c.Acceso_Sistema.Empresa).
                    Where(p => p.Habilitado == true).ToList();
                return View(liListaAccesoPerfil);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Carga de datos"
        //Método para llenar el combo de sistema del modal
        public void listarComboSistema()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Acceso_Sistema.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idSistema.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un sistema--",
                    Value = ""
                });
                ViewBag.listaAccesoSistema = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }


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
        public void listarComboFiltroEmpresa()
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
                liLista.Insert(0, new SelectListItem { Text = "Todas las empresas", Value = "" });
                ViewBag.listaFiltroEmpresa = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para llenar el combo filtro de sistema
        public void listarComboFiltroSistema()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Acceso_Sistema.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idSistema.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem { Text = "Todos los sistemas", Value = "" });
                ViewBag.listaFiltro = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Método para filtrar contenido de la tabla
        public ActionResult Filtro(string BuscadorAccesoPerfil, int? filtroCombo, int? filtroComboEmpresa, string datosFiltro)
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Acceso_Perfil> liListarPerfil = new List<Acceso_Perfil>();
                
                sbConsulta.Remove(0, sbConsulta.Length);
                sbConsulta.AppendLine("SELECT Per.idPerfil, Per.Nombre, Per.fkSistema, Per.fkUsuarioCr, Per.fechaCr, ");
                sbConsulta.AppendLine("    Per.Habilitado, Per.fechaUm, Per.fkUsuarioUm");
                sbConsulta.AppendLine( "FROM Acceso_Perfil AS Per ");
                sbConsulta.AppendLine("    INNER JOIN Acceso_Sistema AS Sis ON Per.fkSistema = Sis.idSistema ");
                sbConsulta.AppendLine("    INNER JOIN Acceso_Sistema AS Sis ON Per.fkSistema = Sis.idSistema ");
                sbConsulta.AppendLine("WHERE Per.Habilitado = 1 AND ");
                string consultaLike = sbConsulta.ToString();


                if (filtroCombo == null && filtroComboEmpresa == null)
                {
                    consultaLike +=  "(";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike += asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%' OR ";
                        else
                            consultaLike += asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%')";
                    }
                    liListarPerfil = _context.Acceso_Perfil.FromSqlRaw(consultaLike).Include(c => c.Acceso_Sistema.Empresa).ToList();
                }
                else if (filtroComboEmpresa != null && filtroCombo == null)
                {
                    consultaLike +=  "Sis.fkEmpresa = " + filtroComboEmpresa + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%')";
                    }
                    liListarPerfil = _context.Acceso_Perfil.FromSqlRaw(consultaLike).Include(c => c.Acceso_Sistema.Empresa).ToList();
                }
                else if (filtroComboEmpresa == null && filtroCombo != null)
                {
                    consultaLike =  "Per.fkSistema = " + filtroCombo + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike =  asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%' OR ";
                        else
                            consultaLike =  asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%')";
                    }
                    liListarPerfil = _context.Acceso_Perfil.FromSqlRaw(consultaLike).Include(c => c.Acceso_Sistema.Empresa).ToList();
                }
                else if (filtroComboEmpresa != null && filtroCombo != null)
                {
                    consultaLike =  "Sis.fkEmpresa = " + filtroComboEmpresa + " AND Per.fkSistema = " + filtroCombo + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike =  asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%' OR ";
                        else
                            consultaLike =  asArregloFiltro[i] + " LIKE '%" + BuscadorAccesoPerfil + "%')";
                    }
                    //liListarPerfil = _context.Acceso_Perfil.FromSqlRaw(consultaLike).Include(c => c.Acceso_Sistema.Empresa).ToList();
                    liListarPerfil = _context.Acceso_Perfil.FromSqlRaw(sbConsulta.ToString()).Include(c => c.Acceso_Sistema.Empresa).ToList();
                }
                return PartialView("_TablaAccesoPerfil", liListarPerfil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar (Insertar o editar)
        [HttpPost]
        public string Guardar(Acceso_Perfil Acceso_Perfil, int? id, int fkSistema)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Acceso_Perfil> liListaAccesoPerfil = new List<Acceso_Perfil>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaAccesoPerfil = _context.Acceso_Perfil.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaAccesoPerfil.Where(p => p.Nombre.ToUpper() == Acceso_Perfil.Nombre.ToUpper()
                                    && p.fkSistema == fkSistema).Count();
                        if (inCantidad >= 1) //Registro duplicado
                            return "-1";
                        else
                        {
                            Acceso_Perfil.Habilitado = true;
                            Acceso_Perfil.fechaCr = DateTime.Now;
                            Acceso_Perfil.fkUsuarioCr = fkUsuarioLogin; //Se reemplaza por el usuario logueado
                            _context.Acceso_Perfil.Add(Acceso_Perfil);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Editar
                    {
                        liListaAccesoPerfil = _context.Acceso_Perfil.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaAccesoPerfil.Where(p => p.Nombre.ToUpper() == Acceso_Perfil.Nombre.ToUpper()
                                    && p.fkSistema == fkSistema
                                    && p.idPerfil != id).Count();
                        if (inCantidad >= 1)//Registro duplicado
                            return "-1";
                        else
                        {
                            var vaObj = _context.Acceso_Perfil.Find(id);
                            vaObj.Nombre = Acceso_Perfil.Nombre;
                            vaObj.fkSistema = Acceso_Perfil.fkSistema;
                            vaObj.fechaUm = DateTime.Now;
                            vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    var vaQuery = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    stRpta += "<ul class='list-group'>";
                    vaQuery.Sort();
                    stRpta += "<li class='list-group-item'>" + vaQuery[0].ToString() + "</li>";
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
                var vaObj = _context.Acceso_Perfil.Find(id);
                vaObj.Habilitado = false;
                vaObj.fechaUm = DateTime.Now;
                vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
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
                var vaAccesoPerfil = _context.Acceso_Perfil.Find(id);
                return Ok(vaAccesoPerfil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para validar las relaciones que tiene Acceso_Perfil (Agregar la relaciones con Opciones por perfiles cuando se cree en el modelo)
        public int verificarRelaciones(int id) //Añadir la relacion con Perfiles Opciones
        {
            try
            {
                var vaColeccion = _context.Usuario_Empresa_Sucursal_Sis_Per.Where
                    (p => p.fkPerfil == id && p.Habilitado == true).Count();
                if (vaColeccion == 0)
                {
                    var vaAcceso_Perfil = _context.Acceso_Permiso_Perfil_Opcion.Where
                    (p => p.fkPerfil == id && p.Habilitado == true).Count();
                    return vaAcceso_Perfil;
                }
                else
                    return vaColeccion;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public IActionResult recuperarDatosSistema(int id)
        {
            try
            {
                var vaSistema = _context.Acceso_Sistema.Find(id);
                return Ok(vaSistema);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-------------------Recuperar datos de empresa----------------
        public IActionResult recuperarDatosEmpresa(int id)
        {
            try
            {
                var vaEmpresa = _context.Acceso_Sistema.Find(id);
                return Ok(vaEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //------------------------Actualizar combo de filtro de sistema
        public IActionResult actualizarComboFitroSistema(int id)
        {
            try
            {
                var vaSistema = _context.Acceso_Sistema.Where(p => p.fkEmpresa == id & p.Habilitado == true).ToList();
                return Ok(vaSistema);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Actualizar el combo sistema del modal
        public IActionResult actualizarSistema(int id)
        {
            try
            {
                var vaSistema = _context.Acceso_Sistema.Where(p => p.fkEmpresa == id & p.Habilitado == true).ToList();
                return Ok(vaSistema);
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
                var vaPerfil = _context.Acceso_Perfil.Include(c => c.Acceso_Sistema).Where(p => p.idPerfil == id && p.Habilitado == true).ToList();
                return Ok(vaPerfil);
            }
            catch (Exception)
            { 
                throw;
            }
        }

        #endregion

    }
}
