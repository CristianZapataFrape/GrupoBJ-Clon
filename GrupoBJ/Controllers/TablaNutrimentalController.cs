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
    public class TablaNutrimentalController : Controller
    {
        private readonly GrupoBJDBContext _context;
        public TablaNutrimentalController(GrupoBJDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            listarComboSMercado();
            List<Tabla_Nutrimental> listaArticulos = new List<Tabla_Nutrimental>();
            listaArticulos = _context.Tabla_Nutrimental.Include(c=>c.Carateristica_Valores).AsNoTracking().Where(p => p.Activo == true).ToList();


            return View(listaArticulos);
        }





        [HttpPost]
        public ActionResult Busqueda(string BuscadorArticulo)
        {
            try
            {
                List<Tabla_Nutrimental> listaArticulos = new List<Tabla_Nutrimental>();
                listaArticulos = _context.Tabla_Nutrimental.Include(c => c.Carateristica_Valores).AsNoTracking().Where(p => p.Activo == true).ToList();
                if (!string.IsNullOrEmpty(BuscadorArticulo))
                {
                    BuscadorArticulo = BuscadorArticulo.ToUpper();
                    listaArticulos = listaArticulos.Where(
                        s => s.Nombre_Tabla_Nutrimental.ToUpper().Contains(BuscadorArticulo) ||
                        s.id_Tabla_Nutrimental.ToString().ToUpper().Contains(BuscadorArticulo) ||
                        s.fechaCr.ToString().ToUpper().Contains(BuscadorArticulo) ||
                         s.fechaUm.ToString().ToUpper().Contains(BuscadorArticulo)
                    ).ToList();
                }
                return PartialView("_TablaNutrimentalMaestro", listaArticulos);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult BusquedaCampos(string BuscadorArticulo2,int id2)
        {
            try
            {
                List<Tabla_Nutrimental_Campos> listaCampos = new List<Tabla_Nutrimental_Campos>();
                listaCampos = _context.Tabla_Nutrimental_Campos.Where(c=>c.id_Tabla_Nutrimental==id2).ToList();
                if (!string.IsNullOrEmpty(BuscadorArticulo2))
                {
                    BuscadorArticulo2 = BuscadorArticulo2.ToUpper();
                    listaCampos = listaCampos.Where(
                        s => s.Nombre_Tabla_Nutrimental_Campos.ToUpper().Contains(BuscadorArticulo2) ||
                        s.id_Tabla_Nutrimental_Campos.ToString().ToUpper().Contains(BuscadorArticulo2)
                    ).ToList();
                }
                return PartialView("_TablaNutrimentalCamposMaestra", listaCampos);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Tabla_Nutrimental tablaNutrimental, int? id,bool chActivo)
        {
            try
            {
               // tablaNutrimental.id_Carateristica_Valores = 1;
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string rpta = "";
                if (ModelState.IsValid)
                {
                    int cantidad = 0;
                    List<Tabla_Nutrimental> listaTablaNutrimental = new List<Tabla_Nutrimental>();
                    if (id.Equals(-1)) //Insertar
                    {

                        listaTablaNutrimental = _context.Tabla_Nutrimental.ToList();
                        cantidad = listaTablaNutrimental.Where((p => p.Nombre_Tabla_Nutrimental.ToUpper() == tablaNutrimental.Nombre_Tabla_Nutrimental.ToUpper())).Count(); //Validación por nombre de la empresa

                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {

                            tablaNutrimental.Activo = chActivo;
                            tablaNutrimental.fechaCr = DateTime.Now;
                            tablaNutrimental.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Tabla_Nutrimental.Add(tablaNutrimental);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        listaTablaNutrimental = _context.Tabla_Nutrimental.Where(p => p.id_Tabla_Nutrimental != id).ToList();
                        cantidad = listaTablaNutrimental.Where(p => p.Nombre_Tabla_Nutrimental.ToUpper() == tablaNutrimental.Nombre_Tabla_Nutrimental.ToUpper()).Count(); //Validación de registro no repetido
                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var obj = _context.Tabla_Nutrimental.Find(id);
                            obj.Nombre_Tabla_Nutrimental = tablaNutrimental.Nombre_Tabla_Nutrimental;
                            obj.Activo = chActivo;
                            obj.id_Carateristica_Valores = tablaNutrimental.id_Carateristica_Valores;
                            obj.fechaUm = DateTime.Now;
                            obj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    var query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    rpta += "<ul class='list-group'>";
                    query.Sort();
                    rpta += "<li class='list-group-item'>" + query[0].ToString() + "</li>";
                    rpta += "</ul>";
                    return rpta;
                }
            }
            catch (Exception)
            {

                return "";
            }
        }


        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string GuardarCampos(Tabla_Nutrimental_Campos tablaNutrimentaCampos,string Nombre_Articulo_Campos, int id_Maestro,int? id_Detalle)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string rpta = "";
                if (!ModelState.IsValid)
                {
                    tablaNutrimentaCampos.Nombre_Tabla_Nutrimental_Campos = Nombre_Articulo_Campos;
                    int cantidad = 0;
                    List<Tabla_Nutrimental_Campos> listaTablaNutrimentalCampos = new List<Tabla_Nutrimental_Campos>();
                    if (id_Detalle.Equals(-1)) //Insertar
                    {
                       
                        listaTablaNutrimentalCampos = _context.Tabla_Nutrimental_Campos.ToList();
                        cantidad = listaTablaNutrimentalCampos.Where((p => p.Nombre_Tabla_Nutrimental_Campos.ToUpper() == tablaNutrimentaCampos.Nombre_Tabla_Nutrimental_Campos.ToUpper())).Count(); //Validación por nombre de la empresa

                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            // tablaNutrimentaCampos.Habilitado = true;
                            tablaNutrimentaCampos.id_Tabla_Nutrimental = id_Maestro;
                            tablaNutrimentaCampos.fechaCr = DateTime.Now;
                            tablaNutrimentaCampos.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Tabla_Nutrimental_Campos.Add(tablaNutrimentaCampos);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        listaTablaNutrimentalCampos = _context.Tabla_Nutrimental_Campos.Where(p => p.id_Tabla_Nutrimental_Campos != id_Detalle).ToList();
                        cantidad = listaTablaNutrimentalCampos.Where(p => p.Nombre_Tabla_Nutrimental_Campos.ToUpper() == tablaNutrimentaCampos.Nombre_Tabla_Nutrimental_Campos.ToUpper()).Count(); //Validación de registro no repetido
                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var obj = _context.Tabla_Nutrimental_Campos.Find(id_Detalle);
                            obj.Nombre_Tabla_Nutrimental_Campos = tablaNutrimentaCampos.Nombre_Tabla_Nutrimental_Campos;
                            obj.fechaUm = DateTime.Now;
                            obj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    var query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    rpta += "<ul class='list-group'>";
                    query.Sort();
                    rpta += "<li class='list-group-item'>" + query[0].ToString() + "</li>";
                    rpta += "</ul>";
                    return rpta;
                }
            }
            catch (Exception)
            {

                return "";
            }
        }
        //Método para deshabilitar el registro
        public string eliminar(int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var obj = _context.Tabla_Nutrimental.Find(id);
                obj.Activo = false;
                obj.fechaUm = DateTime.Now;
                obj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }


        //Método para recuperar los datos del registro seleccionado
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var campos = _context.Tabla_Nutrimental.Find(id);
                return Ok(campos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult recuperarDatosCampos(int id)
        {
            try
            {
                var campos = _context.Tabla_Nutrimental_Campos.Find(id);
                return Ok(campos);
            }
            catch (Exception)
            {
                throw;
            }
        }



        //Método para llenar el combo de Mercado del modal
        public void listarComboSMercado()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 1).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un sistema--",
                    Value = ""
                });
                ViewBag.listaMercado = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
