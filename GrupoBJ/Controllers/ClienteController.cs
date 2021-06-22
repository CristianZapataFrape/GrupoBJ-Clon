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
    }
}
