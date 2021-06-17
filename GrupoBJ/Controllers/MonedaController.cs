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
    public class MonedaController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        StringBuilder sbConsulta = new StringBuilder();

        #endregion

        #region "Constructor"
        public MonedaController(GrupoBJDBContext context)
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
                listarComboMonedaSAT();
                listarComboSimbolo();
                listarComboDecimales();
                listarComboPosicion();
                List<Moneda> liLista = new List<Moneda>();
                liLista = _context.Moneda.Include(c=> c.MonedaSAT).AsNoTracking().Where(p => p.Habilitado == true).ToList();
                return View(liLista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Carga de datos"
        //Método para cargar la empresa
        public void listarComboMonedaSAT()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.MonedaSAT.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Codigo,
                                          Value = x.idMonedaSAT.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione el código de moneda del SAT--",
                    Value = ""
                });
                ViewBag.listaMonedaSAT = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de símbolo de moneda
        public void listarComboSimbolo()
        {
            try
            {
                List<SelectListItem> liLista = new List<SelectListItem>();
                liLista = new List<SelectListItem>
                {
                    new SelectListItem {Text = "--Seleccione un símbolo de moneda--", Value="", Selected=true, Disabled=true},
                    new SelectListItem {Text = "$", Value = "$"},
                    new SelectListItem {Text = "€", Value = "€"},
                    new SelectListItem {Text = "£", Value = "£"}
                };
                ViewBag.listaSimbolo = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de decimales
        public void listarComboDecimales()
        {
            try
            {
                List<SelectListItem> liLista = new List<SelectListItem>();
                liLista = new List<SelectListItem>
                {
                    new SelectListItem {Text = "--Seleccione un dígito decimal--", Value="", Selected=true, Disabled=true},
                    new SelectListItem {Text = "0", Value = "0", Selected= true},
                    new SelectListItem {Text = "1", Value = "1"},
                    new SelectListItem {Text = "2", Value = "2"},
                    new SelectListItem {Text = "3", Value = "3"},
                    new SelectListItem {Text = "4", Value = "4"}
                };
                ViewBag.listaDecimales = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de posicion
        public void listarComboPosicion()
        {
            try
            {
                List<SelectListItem> liLista = new List<SelectListItem>();
                liLista = new List<SelectListItem>
                {
                    new SelectListItem {Text = "--Seleccione la posición del símbolo--", Value= "", Selected=true, Disabled=true},
                    new SelectListItem {Text = "Al inicio", Value = "1"},
                    new SelectListItem {Text = "Al final", Value = "2"}
                };
                ViewBag.listaPosicion = liLista;
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
                List<Moneda> liListarMoneda = new List<Moneda>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarMoneda = _context.Moneda.Include(c=> c.MonedaSAT).Where(p => p.Habilitado == true).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica
                    string consultaLike;
                    sbConsulta.Remove(0, sbConsulta.Length);
                    sbConsulta.AppendLine("SELECT M.idMoneda, M.fkUsuarioCr, M.Habilitado, M.Nombre, M.Simbolo, M.fechaCr, M.fechaUm, ");
                    sbConsulta.AppendLine("M.fkUsuarioUm, M.Codigo, M.Decimales, M.Posicion, M.fkMonedaSAT, M.nombrePlural, ");
                    sbConsulta.AppendLine("M.nombreSingular, M.textoFinal FROM Moneda AS M");
                    sbConsulta.AppendLine("INNER JOIN MonedaSAT AS MS ON M.fkMonedaSAT = MS.idMonedaSAT WHERE M.Habilitado = 1 AND (");
                    consultaLike = sbConsulta.ToString();

                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=   asArregloFiltro[i] + " LIKE '%" + Buscador + "%' OR ";
                        else
                            consultaLike +=   asArregloFiltro[i] + " LIKE '%" + Buscador + "%')";
                    }
                    liListarMoneda = _context.Moneda.FromSqlRaw(consultaLike).Include(c=> c.MonedaSAT).ToList();
                }
                return PartialView("_TablaMoneda", liListarMoneda);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Moneda moneda, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Moneda> liListarMoneda = new List<Moneda>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListarMoneda = _context.Moneda.Include(c=>c.MonedaSAT).Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListarMoneda.Where(p => p.Nombre.ToUpper() == moneda.Nombre.ToUpper() //Validar repetidos
                                    || p.Codigo.ToUpper() == moneda.Codigo.ToUpper()).Count();
                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            moneda.Habilitado = true;
                            moneda.fechaCr = DateTime.Now;
                            moneda.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Moneda.Add(moneda);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListarMoneda = _context.Moneda.Include(c => c.MonedaSAT).Where(p => p.Habilitado == true && p.idMoneda != id).ToList();
                        inCantidad = liListarMoneda.Where(p => p.Nombre.ToUpper() == moneda.Nombre.ToUpper() //Validar repetidos
                                    || p.Codigo.ToUpper() == moneda.Codigo.ToUpper()).Count();
                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            var vaObj = _context.Moneda.Find(id);
                            vaObj.Codigo = moneda.Codigo;
                            vaObj.Nombre = moneda.Nombre;
                            vaObj.Simbolo = moneda.Simbolo;
                            vaObj.Posicion = moneda.Posicion;
                            vaObj.Decimales = moneda.Decimales;
                            vaObj.nombreSingular = moneda.nombreSingular;
                            vaObj.nombrePlural = moneda.nombrePlural;
                            vaObj.textoFinal = moneda.textoFinal;
                            vaObj.fkMonedaSAT = moneda.fkMonedaSAT;
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
                var vaObj = _context.Moneda.Find(id);
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
                var vaMoneda = _context.Moneda.Find(id);
                return Ok(vaMoneda);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para validar las relaciones que tiene empresa
        public int verificarRelacionesMoneda(int id)
        {
            try
            {
                var vaEmpresa = _context.Empresa.Where(p => p.fkMoneda == id && p.Habilitado == true).Count();
                return vaEmpresa;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion


    }
}
