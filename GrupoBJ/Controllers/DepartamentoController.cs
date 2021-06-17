using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class DepartamentoController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion

        #region "Constructor"
        public DepartamentoController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método que se ejecuta cuando se inicia la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboEmpresa();
                listarComboFiltro();
                List<Departamento> liListaDepartamento = new List<Departamento>();

                liListaDepartamento = _context.Departamento.Include
                    (c => c.Empresa).AsNoTracking().ToList(); //Incluir la información de la empresa (Relacion)
                liListaDepartamento = liListaDepartamento.Where(p => p.Habilitado == true).ToList();
                return View(liListaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Carga de datos"

        //Método para carga las empresas
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
                liLista.Insert(0, new SelectListItem { Selected = true, Disabled = true, 
                    Text = "--Seleccione una empresa--", Value = "" });
                ViewBag.listaEmpresa = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para carga el filtro
        public void listarComboFiltro()
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
                liLista.Insert(0, new SelectListItem {Text = "Todas las empresas", Value = "" });
                ViewBag.listaFiltro = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"

        [HttpPost]
        //Método para filtrar la tabla con el buscador y/o combo
        public ActionResult Filtro(string BuscadorDepartamento, bool Habilitar, int? filtroCombo, string datosFiltro) //Filtro por textbox
        {
            try
            {
                string consultaLike;
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Departamento> liListarDepartamento = new List<Departamento>();
                //Creación de la consulta de filtro dinámica sin combo filtro
                sbConsulta.Remove(0, sbConsulta.Length);
                sbConsulta.AppendLine("SELECT D.idDepartamento, D.Nombre, D.fkEmpresa, D.Habilitado, D.fechaCr, ");
                sbConsulta.AppendLine("D.fkUsuarioCr, D.fechaUm, D.fkUsuarioUm FROM Departamento AS D ");
                sbConsulta.AppendLine("INNER JOIN Empresa AS E ON D.fkEmpresa = E.idEmpresa WHERE D.Habilitado = 1 AND ");
                consultaLike = sbConsulta.ToString();

         
                if (filtroCombo == null)
                {
                    consultaLike +=  "(";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%')";
                    }
                    liListarDepartamento = _context.Departamento.FromSqlRaw(consultaLike).Include(c => c.Empresa).ToList();
                }
                else
                {
                    consultaLike +=  "fkEmpresa = " + filtroCombo + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%')";
                    }
                    liListarDepartamento = _context.Departamento.FromSqlRaw(consultaLike).Include(c => c.Empresa).ToList();
                }
                return PartialView("_TablaDepartamento", liListarDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método pata guardar los datos (Insersión o modificación)
        [HttpPost]
        public string Guardar(Departamento departamento, int? id, int fkEmpresa)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Departamento> liListaDepartamento = new List<Departamento>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaDepartamento = _context.Departamento.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaDepartamento.Where(p => p.Nombre.ToUpper() == departamento.Nombre.ToUpper() 
                                    && p.fkEmpresa == fkEmpresa).Count(); //Validación por nombre de la empresa
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            departamento.Habilitado = true;
                            departamento.fechaCr = DateTime.Now;
                            departamento.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Departamento.Add(departamento);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListaDepartamento = _context.Departamento.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaDepartamento.Where(p => p.Nombre.ToUpper() == departamento.Nombre.ToUpper() 
                                    && p.fkEmpresa == fkEmpresa 
                                    && p.idDepartamento != id).Count(); //Validación de registro no repetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var vaObj = _context.Departamento.Find(id);
                            vaObj.Nombre = departamento.Nombre;
                            vaObj.fkEmpresa = departamento.fkEmpresa;
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

        //Método para deshabilitar un registro cuando se desea borrarlo
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaObj = _context.Departamento.Find(id);
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
                var vaDepartamento = _context.Departamento.Find(id);
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para obtener los datos de la relación anterior (Empresa)
        public IActionResult recuperarDatosRelacionAnterior(int id)
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


        //Método para verificar las relaciones que tiene
        public int verificarRelacionesPuesto(int id)
        {
            try
            {
                var vaCantidad = _context.Puesto.Where(p => p.fkDepartamento == id && p.Habilitado == true).Count();
                return vaCantidad;
            }
            catch (Exception)
            {
                return 0; //Error
            }
        }

        public IActionResult recuperarDatosEliminar(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Include(c => c.Empresa).Where(p => p.idDepartamento == id && p.Habilitado == true).ToList();
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
