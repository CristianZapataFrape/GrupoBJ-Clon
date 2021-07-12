using GrupoBJ.DataBase;
using GrupoBJ.Filters;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class ProveedorController : Controller
    {
        #region"Variables Globales"
        private readonly GrupoBJDBContext _context;
        public string[] asArregloColumnas;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion

        #region"Constructor"
        public ProveedorController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Index"
        [HttpGet]
        public IActionResult Index(string filtro)
        {
            try
            {
                List<Proveedorcs> liListarProveedor = new List<Proveedorcs>();
                liListarProveedor = _context.Proveedor.Where(p => p.Habilitado == true).ToList();
                return View(liListarProveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Funciones CRUD"
        //Funcion para el filtro de busqueda dinamico de proveedor
        public ActionResult Filtro(string BuscadorProveedor, string datosFiltro) //Filtro por textbox
        {

            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Proveedorcs> liListarProveedor = new List<Proveedorcs>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarProveedor = _context.Proveedor.Where(p => p.Habilitado == true).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica
                    sbConsulta.Remove(0, sbConsulta.Length);
                    sbConsulta.AppendLine("SELECT * FROM Proveedor WHERE Habilitado = 1 AND (");
                    string consultaLike = sbConsulta.ToString();
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorProveedor + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorProveedor + "%')";
                    }


                    liListarProveedor = _context.Proveedor.FromSqlRaw(consultaLike).ToList();
                }
                return PartialView("_TablaProveedor", liListarProveedor);
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Funcion para agregar o actualizar datos del proveedor
        [HttpPost]
        public string Guardar(Proveedorcs Proveedor, int? id)
        {
            try
            {
                //int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string Rpta = "";

                if (ModelState.IsValid)
                {
                    int Cantidad = 0;
                    List<Proveedorcs> liListarProveedor = new List<Proveedorcs>();
                    if (id.Equals(-1)) //insertar
                    {
                        liListarProveedor = _context.Proveedor.Where(p => p.Habilitado == true).ToList();
                        Cantidad = liListarProveedor.Where(p => p.Nombre.ToUpper() == Proveedor.Nombre.ToUpper()
                        && p.ApPaterno.ToUpper() == Proveedor.ApPaterno.ToUpper()
                        && p.Razon_Social.ToUpper() == Proveedor.Razon_Social.ToUpper()
                        && p.RFC.ToUpper() == Proveedor.RFC.ToUpper()).Count();

                        if (Cantidad >= 1)//En caso de que exista algun registro repetido
                        {
                            return "-1"; //el registro se encuenta en la base de datos
                        }
                        else
                        {
                            Proveedor.Habilitado = true;
                            Proveedor.FechaCr = DateTime.Now;
                            _context.Proveedor.Add(Proveedor);//Agrega los datos a la BD
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else // Moodifica el dato existente
                    {
                        liListarProveedor = _context.Proveedor.Where(p => p.Habilitado == true).ToList();
                        //Cantidad = liListarProveedor.Where(p => p.Nombre.ToUpper() == Proveedor.Nombre.ToUpper()
                        //&& p.ApPaterno.ToUpper() == Proveedor.ApPaterno.ToUpper()
                        //&& p.Razon_Social.ToUpper() == Proveedor.Razon_Social.ToUpper()
                        //&& p.RFC.ToUpper() == Proveedor.RFC.ToUpper()).Count();

                        if (Cantidad >= 1)
                        {
                            return "-1";
                        }
                        else
                        {
                            var oProveedor = _context.Proveedor.Find(id);
                            oProveedor.Nombre = Proveedor.Nombre;
                            oProveedor.ApPaterno = Proveedor.ApPaterno;
                            oProveedor.ApMaterno = Proveedor.ApMaterno;
                            oProveedor.Telefono = Proveedor.Telefono;
                            oProveedor.Correo = Proveedor.Correo;
                            oProveedor.Calle = Proveedor.Calle;
                            oProveedor.Ciudad = Proveedor.Ciudad;
                            oProveedor.Estado = Proveedor.Estado;
                            oProveedor.Pais = Proveedor.Pais;
                            oProveedor.Codigo_Postal = Proveedor.Codigo_Postal;
                            oProveedor.Razon_Social = Proveedor.Razon_Social;
                            oProveedor.RFC = Proveedor.RFC;
                            oProveedor.Cuenta = Proveedor.Cuenta;
                            oProveedor.Tiempo_Entrega = Proveedor.Tiempo_Entrega;
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    var Query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    Rpta += "<ul class='list-group'>";
                    Query.Sort();
                    Rpta += "<li class='list-group-item'>" + Query[0].ToString() + "</li>";
                    Rpta += "</ul>";
                    return Rpta;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para deshabilitar el registro
        public string eliminar(int id)
        {
            try
            {
                //int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var oProveedor = _context.Proveedor.Find(id);
                oProveedor.Habilitado = false;
                //vaObj.fechaUm = DateTime.Now;
                //vaObj.fkUsuarioUm = fkUsuarioLogin; Se reemplaza por el usuario que se logueo
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Query"
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaProveedor = _context.Proveedor.Find(id);
                return Ok(vaProveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}