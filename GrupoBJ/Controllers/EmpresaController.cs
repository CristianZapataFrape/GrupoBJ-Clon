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
    public class EmpresaController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        public string[] asArregloColumnas;
        #endregion

        #region "Constructor"
        public EmpresaController(GrupoBJDBContext context)
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
                listarComboPais();
                listarComboEstado();
                listarComboCiudad();
                listarMoneda();
                List<Empresa> liListarEmpresa = new List<Empresa>();
                liListarEmpresa = _context.Empresa.Where(p => p.Habilitado == true).ToList();
                return View(liListarEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Carga de datos"
        //Método para el llenado del combo de Moneda
        public void listarMoneda()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Moneda.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idMoneda.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem { Selected = true, Disabled = true, 
                    Text = "--Seleccione una moneda--", Value = "" });
                ViewBag.listaMoneda = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Pais
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

        //Método para llenar el combo estado
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

        //Método para llenar el combo de ciudad
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

        #endregion

        #region "Funciones CRUD"
        //Método para filtrar la tabla con respecto a lo escrito en el buscador
        public ActionResult Filtro(string BuscadorEmpresa, string datosFiltro) //Filtro por textbox
        {
            
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Empresa> liListarEmpresa = new List<Empresa>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarEmpresa = _context.Empresa.Where(p => p.Habilitado == true).ToList();
                }else
                {
                    //Creación de la consulta de filtro dinámica
                    string consultaLike = "SELECT * FROM Empresa WHERE Habilitado = 1 AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorEmpresa + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorEmpresa + "%')";
                    }


                    liListarEmpresa = _context.Empresa.FromSqlRaw(consultaLike).ToList();
                }
                return PartialView("_TablaEmpresa", liListarEmpresa);           
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Empresa empresa, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Empresa> liListarEmpresa = new List<Empresa>();
                    if (id.Equals(-1)) //Insertar
                    {

                        liListarEmpresa = _context.Empresa.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListarEmpresa.Where((p => p.Nombre.ToUpper() == empresa.Nombre.ToUpper() 
                        || p.RFC.ToUpper() == empresa.RFC.ToUpper() ||
                        p.razonSocial.ToUpper() == empresa.razonSocial.ToUpper())).Count(); //Validación por nombre de la empresa

                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            empresa.Habilitado = true;
                            empresa.fechaCr = DateTime.Now; 
                            empresa.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Empresa.Add(empresa);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListarEmpresa = _context.Empresa.Where(p => p.Habilitado == true && p.idEmpresa != id).ToList();
                        inCantidad = liListarEmpresa.Where(p => p.Nombre.ToUpper() == empresa.Nombre.ToUpper() 
                        || p.RFC.ToUpper() == empresa.RFC.ToUpper() ||
                         p.razonSocial.ToUpper() == empresa.razonSocial.ToUpper()).Count(); //Validación de registro no repetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var vaObj = _context.Empresa.Find(id);
                            vaObj.Nombre = empresa.Nombre;
                            vaObj.razonSocial = empresa.razonSocial;
                            vaObj.RFC = empresa.RFC;
                            vaObj.codigoPostal = empresa.codigoPostal;
                            vaObj.Calle = empresa.Calle;
                            vaObj.Colonia = empresa.Colonia;
                            vaObj.numeroExterior = empresa.numeroExterior;
                            vaObj.numeroInterior = empresa.numeroInterior;
                            vaObj.Telefono = empresa.Telefono;
                            vaObj.Celular = empresa.Celular;
                            vaObj.Fax = empresa.Fax;
                            vaObj.fkCiudad = empresa.fkCiudad;
                            vaObj.fkMoneda = empresa.fkMoneda;
                            vaObj.Cardinalidad = empresa.Cardinalidad;
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
                var vaObj = _context.Empresa.Find(id);
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
                var vaEmpresa = _context.Empresa.Find(id);
                return Ok(vaEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //-----------------------Recuperar datos para editar------------------

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

        //----------------------------------------------------------------------------------

        

        //Método para validar las relaciones que tiene empresa
        public int verificarRelaciones(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Where(p => p.fkEmpresa == id && p.Habilitado == true).Count();
                if (vaDepartamento == 0)
                {
                    var vaSucursal = _context.Sucursal.Where(p => p.fkEmpresa == id && p.Habilitado == true).Count();
                    if (vaSucursal == 0)
                    {
                        var vaColeccion = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkEmpresa == id && p.Habilitado == true).Count();
                        return vaColeccion;
                    }
                    return vaSucursal;
                }
                else
                    return vaDepartamento;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #endregion



    }
}
