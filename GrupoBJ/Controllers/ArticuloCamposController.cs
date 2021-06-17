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
    public class ArticuloCamposController : Controller
    {
        //[Acceder]

        private readonly GrupoBJDBContext _context;
        public ArticuloCamposController(GrupoBJDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Articulos_Campos> listaArticulosCampos = new List<Articulos_Campos>();            
            listaArticulosCampos = _context.Articulos_Campos.Where(p=>p.Habilitado==true).ToList();

            List<Articulos_Campos_Vista> listaArticulosCamposVista = new List<Articulos_Campos_Vista>();
            for(int i = 0;i<listaArticulosCampos.Count;i++)
            {

            }

            return View(listaArticulosCampos);
        }

        [HttpPost]
        public ActionResult Busqueda(string BuscadorArticulo)
        {
            try
            {
                List<Articulos_Campos> listaArticulos = new List<Articulos_Campos>();
                listaArticulos = _context.Articulos_Campos.Where(p => p.Habilitado == true).ToList();
                if (!string.IsNullOrEmpty(BuscadorArticulo))
                {
                    BuscadorArticulo = BuscadorArticulo.ToUpper();
                    listaArticulos = listaArticulos.Where(
                        s => s.Nombre_Articulo_Campos.ToUpper().Contains(BuscadorArticulo) ||
                        s.idArticulos_Campos.ToString().ToUpper().Contains(BuscadorArticulo) ||
                        s.fechaCr.ToString().ToUpper().Contains(BuscadorArticulo) ||
                         s.fechaUm.ToString().ToUpper().Contains(BuscadorArticulo)
                    ).ToList();
                }
                return PartialView("_ArticuloCamposMaestro", listaArticulos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Articulos_Campos articulosCampos, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string rpta = "";
                if (ModelState.IsValid)
                {
                    int cantidad = 0;
                    List<Articulos_Campos> listaArticulosCampos = new List<Articulos_Campos>();
                    if (id.Equals(-1)) //Insertar
                    {

                        listaArticulosCampos = _context.Articulos_Campos.ToList();
                        cantidad = listaArticulosCampos.Where((p => p.Nombre_Articulo_Campos.ToUpper() == articulosCampos.Nombre_Articulo_Campos.ToUpper())).Count(); //Validación por nombre de la empresa

                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            articulosCampos.Habilitado = true;
                            articulosCampos.fechaCr = DateTime.Now;
                            articulosCampos.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Articulos_Campos.Add(articulosCampos);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        listaArticulosCampos = _context.Articulos_Campos.Where(p => p.idArticulos_Campos != id).ToList();
                        cantidad = listaArticulosCampos.Where(p => p.Nombre_Articulo_Campos.ToUpper() == articulosCampos.Nombre_Articulo_Campos.ToUpper()).Count(); //Validación de registro no repetido
                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var obj = _context.Articulos_Campos.Find(id);
                            obj.Nombre_Articulo_Campos = articulosCampos.Nombre_Articulo_Campos;                           
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
                var obj = _context.Articulos_Campos.Find(id);
                obj.Habilitado = false;
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
                var campos = _context.Articulos_Campos.Find(id);
                return Ok(campos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para validar las relaciones que tiene empresa
        public int verificarRelaciones(int id)
        {
            try
            {
                var Departamento = _context.Departamento.Where(p => p.fkEmpresa == id && p.Habilitado == true).Count();
                if (Departamento == 0)
                {
                    var Sucursal = _context.Sucursal.Where(p => p.fkEmpresa == id && p.Habilitado == true).Count();
                    if (Sucursal == 0)
                    {
                        var Coleccion = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkEmpresa == id && p.Habilitado == true).Count();
                        return Coleccion;
                    }
                    return Sucursal;
                }
                else
                    return Departamento;
            }
            catch (Exception)
            {
                return 0;
            }
        }



    }
}
