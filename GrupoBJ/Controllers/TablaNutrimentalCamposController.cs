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
    public class TablaNutrimentalCamposController : Controller
    {
        //[Acceder]

        private readonly GrupoBJDBContext _context;
        public TablaNutrimentalCamposController(GrupoBJDBContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            List<Tabla_Nutrimental_Campos> listaTablaNutrimentalCampos = new List<Tabla_Nutrimental_Campos>();
            listaTablaNutrimentalCampos = _context.Tabla_Nutrimental_Campos.Where(c=>c.id_Tabla_Nutrimental==id).ToList();
            return View(listaTablaNutrimentalCampos);
        }

        [HttpPost]
        public ActionResult Busqueda(string BuscadorCampo)
        {
            try
            {
                List<Tabla_Nutrimental_Campos> listaCampos = new List<Tabla_Nutrimental_Campos>();
                listaCampos = _context.Tabla_Nutrimental_Campos.ToList();
                if (!string.IsNullOrEmpty(BuscadorCampo))
                {
                    BuscadorCampo = BuscadorCampo.ToUpper();
                    listaCampos = listaCampos.Where(
                        s => s.Nombre_Tabla_Nutrimental_Campos.ToUpper().Contains(BuscadorCampo) ||
                        s.id_Tabla_Nutrimental_Campos.ToString().ToUpper().Contains(BuscadorCampo)
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
        public string Guardar(Tabla_Nutrimental_Campos tablaNutrimentaCampos, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string rpta = "";
                if (ModelState.IsValid)
                {
                    int cantidad = 0;
                    List<Tabla_Nutrimental_Campos> listaTablaNutrimentalCampos = new List<Tabla_Nutrimental_Campos>();
                    if (id.Equals(-1)) //Insertar
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
                            tablaNutrimentaCampos.fechaCr = DateTime.Now;
                            tablaNutrimentaCampos.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Tabla_Nutrimental_Campos.Add(tablaNutrimentaCampos);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        listaTablaNutrimentalCampos = _context.Tabla_Nutrimental_Campos.Where(p => p.id_Tabla_Nutrimental_Campos != id).ToList();
                        cantidad = listaTablaNutrimentalCampos.Where(p => p.Nombre_Tabla_Nutrimental_Campos.ToUpper() == tablaNutrimentaCampos.Nombre_Tabla_Nutrimental_Campos.ToUpper()).Count(); //Validación de registro no repetido
                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var obj = _context.Tabla_Nutrimental_Campos.Find(id);
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
                var obj = _context.Tabla_Nutrimental_Campos.Find(id);
                //obj.Habilitado = false;
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
                var campos = _context.Tabla_Nutrimental_Campos.Find(id);
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
