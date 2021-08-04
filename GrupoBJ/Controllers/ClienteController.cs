using Microsoft.AspNetCore.Mvc;
using GrupoBJ.DataBase;
using GrupoBJ.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class ClienteController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        public string[] asArregloColumnas;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion

        public ClienteController(GrupoBJDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<ClienteCls> listaClientes = new List<ClienteCls>();
            try
            {
                listarComboProveedor();
                listarComboPais();
                listarComboEstado();
                listarComboCiudad();
                //List<Empleado> liListaEmpleado = new List<Empleado>();
                //liListaEmpleado = _context.Empleado.Include
                //    (c => c.Sucursal.Empresa)
                //    .Include(c => c.Puesto.Departamento)
                //    .AsNoTracking().ToList(); //Incluir la información de la empresa (Relacion)
                //liListaEmpleado = liListaEmpleado.Where(p => p.Habilitado == true).ToList();
                //liLista = _context.Moneda.Include(c => c.MonedaSAT).AsNoTracking().Where(p => p.Habilitado == true).ToList();
                listaClientes = _context.Cliente.Include(c => c.Proveedor).AsNoTracking().Where(p => p.Habilitado == true).ToList();

                //listaClientes = _context.Cliente.Where(p => p.Habilitado == true).ToList();
                
                
               
            }
            catch (Exception)
            {

                throw;
            }

            return View(listaClientes);
          
        }

        #region "Funciones CRUD"
        //Funcion para el filtro de busqueda dinamico de proveedor
        public ActionResult Filtro(string BuscadorClientes, string datosFiltro) //Filtro por textbox
        {

            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<ClienteCls> liListarClientes = new List<ClienteCls>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarClientes = _context.Cliente.Where(p => p.Habilitado == true).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica
                    sbConsulta.Remove(0, sbConsulta.Length);
                    sbConsulta.AppendLine("SELECT * FROM Cliente WHERE Habilitado = 1 AND (");
                    string consultaLike = sbConsulta.ToString();
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorClientes + "%' OR ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorClientes + "%')";
                    }


                    liListarClientes = _context.Cliente.FromSqlRaw(consultaLike).ToList();
                }
                return PartialView("_TablaCliente", liListarClientes);
            }
            catch (Exception)
            {
                throw;
            }

        }




        //Funcion para agregar o actualizar datos del Cliente
        [HttpPost]
        public string Guardar(ClienteCls oClienteCls, int? id)
        {
            
            try
            {
                //int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int incantidad = 0;
                    List<ClienteCls> listaCliente = new List<ClienteCls>();
                    if (id.Equals(-1))//Insertar
                    {
                        listaCliente = _context.Cliente.Where(p => p.Habilitado == true).ToList();
                        incantidad = listaCliente.Where(
                           p => (p.Nombre.ToUpper() == oClienteCls.Nombre.ToUpper()
                           //&& p.apPaterno.ToUpper() == oClienteCls.apPaterno.ToUpper()
                           //&& p.fk_id_Pais== oClienteCls.fk_id_Pais
                           && p.fk_id_Ciudad == oClienteCls.fk_id_Ciudad
                           && p.nombreCompania.ToUpper() == oClienteCls.nombreCompania.ToUpper()
                           && p.CP.ToUpper() == oClienteCls.CP.ToUpper()
                           && p.razonSocial.ToUpper() == oClienteCls.razonSocial.ToUpper()
                           && p.fk_Id_Proveedor == oClienteCls.fk_Id_Proveedor
                           && p.rfcFacturacion.ToUpper() == oClienteCls.rfcFacturacion.ToUpper()
                           && p.domicilioFacturacion.ToUpper() == oClienteCls.domicilioFacturacion.ToUpper()
                           && p.Saldo == oClienteCls.Saldo
                           && p.Telefono == oClienteCls.Telefono
                           /*&& p.apMaterno.ToUpper() == oClienteCls.apMaterno.ToUpper()*/)
                           && p.Email.ToUpper() == oClienteCls.Email.ToUpper()).Count();

                        if (incantidad >=1)//En caso de que exista algun registro repetido
                        {
                            return "-1"; //El registro se encuentra en la base de datos
                        }
                        else
                        {
                            oClienteCls.Habilitado = true;
                            oClienteCls.FechaCr = DateTime.Now;
                            _context.Cliente.Add(oClienteCls);//Agrega los datos a la BD
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else //modifica el dato existente
                    {
                        listaCliente = _context.Cliente.Where(p => p.Habilitado == true).ToList();
                        incantidad = listaCliente.Where(
                           p => (p.Nombre.ToUpper() == oClienteCls.Nombre.ToUpper()
                           //&& p.apPaterno.ToUpper() == oClienteCls.apPaterno.ToUpper()
                           //&& p.fk_id_Pais == oClienteCls.fk_id_Pais
                           && p.fk_id_Ciudad == oClienteCls.fk_id_Ciudad
                           && p.nombreCompania.ToUpper() == oClienteCls.nombreCompania.ToUpper()
                           && p.CP.ToUpper() == oClienteCls.CP.ToUpper()
                           && p.razonSocial.ToUpper() == oClienteCls.razonSocial.ToUpper()
                           && p.rfcFacturacion.ToUpper() == oClienteCls.rfcFacturacion.ToUpper()
                           && p.domicilioFacturacion.ToUpper() == oClienteCls.domicilioFacturacion.ToUpper()
                           && p.fk_Id_Proveedor == oClienteCls.fk_Id_Proveedor
                           && p.Saldo == oClienteCls.Saldo
                           /*&& p.apMaterno.ToUpper() == oClienteCls.apMaterno.ToUpper()*/)
                           && p.Email.ToUpper() == oClienteCls.Email.ToUpper()).Count();
                        if (incantidad >=1)
                        {
                            return "-1";
                        }
                        else
                        {
                            var oCliente = _context.Cliente.Find(id);
                            oCliente.Nombre = oClienteCls.Nombre;
                            //oCliente.apPaterno = oClienteCls.apPaterno;
                            //oCliente.apMaterno = oClienteCls.apMaterno;
                            oCliente.fk_id_Ciudad = oClienteCls.fk_id_Ciudad;
                            //oCliente.fk_id_Pais = oClienteCls.fk_id_Pais;
                            oCliente.CP = oClienteCls.CP;
                            oCliente.Email = oClienteCls.Email;
                            oCliente.nombreCompania = oClienteCls.nombreCompania;
                            oCliente.CP = oClienteCls.CP;
                            oCliente.fk_Id_Proveedor = oClienteCls.fk_Id_Proveedor;
                            oCliente.razonSocial = oClienteCls.razonSocial;
                            oCliente.rfcFacturacion = oClienteCls.rfcFacturacion;
                            oCliente.domicilioFacturacion = oClienteCls.domicilioFacturacion;
                            oCliente.Saldo = oClienteCls.Saldo;
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
                    stRpta += "<ul class='list-group'>";
                    Query.Sort();
                    stRpta += "<li class='list-group-item'>" + Query[0].ToString() + "</li>";
                    stRpta += "</ul>";
                    return stRpta;
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            #endregion
            
        }


        [HttpPost]
        //Método para filtrar la tabla con el buscador y/o combo
        //public ActionResult Filtro(string BuscadorDepartamento, bool Habilitar, int? filtroCombo, string datosFiltro) //Filtro por textbox
        //{
        //    try
        //    {
        //        string consultaLike;
        //        string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
        //        List<ClienteCls> liListarCliente = new List<ClienteCls>();
        //        //Creación de la consulta de filtro dinámica sin combo filtro
        //        sbConsulta.AppendLine("SELECT id_Cliente, Nombre, apPaterno, apMaterno, Telefono, habilitado ");
        //        sbConsulta.AppendLine(" FROM Cliente");
        //        sbConsulta.AppendLine(" WHERE habilitado = 1 AND ");
        //        consultaLike = sbConsulta.ToString();


        //        if (filtroCombo == null)
        //        {
        //            consultaLike += "(";
        //            for (int i = 0; i < asArregloFiltro.Length; i++)
        //            {
        //                if (i != asArregloFiltro.Length - 1)
        //                    consultaLike += asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%' OR ";
        //                else
        //                    consultaLike += asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%')";
        //            }
        //            liListarCliente = _context.Cliente.FromSqlRaw(consultaLike).ToList();
        //        }
        //        else
        //        {
        //            consultaLike += "fkEmpresa = " + filtroCombo + " AND (";
        //            for (int i = 0; i < asArregloFiltro.Length; i++)
        //            {
        //                if (i != asArregloFiltro.Length - 1)
        //                    consultaLike += asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%' OR ";
        //                else
        //                    consultaLike += asArregloFiltro[i] + " LIKE '%" + BuscadorDepartamento + "%')";
        //            }
        //            liListarCliente = _context.Cliente.FromSqlRaw(consultaLike).ToList();
        //        }
        //        return PartialView("_TablaCliente", liListarCliente);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //Método para cargar los países
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
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un país--",
                    Value = ""
                });
                ViewBag.listaPais = liLista;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Método para cargar los estados
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


        //Método para cargar las ciudad
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



            //Método para cargar las empresas
            private void listarComboProveedor()
        {

            try
            {


                List<SelectListItem> liLista;
                liLista = _context.Proveedor.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.id_Proveedor.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un Proveedor--",
                    Value = ""
                });
                ViewBag.listaProveedor = liLista;
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
                var oProveedor = _context.Cliente.Find(id);
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

        #region "Query"
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaProveedor = _context.Cliente.Find(id);
                return Ok(vaProveedor);
            }
            catch (Exception)
            {

                throw;
            }
        }

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




        //Método para validar las relaciones que tiene empresa
        public int verificarRelacionesProveedor(int id)
        {
            try
            {
                var vaEmpresa = _context.Cliente.Where(p => p.fk_Id_Proveedor == id && p.Habilitado == true).Count();
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
