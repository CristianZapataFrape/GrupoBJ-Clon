using Microsoft.AspNetCore.Mvc;
using GrupoBJ.DataBase;
using GrupoBJ.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.Models;
using Microsoft.EntityFrameworkCore;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class ClienteController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
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

                
                listaClientes = _context.Cliente.Where(p => p.Habilitado == true).ToList();
                
                
               
            }
            catch (Exception)
            {

                throw;
            }

            return View(listaClientes);
          
        }

        #region "Funciones CRUD"
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
                           p => (p.nombre.ToUpper() == oClienteCls.nombre.ToUpper()
                           && p.apPaterno.ToUpper() == oClienteCls.apPaterno.ToUpper()
                           && p.pais.ToUpper() == oClienteCls.pais.ToUpper()
                           && p.telefono == oClienteCls.telefono
                           && p.apMaterno.ToUpper() == oClienteCls.apMaterno.ToUpper())
                           && p.email.ToUpper() == oClienteCls.email.ToUpper()).Count();

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
                           p => (p.nombre.ToUpper() == oClienteCls.nombre.ToUpper()
                           && p.apPaterno.ToUpper() == oClienteCls.apPaterno.ToUpper()
                           && p.apMaterno.ToUpper() == oClienteCls.apMaterno.ToUpper())
                           && p.email.ToUpper() == oClienteCls.email.ToUpper()).Count();
                        if (incantidad >=1)
                        {
                            return "-1";
                        }
                        else
                        {
                            var oCliente = _context.Cliente.Find(id);
                            oCliente.nombre = oClienteCls.nombre;
                            oCliente.apPaterno = oClienteCls.apPaterno;
                            oCliente.apMaterno = oClienteCls.apMaterno;
                            oCliente.ciudad = oClienteCls.ciudad;
                            oCliente.CP = oClienteCls.CP;
                            oCliente.email = oClienteCls.email;
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
        #endregion

    }
}
