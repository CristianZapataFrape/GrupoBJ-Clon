using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    [Acceder]
    public class AccesoOpcionController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        private bool boBanderaPrimerEntrada = false;
        private int inPadre=0;
        private int inPadreSistema = 0;
        StringBuilder sbConsulta = new StringBuilder();
        #endregion

        #region "Constructor"
        public AccesoOpcionController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método de inicio donde se cargan los datos iniciales para la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboSistema();
                listarComboTipoArchivo();
                listarAccesoOpcionPadre();
                listarComboFiltro();
                listarComboTipoSistema();
                List<Acceso_Opcion> liListaAccesoOpcion = new List<Acceso_Opcion>();
                liListaAccesoOpcion = _context.Acceso_Opcion.Include(c => c.Acceso_Sistema).Include(c => c.Acceso_Tipo_Archivo).
                    Where(p => p.Habilitado == true).ToList();
                return View(liListaAccesoOpcion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Carga de datos"

        //Método para llenar el combo de sistema del modal
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


        //Método para llenar el combo de tipo de archivo del modal
        public void listarComboTipoArchivo()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Acceso_Tipo_Archivo.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idTipoArchivo.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un tipo de archivo--",
                    Value = ""
                });
                ViewBag.listaAccesoTipoArchivo = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de opción padre modal
        public void listarAccesoOpcionPadre()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Acceso_Opcion.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idOpcion.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una opción padre--",
                    Value = ""
                });
                ViewBag.listaAccesoOpcionPadre = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de tipo de sistema del modal
        public void listarComboTipoSistema()
        {
            try
            {
                List<SelectListItem> liLista = new List<SelectListItem>();
                liLista = new List<SelectListItem>
                {
                    new SelectListItem {Text = "--Seleccione un tipo de sistema--", Value="", Selected=true, Disabled=true},
                    new SelectListItem {Text = "Web", Value = "1"},
                    new SelectListItem {Text = "Escritorio", Value = "2"}
                };
                ViewBag.listaTipoSistema = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo filtro de sistema
        public void listarComboFiltro()
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
                liLista.Insert(0, new SelectListItem { Text = "Todos los sistemas", Value = "" });
                ViewBag.listaFiltro = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Método para filtrar contenido de la tabla
        public ActionResult Filtro(string Buscador, int? filtroCombo, string datosFiltro)
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Acceso_Opcion> liListarAccesoOpcion = new List<Acceso_Opcion>();
                //Creación de la consulta de filtro dinámica sin combo filtro
                string consultaLike;
                sbConsulta.Remove(0, sbConsulta.Length);
                sbConsulta.AppendLine("SELECT O.idOpcion, O.fkSistema, O.idOpcionPadre, O.Nombre, O.Posicion, O.fkTipoArchivo,");
                sbConsulta.AppendLine("O.Controlador, O.fkUsuarioCr, O.fechaCr, O.Habilitado, O.nombrePadre, O.fechaUm, ");
                sbConsulta.AppendLine("O.fkUsuarioUm, O.tipoSistema FROM Acceso_Opcion AS O ");
                sbConsulta.AppendLine("    INNER JOIN Acceso_Sistema AS Sis ON O.fkSistema = Sis.idSistema ");
                sbConsulta.AppendLine("    INNER JOIN Acceso_Tipo_Archivo AS TA ON TA.idTipoArchivo = O.fkTipoArchivo ");
                sbConsulta.AppendLine("WHERE O.Habilitado = 1 AND ");
                consultaLike = sbConsulta.ToString();
                //string consultaLike = "SELECT O.idOpcion, O.fkSistema, O.idOpcionPadre, O.Nombre, O.Posicion, O.fkTipoArchivo," +
                //    "O.Controlador, O.fkUsuarioCr, O.fechaCr, O.Habilitado, O.nombrePadre, O.fechaUm, " +
                //    "O.fkUsuarioUm, O.tipoSistema FROM Acceso_Opcion AS O " +
                //    "INNER JOIN Acceso_Sistema AS Sis ON O.fkSistema = Sis.idSistema " +
                //    "INNER JOIN Acceso_Tipo_Archivo AS TA ON TA.idTipoArchivo = O.fkTipoArchivo " +
                //    "WHERE O.Habilitado = 1 AND ";

                if (filtroCombo == null)
                {
                    consultaLike +=  "(";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=   asArregloFiltro[i] + " LIKE '%" + Buscador + "%' OR ";
                        else
                            consultaLike +=   asArregloFiltro[i] + " LIKE '%" + Buscador + "%')";
                    }
                    liListarAccesoOpcion = _context.Acceso_Opcion.FromSqlRaw(consultaLike).Include(c => c.Acceso_Sistema).Include(c => c.Acceso_Tipo_Archivo).ToList();
                }
                else
                {
                    consultaLike +=   "O.fkSistema = " + filtroCombo + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=   asArregloFiltro[i] + " LIKE '%" + Buscador + "%' OR ";
                        else
                            consultaLike +=   asArregloFiltro[i] + " LIKE '%" + Buscador + "%')";
                    }
                    liListarAccesoOpcion = _context.Acceso_Opcion.FromSqlRaw(consultaLike).Include(c => c.Acceso_Sistema).Include(c => c.Acceso_Tipo_Archivo).ToList();
                }
                return PartialView("_TablaAccesoOpcion", liListarAccesoOpcion);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para filtrar contenido de la tabla de búsqueda
        [HttpPost]
        public ActionResult Busqueda(string BuscarOpcionPadre, int? fkOmar)
        {
            try
            {
                List<Acceso_Opcion> liListaAccesoOpcion = new List<Acceso_Opcion>();
                liListaAccesoOpcion = _context.Acceso_Opcion.Include(c => c.Acceso_Sistema).Include(c => c.Acceso_Tipo_Archivo).
                    Where(p => p.Habilitado == true).ToList();
                if (fkOmar != null)
                {
                    liListaAccesoOpcion = liListaAccesoOpcion.Where(
                        p => p.fkSistema == fkOmar && p.Habilitado == true).ToList();
                }
                if (!string.IsNullOrEmpty(BuscarOpcionPadre))
                {
                    liListaAccesoOpcion = liListaAccesoOpcion.Where(
                        s => s.Acceso_Sistema.Nombre.ToUpper().Contains(BuscarOpcionPadre.ToUpper()) ||
                        s.Nombre.ToUpper().Contains(BuscarOpcionPadre.ToUpper()) ||
                        s.Acceso_Tipo_Archivo.Nombre.ToUpper().Contains(BuscarOpcionPadre.ToUpper()) ||
                         s.nombrePadre.ToUpper().Contains(BuscarOpcionPadre.ToUpper())
                    ).ToList();
                }

                return PartialView("_TablaBusqueda", liListaAccesoOpcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar (Insertar o modificar)
        [HttpPost]
        public string Guardar(Acceso_Opcion Acceso_Opcion, int id, int fkSistema, int? fkTipoArchivo, bool? menuPadre, int? idOpcionPadre)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                if (menuPadre == true)
                    idOpcionPadre = 0;
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Acceso_Opcion> liListaAccesoOpcion= new List<Acceso_Opcion>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaAccesoOpcion = _context.Acceso_Opcion.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaAccesoOpcion.Where(p => p.Nombre.ToUpper() == Acceso_Opcion.Nombre.ToUpper()
                                    && p.fkSistema == fkSistema && p.idOpcionPadre == idOpcionPadre && p.Habilitado == true).Count();
                        if (inCantidad >= 1) //Registro duplicado
                            return "-1";
                        else
                        {
                            if (fkTipoArchivo != 1 && Acceso_Opcion.Controlador == null) //Validar cuando se llena el controlador
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)El controlador es obligatorio.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (fkTipoArchivo != 1 && Acceso_Opcion.tipoSistema == null) //Validar cuando se llena el controlador
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(G)El tipo de sistema es obligatorio.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            int inControlador = 0;
                            if (Acceso_Opcion.Controlador != null)
                            {
                                inControlador = _context.Acceso_Opcion.Where(p => p.Controlador.ToUpper() == Acceso_Opcion.Controlador.ToUpper()
                                                && p.Habilitado == true).Count();
                            }

                            if (inControlador >= 1)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)El nombre del controlador se encuentra repetido.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            if (idOpcionPadre == null)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(C)La opción padre es obligatoria.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            //Validar la posición de  los hijos con el mismo padre
                            List<Acceso_Opcion> liListaHijos = new List<Acceso_Opcion>();
                            liListaHijos = _context.Acceso_Opcion.Where(p => p.idOpcionPadre == Acceso_Opcion.idOpcionPadre && 
                                                                      p.fkSistema == fkSistema && p.Habilitado == true).ToList();

                            if (liListaHijos.Count == 0)
                                Acceso_Opcion.Posicion = 1;
                            else
                            {
                                var vaPosicion = liListaHijos[liListaHijos.Count - 1].Posicion;
                                Acceso_Opcion.Posicion = vaPosicion + 1;
                            }           
                            
                            //Obtener el nombre del idPadre
                            var vaObj = _context.Acceso_Opcion.Find(Acceso_Opcion.idOpcionPadre);
                            var vaPadre = "";
                            if (vaObj != null)
                                vaPadre = vaObj.Nombre;

                            Acceso_Opcion.nombrePadre = vaPadre;                          
                            Acceso_Opcion.Habilitado = true;
                            Acceso_Opcion.fechaCr = DateTime.Now;
                            Acceso_Opcion.fkUsuarioCr = fkUsuarioLogin; //Se reemplaza por el usuario logueado
                            _context.Acceso_Opcion.Add(Acceso_Opcion);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListaAccesoOpcion = _context.Acceso_Opcion.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaAccesoOpcion.Where(p => p.Nombre.ToUpper() == Acceso_Opcion.Nombre.ToUpper()
                                    && p.fkSistema == fkSistema && p.idOpcionPadre == idOpcionPadre && p.idOpcion != id).Count();
                        if (inCantidad >= 1)//Registro duplicado
                            return "-1";
                        else
                        {
                            var vaObj = _context.Acceso_Opcion.Find(id); //Registro actual

                            if (fkTipoArchivo != 1 && Acceso_Opcion.Controlador == null) //Validar cuando se llena el controlador
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)El controlador es obligatorio.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (fkTipoArchivo != 1 && Acceso_Opcion.tipoSistema == null) //Validar cuando se llena el controlador
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(G)El tipo de sistema es obligatorio.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (idOpcionPadre == null)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(C)La opción padre es obligatoria.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            //Verificar el tipo de archivo, que si cambia a Opción no tenga hijos sino evitar el cambio
                            if (fkTipoArchivo == 2) //Opción
                            {
                                List<Acceso_Opcion> liTipoArchivo = new List<Acceso_Opcion>();
                                liTipoArchivo = _context.Acceso_Opcion.Where(p => p.Habilitado == true && vaObj.idOpcion == p.idOpcionPadre && p.fkSistema == vaObj.fkSistema).ToList();
                                if (liTipoArchivo.Count() > 0) //tiene hijos pero verificar 
                                {
                                    stRpta += "<ul class='list-group'>";
                                    stRpta += "<li class='list-group-item'>(E)No se puede cambiar el tipo de archivo a Opción ya que contiene algún menú/opcion descendiente.</li>";
                                    stRpta += "</ul>";
                                    return stRpta;
                                }
                            }

                            //Actualizar el fkSistema a sus descendientes (cambio de sistema)
                            int inSistemaBD = int.Parse(vaObj.fkSistema.ToString());
                            if (inSistemaBD != fkSistema) //Hubo cabios
                            {
                                inPadreSistema = id;
                                actualizarSistemaHijos(id, inSistemaBD, fkSistema);
                            }

                            //Obtener el nombre del idPadre para ponerlo en el nombre del padre de sus hijos
                            var vaObjeto = _context.Acceso_Opcion.Find(Acceso_Opcion.idOpcionPadre);
                            var vaPadre = "";
                            if (vaObjeto != null)
                                vaPadre = vaObjeto.Nombre;

                            //Actualizar el nombre del padre de los hijos si el nombre del padre cambia (cambio del nombre de opción)
                            string stNombreBD = vaObj.Nombre;
                            string stNombreModelo = Acceso_Opcion.Nombre;
                            if (stNombreBD != Acceso_Opcion.Nombre)
                            {
                                List<Acceso_Opcion> liHijos = new List<Acceso_Opcion>();
                                liHijos = _context.Acceso_Opcion.Where(p => p.Habilitado == true && vaObj.idOpcion == p.idOpcionPadre && p.fkSistema == vaObj.fkSistema).ToList();
                                for (int i = 0; i < liHijos.Count; i++)
                                {
                                    var vaHijo = _context.Acceso_Opcion.Find(liHijos[i].idOpcion);
                                    vaHijo.nombrePadre = stNombreModelo;
                                    vaHijo.fechaUm = DateTime.Now;
                                    vaHijo.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                                    _context.SaveChanges();
                                }
                            }

                            //Actualización de la posición
                            int inPosicionBD = int.Parse(vaObj.Posicion.ToString());
                            if (Acceso_Opcion.Posicion != inPosicionBD)
                            {
                                int inIdRegistro = vaObj.idOpcionPadre;
                                int inIdO = vaObj.idOpcion;
                                int inCambioPosicion = int.Parse(Acceso_Opcion.Posicion.ToString());
                                List<Acceso_Opcion> liPosiciones = new List<Acceso_Opcion>();
                                liPosiciones = _context.Acceso_Opcion.Where(p => p.Habilitado == true && inIdRegistro == p.idOpcionPadre && p.fkSistema == vaObj.fkSistema && p.idOpcion != inIdO).OrderBy(a => a.Posicion).ToList();

                                List<string> liLista = new List<string>();
                                foreach (var item in liPosiciones)
                                {
                                    liLista.Add(item.idOpcion.ToString());
                                }

                                liLista.Insert(inCambioPosicion - 1, inIdO.ToString());
                                int inCont = 1;
                                foreach (var item in liLista)
                                {
                                    var vaActualizarPosicion = _context.Acceso_Opcion.Find(int.Parse(item));
                                    vaActualizarPosicion.Posicion = inCont;
                                    vaActualizarPosicion.fechaUm = DateTime.Now;
                                    vaActualizarPosicion.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                                    _context.SaveChanges();
                                    inCont++;
                                }

                            }

                            //Actualización
                            vaObj.nombrePadre = vaPadre;
                            vaObj.Nombre = Acceso_Opcion.Nombre;
                            vaObj.fkSistema = Acceso_Opcion.fkSistema;
                            vaObj.fkTipoArchivo = Acceso_Opcion.fkTipoArchivo;
                            vaObj.Controlador = Acceso_Opcion.Controlador;
                            vaObj.tipoSistema = Acceso_Opcion.tipoSistema;
                            vaObj.idOpcionPadre = Acceso_Opcion.idOpcionPadre;
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
            catch (Exception x)
            {
                return x.ToString();
            }
        }

        //Método para eliminar un registro
        public string eliminar(int id)
        {
            try
            {
                inPadre = id;
                var vaObj = _context.Acceso_Perfil.Find(inPadre);
                eliminarRegistrosHijos(id);
                ajustarPosiciones(id);
                eliminarOpcionPermiso(id);
                return "1";
            }
            catch (Exception)
            {
                return "nada"; //Error
            }
        }

        //Función para eliminar los registros descendientes
        public void eliminarRegistrosHijos(int id)
        {
            int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
            //Informacion del nodo
            var vaObj = _context.Acceso_Opcion.Find(id);

            //Obtener los hijos
            List<Acceso_Opcion> liOpciones = new List<Acceso_Opcion>();
            liOpciones = _context.Acceso_Opcion.Where(p => p.Habilitado == true && id == p.idOpcionPadre && p.fkSistema == vaObj.fkSistema).ToList();

            var vaIdNuevo = 0;
            if (liOpciones.Count > 0) //Tiene Hijos
            {
                boBanderaPrimerEntrada = true;
                vaIdNuevo = liOpciones[0].idOpcion;
                eliminarRegistrosHijos(vaIdNuevo);
            }
            else //No tiene hijos, hay que regresarse al padre
            {
                if (boBanderaPrimerEntrada == true)
                {
                    var vaIdOpcion = vaObj.idOpcion;
                    var vaIdPadre = vaObj.idOpcionPadre;
                    //Elimino la información del abuelo
                    vaObj.Habilitado = false;
                    vaObj.fechaUm = DateTime.Now;
                    vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                    _context.SaveChanges();
                    if (inPadre != vaIdOpcion)
                    {
                        eliminarRegistrosHijos(vaIdPadre);
                    }
                }
                else //Primera vez
                {

                    //Elimino la información del abuelo
                    vaObj.Habilitado = false;
                    vaObj.fechaUm = DateTime.Now;
                    vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                    _context.SaveChanges();
                }

            }
        }

        //Función para reajustar las posiciones despues de eliminar registros
        public void ajustarPosiciones(int id)
        {
            //Informacion del nodo
            var vaObj = _context.Acceso_Opcion.Find(id);

            //Obtener los hermanos
            List<Acceso_Opcion> liLista = new List<Acceso_Opcion>();
            liLista = _context.Acceso_Opcion.Where(p => p.Habilitado == true && vaObj.idOpcionPadre == p.idOpcionPadre && p.fkSistema == vaObj.fkSistema)
                    .OrderBy(a => a.Posicion).ToList();

            for (int i = 0; i < liLista.Count; i++)
            {
                var vaActualizarPosicion = _context.Acceso_Opcion.Find(liLista[i].idOpcion);
                vaActualizarPosicion.Posicion = i + 1;
                _context.SaveChanges();
            }
        }


        //Función para cambiar el sistema de los descendientes
        public void actualizarSistemaHijos(int id, int inSistemaBD, int fkSistema)
        {
            int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
            //Informacion del nodo
            var vaObj = _context.Acceso_Opcion.Find(id);

            //Obtener los hijos
            List<Acceso_Opcion> liOpciones = new List<Acceso_Opcion>();
            liOpciones = _context.Acceso_Opcion.Where(p => p.Habilitado == true && id == p.idOpcionPadre && p.fkSistema == inSistemaBD).ToList();

            var vaIdNuevo = 0;
            if (liOpciones.Count > 0) //Tiene Hijos
            {
                boBanderaPrimerEntrada = true;
                vaIdNuevo = liOpciones[0].idOpcion;
                actualizarSistemaHijos(vaIdNuevo, inSistemaBD, fkSistema);
            }
            else //No tiene hijos, hay que regresarse al padre
            {
                if (boBanderaPrimerEntrada == true)
                {
                    var vaIdOpcion = vaObj.idOpcion;
                    var vaIdPadre = vaObj.idOpcionPadre;
                    //Elimino la información del abuelo
                    vaObj.fkSistema = fkSistema;
                    //vaObj.Habilitado = false;
                    vaObj.fechaUm = DateTime.Now;
                    vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                    _context.SaveChanges();
                    if (inPadreSistema != vaIdOpcion)
                    {
                        actualizarSistemaHijos(vaIdPadre, inSistemaBD, fkSistema);
                    }
                }
                else //Primera vez
                {

                    //Elimino la información del abuelo
                    vaObj.fkSistema = fkSistema;
                    //vaObj.Habilitado = false;
                    vaObj.fechaUm = DateTime.Now;
                    vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                    _context.SaveChanges();
                }

            }
        }

        //Método para eliminar los permisos de pantalla
        public void eliminarOpcionPermiso(int id)
        {
            int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
            List<Acceso_Opcion_Permiso> liBD;
            liBD = _context.Acceso_Opcion_Permiso.Where(p => p.fkOpcion == id && p.Habilitado == true).ToList();
            foreach (var item in liBD)
            {
                var vaObjeto = _context.Acceso_Opcion_Permiso.Find(item.idOpcionPermiso);
                vaObjeto.fechaUm = DateTime.Now;
                vaObjeto.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                vaObjeto.Habilitado = false;
                _context.SaveChanges();
            }
        }

        #endregion

        #region "Querys"
        //Función para recargar el combo de idOpcionPadre
        public IActionResult actualizarOpcionPadre(int id)
        {
            try
            {
                var vaOpcionPadre = _context.Acceso_Opcion.Where(p => p.fkSistema == id && p.Controlador == null && p.Habilitado == true).ToList();
                return Ok(vaOpcionPadre);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para obtener los datos de un registro (Modificar)
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaAccesoopcion = _context.Acceso_Opcion.Find(id);
                return Ok(vaAccesoopcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para obtener los datos de un registro (Modificar)
        public int obtenerPosMax(int id)
        {
            try
            {
                int inCantidad = _context.Acceso_Opcion.Where(p => p.Habilitado == true && id == p.idOpcionPadre).Count();
                return inCantidad;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para validar las relaciones que tiene Acceso_Opcion
        public int verificarRelacionesAccesoOpcion(int id)
        {
            try
            {
                //var AccesoOpcionPermiso = _context.Acceso_Opcion_Permiso.Where(p => p.fkOpcion== id && p.Habilitado == true).Count();
                //if (AccesoOpcionPermiso == 0)
                //{
                    var vaAccesoPermisoPerfilOpcion = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkOpcion == id && p.Habilitado == true).Count();
                        return vaAccesoPermisoPerfilOpcion;
                //}
                //else
                //    return AccesoOpcionPermiso;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //Función para obtener la infromación del registro seleccionado
        public IActionResult recuperarInfo(int id)
        {
            try
            {
                var vaInfo = _context.Acceso_Opcion.Include(x=> x.Acceso_Sistema).Where(p=> p.idOpcion == id && p.Habilitado == true);
                return Ok(vaInfo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Obtener los datos del registro a eliminar
        public IActionResult recuperarDatosEliminar(int id)
        {
            try
            {
                var vaOpcion = _context.Acceso_Opcion.Include(c => c.Acceso_Sistema).Where(p => p.idOpcion == id && p.Habilitado == true).ToList();
                return Ok(vaOpcion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


    }
}
