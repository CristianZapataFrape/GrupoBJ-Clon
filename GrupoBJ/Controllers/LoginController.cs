using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.Json;

namespace GrupoBJ.Controllers
{
    public class LoginController : Controller
    {
        private readonly GrupoBJDBContext _context;
        List<int> liArreglo = new List<int>();
        //List<int> menuPermitido = new List<int>();
        //HashSet<int> hs = new HashSet<int>();
        ArrayList liB = new ArrayList();
        private bool boBanderaPrimerEntrada = false;
        private int inPadre = 0;


        public LoginController(GrupoBJDBContext context)
        {
            _context = context;
        }

        //Método que carga la vista
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("UsuarioSession", -1);
            HttpContext.Session.SetInt32("PerfilSession", -1);
            return View();
        }

        //Método para login
        [HttpPost]
        public string Login(string Usuario, string Contrasena)
        {
            try
            {               
                var vaLogin = _context.Usuario.Where(p => p.nombreUsuario == Usuario && p.Contrasena == Contrasena
                              && p.Habilitado == true).ToList();
                if (vaLogin.Count == 1)
                {                   
                    bool boNuncaCaduca = (bool)vaLogin[0].nuncaCaduca;
                    if (boNuncaCaduca == true)
                    {
                        HttpContext.Session.SetInt32("UsuarioSession", vaLogin[0].idUsuario);
                        return "U-"+vaLogin[0].idUsuario;
                    }                     
                    else
                    {
                        DateTime dtFechaCaducidad = (DateTime)vaLogin[0].fechaCaducidad;
                        if (dtFechaCaducidad < DateTime.Now)
                            return "<strong><p class='text-danger'>Su usuario ha caducado. Contacte al administrador</p></strong>";
                        else
                        {
                            HttpContext.Session.SetInt32("UsuarioSession", vaLogin[0].idUsuario);
                            return "U-" + vaLogin[0].idUsuario;
                        }                         
                    }
                }else
                    return "<strong><p class='text-danger'>Error al loguearse. Favor de verificar usuario y/o contraseña</p></strong>";
            }
            catch (Exception)
            {
                throw;
            } 
        }

        //Método para filtrar contenido de la tabla de empresa-sucursal
        [HttpPost]
        public ActionResult EmpresaSucursal(int idUsuario, string BuscarEmpresaSucursal)
        {
            try
            {
                List<Usuario_Empresa_Sucursal_Sis_Per> liBD = new List<Usuario_Empresa_Sucursal_Sis_Per>();
                liBD = _context.Usuario_Empresa_Sucursal_Sis_Per.Include(c => c.Empresa).Include(a=> a.Sucursal).
                    Where(p => p.Habilitado == true).ToList();
                if (idUsuario != 0)
                {
                    liBD = liBD.Where(
                        p => p.fkUsuario == idUsuario && p.Habilitado == true).ToList();
                }
                if (!string.IsNullOrEmpty(BuscarEmpresaSucursal))
                {
                    liBD = liBD.Where(
                        s => s.Empresa.Nombre.ToUpper().Contains(BuscarEmpresaSucursal.ToUpper()) ||
                        s.Sucursal.Nombre.ToUpper().Contains(BuscarEmpresaSucursal.ToUpper())
                    ).ToList();
                }

                return PartialView("_TablaEmpresaSucursal", liBD);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para quitar login
        [HttpPost]
        public string LogOut()
        {
            HttpContext.Session.SetInt32("UsuarioSession", -1);
            HttpContext.Session.SetInt32("PerfilSession", -1);
            return "";
        }


        //Método para guardar el perfil
        [HttpPost]
        public string guardarPerfil(int idPerfil)
        {
            //Guardar el perfil en variable Session
            HttpContext.Session.SetInt32("PerfilSession", idPerfil);

            //Obtener controladores
            var vaPantallas = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkPerfil == idPerfil && p.Habilitado == true)
                                .GroupBy(x => x.fkOpcion).Select(x => new { x.Key }).ToList();

            ArrayList alArregloControladores = new ArrayList();
            for (int i = 0; i < vaPantallas.Count; i++)
            {
                var vaObj = _context.Acceso_Opcion.Find(vaPantallas[i].Key);
                alArregloControladores.Add(vaObj.Controlador);
            }
            alArregloControladores.Add("Home");

            //Guardar los controladores en la variable Session
            HttpContext.Session.Set("Controladores", JsonSerializer.SerializeToUtf8Bytes(alArregloControladores));
            
            return "";
        }

        //Método para cargar las pantallas por perfil
        [HttpPost]
        public IActionResult obtenerPantallasDelMenu(int idPerfil)
        {
            //Obtener el sistema
            var vaSistema = _context.Acceso_Perfil.Where(p => p.Habilitado == true && idPerfil == p.idPerfil).ToList();
            int inIdSistema = (int)vaSistema[0].fkSistema;

            //Obtener las pantallas que tiene permiso el perfil
            var vaPantallas = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkPerfil == idPerfil && p.Habilitado == true)
                                .GroupBy(x => x.fkOpcion).Select(x => new { x.Key }).ToList();

            //Obtener las pantallas que son del sistema Escritorio
            var vaEscritorio = _context.Acceso_Opcion.Where(p => p.Habilitado == true && p.tipoSistema == 2).ToList();

            //Obtener el array quitando las pantallas de escritorio
            ArrayList alPantallas = new ArrayList();
            bool boBanderaPantalla = false;
            for (int i = 0; i < vaPantallas.Count; i++)
            {
                int inVaPantalla = (int)vaPantallas[i].Key;
                for (int j = 0; j < vaEscritorio.Count; j++)
                {
                    int inVaEscritorio = vaEscritorio[j].idOpcion;
                    if (inVaPantalla == inVaEscritorio)
                    {
                        boBanderaPantalla = true;
                        break;
                    }
                }
                if (boBanderaPantalla == false)
                {
                    alPantallas.Add(inVaPantalla);
                }
                boBanderaPantalla = false;
            }

            //Obtener el menú asociado el perfil que se logueo
            for (int i = 0; i < alPantallas.Count; i++)
            {
                liArreglo.Add((int)alPantallas[i]);
                obtenerMenuPermiso((int)alPantallas[i]);
            }

            //Convertir en string el liArreglo de las pantallas con permiso
            string stIds = String.Join(",", liArreglo.Select(p => p.ToString()).ToArray());

            if (stIds != "")
            {
                //Obtener el menú del sistema
                List<Acceso_Opcion> liMenu = new List<Acceso_Opcion>();
                List<Acceso_Opcion> liBueno = new List<Acceso_Opcion>();

                liMenu = _context.Acceso_Opcion.FromSqlRaw("Select * from Acceso_Opcion where idOpcion in (" + stIds + ") and Habilitado = 1").ToList();

                var vaInicio = liMenu.Where(p => p.Habilitado == true && p.idOpcionPadre == 0).OrderBy(c => c.Posicion).ToList();
                for (int i = 0; i < vaInicio.Count; i++)
                {
                    liBueno.Add(new Acceso_Opcion() {
                        idOpcion = vaInicio[i].idOpcion, 
                        idOpcionPadre = vaInicio[i].idOpcionPadre, 
                        Nombre = vaInicio[i].Nombre,
                        fkSistema = vaInicio[i].fkSistema,
                        Posicion = vaInicio[i].Posicion,
                        fkTipoArchivo = vaInicio[i].fkTipoArchivo,
                        Controlador = vaInicio[i].Controlador,
                        fkUsuarioCr = vaInicio[i].fkUsuarioCr,
                        fechaCr = vaInicio[i].fechaCr,
                        Habilitado = vaInicio[i].Habilitado,
                        nombrePadre = vaInicio[i].nombrePadre,
                        fechaUm = vaInicio[i].fechaUm,
                        fkUsuarioUm = vaInicio[i].fkUsuarioUm
                    });
                }

                liMenu = _context.Acceso_Opcion.FromSqlRaw("Select * from Acceso_Opcion where idOpcion in (" + stIds + ") " +
                    "and Habilitado = 1 and idOpcionPadre != 0 Order by idOpcionPadre, Posicion").ToList();
                for (int i = 0; i < liMenu.Count; i++)
                {
                    liBueno.Add(new Acceso_Opcion()
                    {
                        idOpcion = liMenu[i].idOpcion,
                        idOpcionPadre = liMenu[i].idOpcionPadre,
                        Nombre = liMenu[i].Nombre,
                        fkSistema = liMenu[i].fkSistema,
                        Posicion = liMenu[i].Posicion,
                        fkTipoArchivo = liMenu[i].fkTipoArchivo,
                        Controlador = liMenu[i].Controlador,
                        fkUsuarioCr = liMenu[i].fkUsuarioCr,
                        fechaCr = liMenu[i].fechaCr,
                        Habilitado = liMenu[i].Habilitado,
                        nombrePadre = liMenu[i].nombrePadre,
                        fechaUm = liMenu[i].fechaUm,
                        fkUsuarioUm = liMenu[i].fkUsuarioUm
                    });
                }



                //Menu = _context.Acceso_Opcion.FromSqlRaw("Select * from Acceso_Opcion where idOpcion in (" + ids + ") and Habilitado = 1 Order by idOpcionPadre, Posicion").ToList();


                //for (int i = 0; i < inicio.Count; i++)
                //{
                //    b.Add(inicio[i].idOpcion);
                //    ordenar(inicio[i].idOpcion, Menu);
                //}

                //Crear JSON de menú (Pantallas)
                //Menu = Menu.OrderBy(c => c.Posicion).ToList();
                List<Menu> liJson = new List<Menu>();
                foreach (var item in liBueno)
                {
                    liJson.Add(new Menu
                    {
                        id = item.idOpcion.ToString(),
                        parentid = item.idOpcionPadre.ToString(),
                        text = item.Nombre,
                        controlador = item.Controlador,
                        tipoArchivo = item.fkTipoArchivo.ToString()
                    });
                }
                return Ok(liJson);
            }
            return Ok("{}");
        }

        //Método para obtener el menú de las pantallas que tiene permiso el perfil
        public void obtenerMenuPermiso(int idOpcion)
        {
            //Obtener el objeto y el idPPadre con el idOpcion
            var vaObj = _context.Acceso_Opcion.Find(idOpcion);
            int inIdPadre = vaObj.idOpcionPadre;

            //Validación del idOpcionPadre
            if (inIdPadre != 0)
            {
                //Guardar el id padre en el liArreglo
                liArreglo.Add(inIdPadre);
                obtenerMenuPermiso(inIdPadre);
            }
         
        }

        //Función para eliminar los registros descendientes
        public void ordenar(int id, List<Acceso_Opcion> Menu)
        {
            //Informacion del nodo
            var vaObj = Menu.Where(p=>p.idOpcion ==id).ToList();

            //Obtener los hijos
            List<Acceso_Opcion> liOpciones = new List<Acceso_Opcion>();
            liOpciones = Menu.Where(p => p.Habilitado == true && id == p.idOpcionPadre && p.fkSistema == vaObj[0].fkSistema).OrderBy(c=>c.Posicion).ToList();

            var vaIdNuevo = 0;
            if (liOpciones.Count > 0) //Tiene Hijos
            {
                boBanderaPrimerEntrada = true;
                vaIdNuevo = liOpciones[0].idOpcion;
                vaObj[0].Habilitado = false;
                liB.Add(vaIdNuevo);
                ordenar(vaIdNuevo, Menu);
            }
            else //No tiene hijos, hay que regresarse al padre
            {
                if (boBanderaPrimerEntrada == true)
                {
                    var inIdOpcion = vaObj[0].idOpcion;
                    var inIdPadre = vaObj[0].idOpcionPadre;
                    if (inPadre != inIdOpcion)
                    {
                        ordenar(inIdPadre, Menu);
                    }
                }
                else //Primera vez
                {
                    //Elimino la información del abuelo
                    vaObj[0].Habilitado = false;
                }

            }
        }
        

        //Función para obtener el nombre del usuario logueado
        public string obtenerNombreUsuarioLogin(int idUsuario)
        {
            var vaUsuario = _context.Usuario.Find(idUsuario);
            var vaNombre = vaUsuario.Nombre;
            return vaNombre;
        }

        //Función para crear el menú lateral
        public IActionResult crearMenuLateral(string datos)
        {

            var vaBD = _context.Acceso_Opcion.FromSqlRaw("Select * from Acceso_Opcion where idOpcion in (" + datos + ") " +
                    "and Habilitado = 1 Order by Posicion").ToList();
            List<TreeViewNode> liNodes = new List<TreeViewNode>();
            foreach (var item in vaBD)
            {
                //Estado de habilitado
                state a = new state();
                a.disabled = true;

                //Conversión para el padre
                var parent = "";
                if (item.idOpcionPadre == 0)
                    parent = "#";
                else
                    parent = item.idOpcionPadre.ToString();

                //Conversión para el icono
                var tipo = item.fkTipoArchivo;
                var imagen = "";
                if (tipo == 2)
                {
                    imagen = "../../Script/img/icono_paper.png";
                    a.disabled = false;
                }
                else
                    imagen = "../../Script/img/icono_folder.png";
                liNodes.Add(new TreeViewNode { id = item.idOpcion.ToString(), parent = parent, text = item.Nombre, icon = imagen, state = a });
            }

            return Ok(liNodes);
        }

        //Método para obtener el controlador de la pantalla seleccionada
        public string obtenerControladorMenu(int idOpcion)
        {
            var vaOpcion = _context.Acceso_Opcion.Find(idOpcion);
            string stControlador = vaOpcion.Controlador;
            return stControlador;
        }

        //public LocalRedirectResult prueba()
        //{
        //    return prueba("/Login");
        //    //El redirect no funciona moviendose de controlador a controlador, solo funciona cuando se cambia de pantalla con js y html
        //    //Response.Headers.Add("Refresh", "2");// in secound
        //    //Response.Headers.Remove("Refresh");
        //}

        //public IActionResult LocalRedirect()
        //{
        //    return View("Index");
        //    //return LocalRedirect("/Login");
        //    //View();
        //}
        //public int verificarSesion()
        //{
        //    int sesion = (int)HttpContext.Session.GetInt32("UsuarioSession");
        //    return sesion;
        //}

        //public RedirectResult MyProfile()
        //{
        //    return Redirect("https://www.c-sharpcorner.com/members/farhan-ahmed24");
        //}



    }
}
