using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using Microsoft.AspNetCore.Mvc;
using GrupoBJ.Models.Contabilidad;
using GrupoBJ.Models;
using Microsoft.EntityFrameworkCore;
using GrupoBJ.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class ConceptosIETUController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        #endregion

        #region "Constructor"
        public ConceptosIETUController(GrupoBJDBContext context)
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
                listarComboTipoConceptoIETU();
                listarComboTipoConceptoIETU_IETU();
                listarComboTipoConceptoIETU_IVA();
                List<ConceptosIETU> liLista = new List<ConceptosIETU>();
                liLista = _context.ConceptosIETU.
                    Include(c => c.Tipo_ConceptosIETU_IETU).
                    Include(c => c.Tipo_ConceptosIETU_IVA).
                    Include(c=> c.Tipo_ConceptosIETU).
                    AsNoTracking().Where(p => p.Habilitado == true).ToList();
                return View(liLista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Carga de datos"
        //Método para cargar el tipo de concepto IETU
        public void listarComboTipoConceptoIETU()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Tipo_ConceptosIETU.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idTipoConceptoIETU.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione el tipo de concepto--",
                    Value = ""
                });
                ViewBag.listaTipoConceptoIETU = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para cargar el tipo de concepto IETU_IETU
        public void listarComboTipoConceptoIETU_IETU()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Tipo_ConceptosIETU_IETU.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idTipoConceptoIETU_IETU.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione para el IETU--",
                    Value = ""
                });
                ViewBag.listaTipoConceptoIETU_IETU = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar el tipo de concepto IETU_IETU
        public void listarComboTipoConceptoIETU_IVA()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Tipo_ConceptosIETU_IVA.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idTipoConceptoIETU_IVA.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione para el IVA--",
                    Value = ""
                });
                ViewBag.listaTipoConceptoIETU_IVA = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Metodo para filtrar la tabla con respecto al buscador
        public ActionResult Filtro(string Buscador) //Filtro por textbox
        {
            try
            {
                List<ConceptosIETU> liLista = new List<ConceptosIETU>();
                liLista = _context.ConceptosIETU.
                    Include(c => c.Tipo_ConceptosIETU_IETU).
                    Include(c=> c.Tipo_ConceptosIETU_IVA).
                    Include(c=> c.Tipo_ConceptosIETU).
                    AsNoTracking().Where(p => p.Habilitado == true).ToList();
                if (!string.IsNullOrEmpty(Buscador))
                {
                    Buscador = Buscador.ToUpper();
                    liLista = liLista.Where(
                        s => s.Codigo.ToUpper().Contains(Buscador) ||
                        s.Nombre.ToUpper().Contains(Buscador) ||
                        s.Codigo.ToUpper().Contains(Buscador) ||
                        s.Tipo_ConceptosIETU_IETU.Nombre.ToUpper().Contains(Buscador) ||
                        s.Tipo_ConceptosIETU_IVA.Nombre.ToUpper().Contains(Buscador)
                    ).ToList();
                }

                return PartialView("_TablaConceptosIETU", liLista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(ConceptosIETU conceptosIETU, int? id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<ConceptosIETU> liListarConceptosIETU = new List<ConceptosIETU>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListarConceptosIETU = _context.ConceptosIETU.
                            Include(c => c.Tipo_ConceptosIETU_IETU).
                            Include(c => c.Tipo_ConceptosIETU_IVA).
                            Include(c=> c.Tipo_ConceptosIETU).
                            Where(p => p.Habilitado == true).ToList();

                        inCantidad = liListarConceptosIETU.Where(
                                p => p.Nombre.ToUpper() == conceptosIETU.Nombre.ToUpper() || //Validar repetidos
                                p.Codigo.ToUpper() == conceptosIETU.Codigo.ToUpper()
                        ).Count();

                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            //Generación y guardado del TIPO de flujo
                            var vaIVA = _context.Tipo_ConceptosIETU_IVA.Find(conceptosIETU.fkTipoIVA);
                            string stCodigoIVA = vaIVA.Codigo;
                            var vaIETU = _context.Tipo_ConceptosIETU_IETU.Find(conceptosIETU.fkTipoIETU);
                            string stCodigoIETU = vaIETU.Codigo;

                            conceptosIETU.Tipo = stCodigoIETU + stCodigoIVA;
                            conceptosIETU.Habilitado = true;
                            conceptosIETU.fechaCr = DateTime.Now;
                            conceptosIETU.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.ConceptosIETU.Add(conceptosIETU);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListarConceptosIETU = _context.ConceptosIETU.
                            Include(c => c.Tipo_ConceptosIETU_IETU).
                            Include(c => c.Tipo_ConceptosIETU_IVA).
                            Include(c=> c.Tipo_ConceptosIETU).
                            Where(p => p.Habilitado == true &&
                                  p.idConceptoIETU != id).ToList();

                        inCantidad = liListarConceptosIETU.Where(
                                p => p.Nombre.ToUpper() == conceptosIETU.Nombre.ToUpper() || //Validar repetidos
                                p.Codigo.ToUpper() == conceptosIETU.Codigo.ToUpper()
                        ).Count();


                        if (inCantidad >= 1) //Si existe el registro
                            return "-1"; //Registro se encuentra de BD
                        else
                        {
                            var vaObj = _context.ConceptosIETU.Find(id);
                            vaObj.Codigo = conceptosIETU.Codigo;
                            vaObj.Nombre = conceptosIETU.Nombre;
                            vaObj.fkTipoFlujo = conceptosIETU.fkTipoFlujo;
                            vaObj.fkTipoIETU = conceptosIETU.fkTipoIETU;
                            vaObj.fkTipoIVA = conceptosIETU.fkTipoIVA;
                            

                            //Generación y guardado del TIPO de flujo
                            var vaIVA = _context.Tipo_ConceptosIETU_IVA.Find(conceptosIETU.fkTipoIVA);
                            string stCodigoIVA = vaIVA.Codigo;
                            var vaIETU = _context.Tipo_ConceptosIETU_IETU.Find(conceptosIETU.fkTipoIETU);
                            string stCodigoIETU = vaIETU.Codigo;

                            vaObj.Tipo = stCodigoIETU + stCodigoIVA;
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
                var vaObj = _context.ConceptosIETU.Find(id);
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
        //Consulta para filtrar el IVA por el tipo de concepto
        public IActionResult actualizarIVA(int id)
        {
            try
            {
                var vaIVA = _context.Tipo_ConceptosIETU_IVA.Where(p => p.fkTipoConceptoIETU == id && p.Habilitado == true).ToList();
                return Ok(vaIVA);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Consulta para filtrar el IVA por el tipo de concepto
        public IActionResult actualizarIETU(int id)
        {
            try
            {
                var vaIETU = _context.Tipo_ConceptosIETU_IETU.Where(p => p.fkTipoConceptoIETU == id && p.Habilitado == true).ToList();
                return Ok(vaIETU);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para recuperar los datos del registro seleccionado
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaConceptosIETU = _context.ConceptosIETU.Find(id);
                return Ok(vaConceptosIETU);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
