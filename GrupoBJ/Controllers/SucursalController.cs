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
    public class SucursalController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        #endregion

        #region "Constructor"

        public SucursalController(GrupoBJDBContext context)
        {
            _context = context;
        }

        #endregion

        #region "Load"
        //Método que se ejecuta la incio y carga la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboPais();
                listarComboEstado();
                listarComboCiudad();
                listarComboEmpresa();
                listarComboFiltro();
                List<Sucursal> liListaSucursal = new List<Sucursal>();
                liListaSucursal = _context.Sucursal.Include
                    (c => c.Empresa).AsNoTracking().ToList(); //Incluir la información de la empresa (Relacion)
                liListaSucursal = liListaSucursal.Where(p => p.Habilitado == true).ToList();

                return View(liListaSucursal);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        #endregion

        #region "Carga de datos"

        //Método para cargar el país
        public void listarComboPais()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Pais.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idPais.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem { Selected = true, Disabled = true, 
                    Text = "--Seleccione un país--", Value = "" });
                ViewBag.listaPais = liLista;
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        //Método para cargar el estado
        public void listarComboEstado()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Estado.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idEstado.ToString()
                                      }).ToList();
                ViewBag.listaEstado = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar la ciudad
        public void listarComboCiudad()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Ciudad.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idCiudad.ToString()
                                      }).ToList();
                ViewBag.listaCiudad = liLista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Método para cargar la empresa
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

        //Método para cargar el combo filtro
        public void listarComboFiltro() //AQUI
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
                ViewBag.listaFiltro = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Método para filtrar la tabla
        public ActionResult Filtro(string BuscadorSucursal, int? filtroCombo, string datosFiltro) //Filtro por textbox (AQUI)
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Sucursal> liListarSucursal = new List<Sucursal>();

                if (filtroCombo == null)
                {
                    //Creación de la consulta de filtro dinámica sin combo filtro
                    string consultaLike = "SELECT idSucursal, fkEmpresa, S.Nombre, S.Telefono, S.codigoPostal, S.Celular, S.Fax, S.Calle, S.Colonia, S.numeroInterior, " +
                        "S.numeroExterior, S.Cardinalidad, S.fkCiudad, S.Habilitado, S.fechaCr, S.fechaUm, S.fkUsuarioCr, S.fkUsuarioUm FROM Sucursal AS S " +
                        "INNER JOIN Empresa AS E ON S.fkEmpresa = E.idEmpresa WHERE S.Habilitado = 1 AND (";

                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorSucursal + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorSucursal + "%')";
                    }
                    liListarSucursal = _context.Sucursal.FromSqlRaw(consultaLike).Include(c => c.Empresa).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica sin combo filtro 
                    string consultaLike = "SELECT idSucursal, fkEmpresa, S.Nombre, S.Telefono, S.codigoPostal, S.Celular, S.Fax, S.Calle, S.Colonia, S.numeroInterior, " +
                        "S.numeroExterior, S.Cardinalidad, S.fkCiudad, S.Habilitado, S.fechaCr, S.fechaUm, S.fkUsuarioCr, S.fkUsuarioUm FROM Sucursal AS S " +
                        "INNER JOIN Empresa AS E ON S.fkEmpresa = E.idEmpresa WHERE S.Habilitado = 1 AND fkEmpresa = "+filtroCombo+ " AND (";

                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorSucursal + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorSucursal + "%')";
                    }
                    liListarSucursal = _context.Sucursal.FromSqlRaw(consultaLike).Include(c => c.Empresa).ToList();
                }                
                return PartialView("_TablaSucursal", liListarSucursal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos (Insertar o eliminar)
        [HttpPost]
        public string Guardar(Sucursal sucursal, int? id, int fkEmpresa)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Sucursal> liListaSucursal = new List<Sucursal>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaSucursal = _context.Sucursal.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaSucursal.Where(p => p.Nombre.ToUpper() == sucursal.Nombre.ToUpper() 
                        && p.fkEmpresa == fkEmpresa).Count(); //Validación por nombre de la empresa
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            sucursal.Habilitado = true;
                            sucursal.fechaCr = DateTime.Now;
                            sucursal.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Sucursal.Add(sucursal);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListaSucursal = _context.Sucursal.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaSucursal.Where(p => p.Nombre.ToUpper() == sucursal.Nombre.ToUpper() 
                        && p.fkEmpresa == fkEmpresa && 
                        p.idSucursal != id).Count(); //Validación de registro no repetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var vaObj = _context.Sucursal.Find(id);
                            vaObj.Nombre = sucursal.Nombre;
                            vaObj.codigoPostal = sucursal.codigoPostal;
                            vaObj.Calle = sucursal.Calle;
                            vaObj.Colonia = sucursal.Colonia;
                            vaObj.numeroExterior = sucursal.numeroExterior;
                            vaObj.numeroInterior = sucursal.numeroInterior;
                            vaObj.Telefono = sucursal.Telefono;
                            vaObj.Celular = sucursal.Celular;
                            vaObj.Fax = sucursal.Fax;
                            vaObj.fkCiudad = sucursal.fkCiudad;
                            vaObj.fkEmpresa = sucursal.fkEmpresa;
                            vaObj.Cardinalidad = sucursal.Cardinalidad;
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

        //Método para deshabilitar un registro cuando se va a eliminar
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaObj = _context.Sucursal.Find(id);
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
                var vaSucursal = _context.Sucursal.Find(id);
                return Ok(vaSucursal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para recuperar los datos de la relación anterior (Empresa)
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

        //-----------------------Recuperar datos para modificar------------------
        public IActionResult recuperarDatosCiudad(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Find(id);
                return Ok(vaCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult recuperarDatosEstado(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Find(id);
                return Ok(vaCiudad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult recuperarDatosPais(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Find(id);
                var vaEstado = _context.Estado.Find(vaCiudad.fkEstado);
                return Ok(vaEstado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //------------------------------Cargar los datos de ciudad y estado-----------------------------------------
        public IActionResult actualizarEstado(int id)
        {
            try
            {
                var vaEstado = _context.Estado.Where(p => p.fkPais == id && p.Habilitado == true).ToList();
                return Ok(vaEstado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult actualizarCiudad(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Where(p => p.fkEstado == id && p.Habilitado == true).ToList();
                return Ok(vaCiudad);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para validar las relaciones que tiene sucursal
        public int verificarRelaciones(int id)
        {
            try
            {
                var vaEmpleado = _context.Empleado.Where(p => p.fkSucursal == id && p.Habilitado == true).Count();
                if (vaEmpleado == 0)
                {
                    var vaColeccion = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkSucursal == id && p.Habilitado == true).Count();
                    return vaColeccion;
                }else
                    return vaEmpleado;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Método para recuperar los datos del registro a eliminar
        public IActionResult recuperarDatosEliminar(int id)
        {
            try
            {
                var vaSucursal = _context.Sucursal.Include(c=> c.Empresa).Where(p=>p.idSucursal == id && p.Habilitado == true).ToList();
                return Ok(vaSucursal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
