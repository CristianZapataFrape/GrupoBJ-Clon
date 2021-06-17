using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Models.Contabilidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace GrupoBJ.Controllers
{
    public class RubrosNIFController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion


        #region "Constructor"
        public RubrosNIFController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método que se ejecuta al inicio y carga la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboNIFTipo();
                listarComboNIFNivel();
                List<Rubros_NIF> liLista = new List<Rubros_NIF>();
                liLista = _context.Rubros_NIF.Include(c=> c.NIF_Nivel).Include(c=> c.NIF_Tipo).AsNoTracking().Where(p => p.Habilitado == true).ToList();
                return View(liLista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Carga de datos"
        //Método para cargar el nivel NIF
        public void listarComboNIFNivel()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.NIF_Nivel.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idNIFNivel.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione el nivel-",
                    Value = ""
                });
                ViewBag.listaNIFNivel = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar el tipo NIF
        public void listarComboNIFTipo()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.NIF_Tipo.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idNIFTipo.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione el tipo-",
                    Value = ""
                });
                ViewBag.listaNIFTipo = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Metodo para filtrar la tabla con respecto al buscador
        public ActionResult Filtro(string Buscador, string datosFiltro) //Filtro por textbox
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Rubros_NIF> liListarRubrosNIF= new List<Rubros_NIF>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarRubrosNIF = _context.Rubros_NIF.Include(c => c.NIF_Nivel).Include(c=> c.NIF_Tipo).Where(p => p.Habilitado == true).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica
                    sbConsulta.Remove(0, sbConsulta.Length);
                    sbConsulta.AppendLine("SELECT RN.idRubroNIF, RN.Codigo, RN.Nombre, RN.fkNIFTipo, RN.fkNIFNivel, RN.fkUsuarioCr, ");
                    sbConsulta.AppendLine("RN.fechaCr, RN.Habilitado, RN.fkUsuarioUm, RN.fechaUm FROM Rubros_NIF AS RN ");
                    sbConsulta.AppendLine("  INNER JOIN NIF_Nivel AS N ON RN.fkNIFNivel = N.idNIFNivel ");
                    sbConsulta.AppendLine("  INNER JOIN NIF_Tipo AS T ON RN.fkNIFTipo = T.idNIFTipo WHERE RN.Habilitado = 1 AND (");
                    string Consult = sbConsulta.ToString();

                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            Consult += asArregloFiltro[i] + " LIKE '%" + Buscador + "%' OR ";
                        else
                            Consult += asArregloFiltro[i] + " LIKE '%" + Buscador + "%')";
                    }
                    liListarRubrosNIF = _context.Rubros_NIF.FromSqlRaw(Consult).Include(c => c.NIF_Nivel).Include(c=> c.NIF_Tipo).ToList();
                }
                return PartialView("_TablaRubrosNIF", liListarRubrosNIF);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Rubros_NIF rubrosNIF, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Rubros_NIF> liListarRubrosNIF = new List<Rubros_NIF>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListarRubrosNIF = _context.Rubros_NIF.Include(c => c.NIF_Tipo).Include(c=> c.NIF_Nivel).Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListarRubrosNIF.Where(p => p.Nombre.ToUpper() == rubrosNIF.Nombre.ToUpper() //Validar repetidos
                                    || p.Codigo.ToUpper() == rubrosNIF.Codigo.ToUpper()).Count();
                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            rubrosNIF.Habilitado = true;
                            rubrosNIF.fechaCr = DateTime.Now;
                            rubrosNIF.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Rubros_NIF.Add(rubrosNIF);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListarRubrosNIF = _context.Rubros_NIF.Include(c => c.NIF_Nivel).Include(c=>c.NIF_Tipo).Where(p => p.Habilitado == true && p.idRubroNIF != id).ToList();
                        inCantidad = liListarRubrosNIF.Where(p => p.Nombre.ToUpper() == rubrosNIF.Nombre.ToUpper() //Validar repetidos
                                    || p.Codigo.ToUpper() == rubrosNIF.Codigo.ToUpper()).Count();
                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            var vaObj = _context.Rubros_NIF.Find(id);
                            vaObj.Codigo = rubrosNIF.Codigo;
                            vaObj.Nombre = rubrosNIF.Nombre;
                            vaObj.fkNIFTipo = rubrosNIF.fkNIFTipo;
                            vaObj.fkNIFNivel = rubrosNIF.fkNIFNivel;
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

        //Método para deshabilitar el registro
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaObj = _context.Rubros_NIF.Find(id);
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
                var vaRubrosNIF = _context.Rubros_NIF.Find(id);
                return Ok(vaRubrosNIF);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

    }
}
