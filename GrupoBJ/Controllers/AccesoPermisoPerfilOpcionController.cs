using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections;
using GrupoBJ.Filters;
using Microsoft.AspNetCore.Http;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class AccesoPermisoPerfilOpcionController : Controller
    {
        #region "Variables globables"
        private readonly GrupoBJDBContext _context;
        #endregion

        #region "Constructor"
        public AccesoPermisoPerfilOpcionController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método que se ejecuta al cargar la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboSistema();
                listarComboPerfil();
                List<Acceso_Permiso_Perfil_Opcion> liListaAccesoPermisoPerfilOpcion = new List<Acceso_Permiso_Perfil_Opcion>();
                liListaAccesoPermisoPerfilOpcion = _context.Acceso_Permiso_Perfil_Opcion.Include(c => c.Acceso_Perfil.Acceso_Sistema).
                    Include(c => c.Acceso_Opcion).Include(c => c.Acceso_Opcion_Permiso).
                    Where(p => p.Habilitado == true).ToList();
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Función para carga de árbol"

        public IActionResult Tree(int? ComboSistema)
        {
            List<Acceso_Opcion> liBD = new List<Acceso_Opcion>();
            liBD = _context.Acceso_Opcion.Where(p => p.Habilitado == true && p.fkSistema == ComboSistema).OrderBy(c=> c.Posicion).ToList();


            List<TreeViewNode> liNodes = new List<TreeViewNode>();
            foreach (var item in liBD)
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
                    imagen = "./Script/img/icono_paper.png";
                    a.disabled = false;
                }                   
                else
                    imagen = "./Script/img/icono_folder.png";
                liNodes.Add(new TreeViewNode { id = item.idOpcion.ToString(), parent = parent, text = item.Nombre, icon = imagen, state = a});
            }

            return Ok(liNodes);

        }

        #endregion

        #region "Funciones CRUD"
        [HttpPost]
        public string Guardar(string Coleccion, int ComboPerfil, string selectedItems)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string[] saArreglo;
                saArreglo = Coleccion.TrimStart('[').TrimEnd(']').Split(',');

                //Buscar los datos de la tabla en BD y los sobrantes quitarlos de BD (Deshabilitarlos)
                List<Acceso_Permiso_Perfil_Opcion> liBD;
                liBD = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkPerfil == ComboPerfil && p.Habilitado == true).ToList();

                foreach (var item in liBD)
                {
                    bool boBandera = false;
                    for (int i = 0; i < saArreglo.Length; i++)
                    {
                        if (item.fkOpcionPermiso == int.Parse(saArreglo[i])) //Repetidos
                        {
                            boBandera = true;
                            break;
                        }
                    }
                    if (boBandera == false) //Los que sobran en BD
                    {
                        var vaObjeto = _context.Acceso_Permiso_Perfil_Opcion.Find(item.idPermisoPerfilOpcion);
                        vaObjeto.fechaUm = DateTime.Now;
                        vaObjeto.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                        vaObjeto.Habilitado = false;
                        _context.SaveChanges();
                    }
                }


                //--3 Agregar los datos de la tabla que faltan en BD
                List<Acceso_Permiso_Perfil_Opcion> liRegistroInsertar = new List<Acceso_Permiso_Perfil_Opcion>();
                for (int i = 0; i < saArreglo.Length; i++)
                {
                    bool boBandera = false;
                    foreach (var item in liBD)
                    {
                        if (item.fkOpcionPermiso == int.Parse(saArreglo[i])) //Repetidos
                        {
                            boBandera = true;
                            break;
                        }
                    }
                    if (boBandera == false)
                    {
                        //Obtener los valores
                        int inFkOpcionPermiso = int.Parse(saArreglo[i].ToString());
                        int inFkOpcion = obtenerfkOpcion(inFkOpcionPermiso);
                        int inFkPerfil = ComboPerfil;

                        //Verificar que exista algun registro deshabilitado con esos datos
                        int inConsulta = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkOpcion == inFkOpcion && p.fkOpcionPermiso == inFkOpcionPermiso
                                        && p.fkPerfil == inFkPerfil &&
                                        p.Habilitado == false).Count();

                        if (inConsulta > 0) //Habilitar el registro
                        {
                            var vaRegistroEncontrado = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkOpcion == inFkOpcion && p.fkOpcionPermiso == inFkOpcionPermiso
                                        && p.fkPerfil == inFkPerfil &&
                                        p.Habilitado == false).ToList();
                            vaRegistroEncontrado[0].fechaUm = DateTime.Now;
                            vaRegistroEncontrado[0].fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            vaRegistroEncontrado[0].Habilitado = true;
                            _context.SaveChanges();
                        }
                        else //Insertarlo
                        {
                            liRegistroInsertar.Add(new Acceso_Permiso_Perfil_Opcion()
                            {
                                fkOpcionPermiso = inFkOpcionPermiso,
                                fkOpcion = inFkOpcion,
                                fkPerfil = inFkPerfil,
                                Habilitado = true,
                                fechaCr = DateTime.Now,
                                fkUsuarioCr = fkUsuarioLogin
                            });
                        }
                    }
                }
                _context.Acceso_Permiso_Perfil_Opcion.AddRange(liRegistroInsertar);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return "-1";
                //throw;
            }            
        }

        //Método para filtrar contenido de la tabla de búsqueda
        [HttpPost]
        public ActionResult Busqueda(string BuscarPerfil, int? fkSistema)
        {
            try
            {
                List<Acceso_Perfil> liListaAccesoPerfil = new List<Acceso_Perfil>();
                liListaAccesoPerfil = _context.Acceso_Perfil.Include(c => c.Acceso_Sistema).
                    Where(p => p.Habilitado == true).ToList();
                if (fkSistema != null)
                {
                    liListaAccesoPerfil = liListaAccesoPerfil.Where(
                        p => p.fkSistema == fkSistema && p.Habilitado == true).ToList();
                }
                if (!string.IsNullOrEmpty(BuscarPerfil))
                {
                    liListaAccesoPerfil = liListaAccesoPerfil.Where(
                        s => s.Acceso_Sistema.Nombre.ToUpper().Contains(BuscarPerfil.ToUpper()) ||
                        s.Nombre.ToUpper().Contains(BuscarPerfil.ToUpper())
                    ).ToList();
                }

                return PartialView("_TablaBusqueda", liListaAccesoPerfil);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Carga de datos"
        //Método para llenar el combo de sistema
        public void listarComboSistema()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Acceso_Sistema.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idSistema.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un sistema--",
                    Value = ""
                });
                ViewBag.listaAccesoSistema = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de perfil
        public void listarComboPerfil()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Acceso_Perfil.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idPerfil.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un perfil--",
                    Value = ""
                });
                ViewBag.listaAccesoPerfil = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones para modales"
        //Método para filtrar la tabla de Usuarios con el mismo perfil
        [HttpPost]
        public ActionResult UsuarioPerfil(int? fkPerfil)
        {
            try
            {
                List<Usuario_Empresa_Sucursal_Sis_Per> liLista = new List<Usuario_Empresa_Sucursal_Sis_Per>();
                liLista = _context.Usuario_Empresa_Sucursal_Sis_Per.Include(c => c.Empresa).Include(c => c.Sucursal).Include(c => c.Usuario).
                    Where(p => p.Habilitado == true && p.fkPerfil == fkPerfil).OrderBy(a => a.Usuario.nombreUsuario).ToList();
                return PartialView("_TablaUsuarioPerfil", liLista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para filtrar la tabla de perfiles que usan la misma pantalla PerfilPantalla
        [HttpPost]
        public ActionResult PerfilPantalla(int? PantallaSelec)
        {
            try
            {
                List<Acceso_Permiso_Perfil_Opcion> liLista = new List<Acceso_Permiso_Perfil_Opcion>();
                liLista = _context.Acceso_Permiso_Perfil_Opcion.Include(c => c.Acceso_Perfil).
                                Where(p => p.fkOpcion == PantallaSelec && p.Habilitado == true) .ToList();
                return PartialView("_TablaPerfilPantalla", liLista);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Querys"
        //Actualizar el combo perfil
        public IActionResult actualizarPerfil(int id)
        {
            try
            {
                var vaPerfil = _context.Acceso_Perfil.Where(p => p.fkSistema == id & p.Habilitado == true).ToList();
                return Ok(vaPerfil);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Método para obtener las pantallas del perfil
        public IActionResult obtenerPantallas(int perfil)
        {
            try
            {
                var vaPantallas = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkPerfil == perfil  && p.Habilitado == true)
                                .GroupBy(x=> x.fkOpcion).Select(x => new {x.Key}).ToList();
                return Ok(vaPantallas);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para obtener todos los permisos de la pantalla
        public IActionResult obtenerPermisos(int idOpcion)
        {
            try
            {
                var vaPermisos = _context.Acceso_Opcion_Permiso.Include(p=> p.Acceso_Permiso).Where(p => p.fkOpcion == idOpcion && p.Habilitado == true).OrderBy(a => a.idOpcionPermiso).ToList();
                return Ok(vaPermisos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para obtener todos los permisos del perfil que estan en BD
        public IActionResult obtenerPermisosBD(int perfil)
        {
            try
            {
                var vaPermisos = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkPerfil == perfil && p.Habilitado == true).ToList();
                return Ok(vaPermisos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Obtener la fkOpcion del pantalla
        public int obtenerfkOpcion(int fkOpcionPermiso)
        {
            var vaRegistro = _context.Acceso_Opcion_Permiso.Where(p => p.idOpcionPermiso == fkOpcionPermiso && p.Habilitado == true).ToList();
            int inFkOpcion = int.Parse(vaRegistro[0].fkOpcion.ToString());
            return inFkOpcion;
        }

        #endregion

    }
}
