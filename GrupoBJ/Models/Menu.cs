using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoBJ.Models
{
    public class Menu
    {
        public string id { get; set; }
        public string parentid { get; set; }
        public string text { get; set; }
        public string controlador { get; set; }

        public string tipoArchivo { get; set; }
    }
}
