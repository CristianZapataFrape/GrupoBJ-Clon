using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Filters;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrupoBJ.Controllers
{
    [Acceder]

    public class BancoController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        #endregion

        #region "Constructor"
        public BancoController(GrupoBJDBContext context)
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
                List<Banco> liLista = new List<Banco>();
                liLista = _context.Banco.AsNoTracking().Where(p => p.Habilitado == true).ToList();
                return View(liLista);
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
                List<Banco> liListarBanco = new List<Banco>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarBanco = _context.Banco.Where(p => p.Habilitado == true).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica
                    string consultaLike = "SELECT * FROM Banco WHERE Habilitado = 1 AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + Buscador + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + Buscador + "%')";
                    }


                    liListarBanco = _context.Banco.FromSqlRaw(consultaLike).ToList();
                }
                return PartialView("_TablaBanco", liListarBanco);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Banco banco, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Banco> liListarBanco = new List<Banco>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListarBanco = _context.Banco.Where(p => p.Habilitado == true).ToList();
                        if (banco.RFC != null)
                        {
                            inCantidad = liListarBanco.Where(p => p.Nombre.ToUpper() == banco.Nombre.ToUpper() //Validar repetidos
                                        || p.Codigo.ToUpper() == banco.Codigo.ToUpper()
                                        || p.Clave.ToUpper() == banco.Clave.ToUpper() 
                                        || p.RFC == banco.RFC).Count();
                        }
                        else
                        {
                            inCantidad = liListarBanco.Where(p => p.Nombre.ToUpper() == banco.Nombre.ToUpper() //Validar repetidos
                                        || p.Codigo.ToUpper() == banco.Codigo.ToUpper()
                                        || p.Clave.ToUpper() == banco.Clave.ToUpper()).Count();
                        }
                                               
                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            banco.Habilitado = true;
                            banco.fechaCr = DateTime.Now;
                            banco.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Banco.Add(banco);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListarBanco = _context.Banco.Where(p => p.Habilitado == true && p.idBanco != id).ToList();
                        if (banco.RFC != null)
                        {
                            inCantidad = liListarBanco.Where(p => p.Nombre.ToUpper() == banco.Nombre.ToUpper() //Validar repetidos
                                        || p.Codigo.ToUpper() == banco.Codigo.ToUpper()
                                        || p.Clave.ToUpper() == banco.Clave.ToUpper()
                                        || p.RFC == banco.RFC).Count();
                        }
                        else
                        {
                            inCantidad = liListarBanco.Where(p => p.Nombre.ToUpper() == banco.Nombre.ToUpper() //Validar repetidos
                                        || p.Codigo.ToUpper() == banco.Codigo.ToUpper()
                                        || p.Clave.ToUpper() == banco.Clave.ToUpper()).Count();
                        }
                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            var vaObj = _context.Banco.Find(id);
                            vaObj.Codigo = banco.Codigo;
                            vaObj.Nombre = banco.Nombre;
                            vaObj.Clave = banco.Clave;
                            vaObj.paginaWeb = banco.paginaWeb;
                            vaObj.esBancoExtranjero = banco.esBancoExtranjero;
                            vaObj.RFC = banco.RFC;
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
                var vaObj = _context.Banco.Find(id);
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
                var vaBanco = _context.Banco.Find(id);
                return Ok(vaBanco);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para validar las relaciones que tiene empresa
        public int verificarRelacionesBanco(int id)
        {
            try
            {
                var vaEmpleado = _context.Empleado.Where(p => p.fkBanco == id && p.Habilitado == true).Count();
                    return vaEmpleado;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion
    }
}
