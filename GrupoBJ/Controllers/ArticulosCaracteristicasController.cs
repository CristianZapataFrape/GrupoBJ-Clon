using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace GrupoBJ.Controllers
{
    public class ArticulosCaracteristicasController : Controller
    {
        private readonly GrupoBJDBContext _context;

        public ArticulosCaracteristicasController(GrupoBJDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            listarComboCaracteristicasBusq();
            listarComboCaracteristicas();
            List<Carateristicas> listaCararcteristicas = new List<Carateristicas>();
            listaCararcteristicas = _context.Carateristicas.Include(c => c.Usuario).AsNoTracking().ToList();
            return View(listaCararcteristicas);
            //return View();
        }


        [HttpPost]
        public ActionResult Busqueda(string BuscadorCaracteristicas)        {
            try
            {
                List<Carateristicas> listaCararcteristicas = new List<Carateristicas>();
                listaCararcteristicas = _context.Carateristicas.Include(c => c.Usuario).AsNoTracking().ToList();
                if (!string.IsNullOrEmpty(BuscadorCaracteristicas))
                {
                    BuscadorCaracteristicas = BuscadorCaracteristicas.ToUpper();
                    listaCararcteristicas = listaCararcteristicas.Where(
                        s => s.Nombre_Carateristica.ToUpper().Contains(BuscadorCaracteristicas) ||                        
                        s.Usuario.Nombre.ToString().ToUpper().Contains(BuscadorCaracteristicas) ||
                         s.fechaUm.ToString().ToUpper().Contains(BuscadorCaracteristicas)
                    ).ToList();
                }
                return PartialView("_CaracteristicasMaestras", listaCararcteristicas);
            }
            catch (Exception)
            {
                throw;
            }
        }



        //Método para llenar el combo de CaracteristicasBusq busquedad del modal
        public void listarComboCaracteristicasBusq()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristicas.Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre_Carateristica,
                                          Value = x.id_Cararteristica.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Text = "--Todos--",
                    Value = ""
                });
                ViewBag.listaCaracteristicas = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Caracteristicas busquedad del modal
        public void listarComboCaracteristicas()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristicas.Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre_Carateristica,
                                          Value = x.id_Cararteristica.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Text = "--Todos--",
                    Value = ""
                });
                ViewBag.listaCaracteristicasD = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
