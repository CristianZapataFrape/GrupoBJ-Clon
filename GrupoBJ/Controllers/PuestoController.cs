using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GrupoBJ.DataBase;
using GrupoBJ.Models;
using GrupoBJ.Filters;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class PuestoController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion

        #region "Constructor"
        public PuestoController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método que carga al iniciar la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboEmpresa();
                listarComboDepartamento();
                listarComboFiltroDepartamento();
                listarComboFiltroEmpresa();
                List<Puesto> liListaPuesto = new List<Puesto>();

                liListaPuesto = _context.Puesto.Include
                    (c => c.Departamento.Empresa).AsNoTracking().ToList(); //Incluir la información de la empresa (Relacion)
                
                liListaPuesto = liListaPuesto.Where(p => p.Habilitado == true).ToList();
                return View(liListaPuesto);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Carga de datos"
        //Método para cargar los departamentos
        public void listarComboDepartamento()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Departamento.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idDepartamento.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Text = "--Seleccione un departamento--",
                    Value = ""
                });
                ViewBag.listaDepartamento = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar las empresas
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

        //Método para cargar el filtro de las empresas
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

        //Filtro para cargar el filtro de los departamentos
        public void listarComboFiltroDepartamento()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Departamento.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idDepartamento.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem { Text = "Todos los departamentos", Value = "" });
                ViewBag.listaFiltroDepartamento = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"

        //Método para filtrar la tabla con el buscador y combos
        public ActionResult Filtro(string BuscadorPuesto, int? filtroComboEmpresa, int? filtroComboDepartamento, string datosFiltro) //Filtro por textbox
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Puesto> liListarPuesto = new List<Puesto>();
                sbConsulta.AppendLine("SELECT P.idPuesto, P.Nombre, P.fkDepartamento, P.fkUsuarioCr, P.fechaCr, P.Habilitado, P.fechaUm, P.fkUsuarioUm ");
                sbConsulta.AppendLine("FROM Puesto AS P ");
                sbConsulta.AppendLine("  INNER JOIN Departamento AS D ON P.fkDepartamento = D.idDepartamento ");
                sbConsulta.AppendLine("  INNER JOIN Empresa AS E ON E.idEmpresa = D.fkEmpresa ");
                sbConsulta.AppendLine("  WHERE P.Habilitado = 1 AND ");
                string consultaLike = sbConsulta.ToString();

                if (filtroComboDepartamento == null && filtroComboEmpresa == null)
                {
                    consultaLike +=  "(";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%')";
                    }
                    liListarPuesto = _context.Puesto.FromSqlRaw(consultaLike).Include(c => c.Departamento.Empresa).ToList();
                }
                else if (filtroComboEmpresa == null && filtroComboDepartamento != null)
                {
                    consultaLike +=  "P.fkDepartamento = " + filtroComboDepartamento + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%')";
                    }
                    liListarPuesto = _context.Puesto.FromSqlRaw(consultaLike).Include(c => c.Departamento.Empresa).ToList();
                }
                else if (filtroComboEmpresa != null && filtroComboDepartamento == null)
                {
                    consultaLike +=  "D.fkEmpresa = " + filtroComboEmpresa + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%')";
                    }
                    liListarPuesto = _context.Puesto.FromSqlRaw(consultaLike).Include(c => c.Departamento.Empresa).ToList();
                }
                else if (filtroComboEmpresa != null && filtroComboDepartamento != null)
                {
                    consultaLike +=  "D.fkEmpresa = " + filtroComboEmpresa + " AND P.fkDepartamento = " + filtroComboDepartamento + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorPuesto + "%')";
                    }
                    liListarPuesto = _context.Puesto.FromSqlRaw(consultaLike).Include(c => c.Departamento.Empresa).ToList();
                }
                return PartialView("_TablaPuesto", liListarPuesto);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para guardar los datos (Insersión o Modificación)
        [HttpPost]
        public string Guardar(Puesto puesto, int? id, int fkDepartamento)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Puesto> liListaPuesto = new List<Puesto>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaPuesto = _context.Puesto.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaPuesto.Where(p => p.Nombre.ToUpper() == puesto.Nombre.ToUpper()
                                    && p.fkDepartamento == fkDepartamento).Count(); //Validación por nombre de la empresa
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            puesto.Habilitado = true;
                            puesto.fechaCr = DateTime.Now;
                            puesto.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Puesto.Add(puesto);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Editar
                    {
                        liListaPuesto = _context.Puesto.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaPuesto.Where(p => p.Nombre.ToUpper() == puesto.Nombre.ToUpper()
                                    && p.fkDepartamento == fkDepartamento
                                    && p.idPuesto != id).Count(); //Validación de registro no repetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var vaObj = _context.Puesto.Find(id);
                            vaObj.Nombre = puesto.Nombre;
                            vaObj.fkDepartamento = puesto.fkDepartamento;
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

        //Método para deshabilitar el registro cuando se desea eliminar
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaObj = _context.Puesto.Find(id);
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

        //Método para recuperar los datos del registro seleccionado
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaPuesto = _context.Puesto.Find(id);
                return Ok(vaPuesto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para obtener los datos de la relacion anterior (Departamento)
        public IActionResult recuperarDatosRelacionAnterior(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Find(id);
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para verificar las relaciones existentes
        public int verificarRelacionesEmpleado(int id)
        {
            try
            {
                var vaCantidad = _context.Empleado.Where(p => p.fkPuesto == id && p.Habilitado == true).Count();
                return vaCantidad;
            }
            catch (Exception)
            {
                return 0; //Error
            }
        }

        //-----------------------Recuperar datos para modificar------------------
        public IActionResult recuperarDatosDepartamento(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Find(id);
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        public IActionResult actualizarDepartamento(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Where(p => p.fkEmpresa == id & p.Habilitado==true).ToList();
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult actualizarComboDepartamento(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Where(p => p.fkEmpresa == id & p.Habilitado == true).ToList();
                return Ok(vaDepartamento);
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
                var vaPuesto = _context.Puesto.Include(c => c.Departamento.Empresa).Where(p => p.idPuesto == id && p.Habilitado == true).ToList();
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
