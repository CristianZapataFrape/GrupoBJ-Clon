using System;
using System.Collections;
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
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GrupoBJ.Controllers
{
    [Acceder]
    public class UsuarioController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        public string [] asArreglo;
        #endregion

        #region "Constructor"
        public UsuarioController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método que se ejecuta al abrir la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboEmpresa();
                List<Usuario> liListaUsuario = new List<Usuario>();
                liListaUsuario = _context.Usuario.AsNoTracking().ToList(); //Incluir la información de las relaciones
                liListaUsuario = liListaUsuario.Where(p => p.Habilitado == true).ToList();

                return View(liListaUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region "Carga de datos"
        //Metodo para el combo de empresas
        public void listarComboEmpresa()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Empresa.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idEmpresa.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una empresa--",
                    Value = ""
                });
                ViewBag.listaEmpresa = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"

        //Metodo para filtrar la tabla con respecto al buscador
        public ActionResult Filtro(string BuscadorUsuario, string datosFiltro) //Filtro por textbox
        {
            try
            {
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Usuario> liListarUsuario = new List<Usuario>();

                if (datosFiltro == null || datosFiltro == "[]")
                {
                    liListarUsuario = _context.Usuario.Where(p => p.Habilitado == true).ToList();
                }
                else
                {
                    //Creación de la consulta de filtro dinámica
                    string consultaLike = "SELECT * FROM Usuario WHERE Habilitado = 1 AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorUsuario + "%' or ";
                        else
                            consultaLike = consultaLike + asArregloFiltro[i] + " LIKE '%" + BuscadorUsuario + "%')";
                    }


                    liListarUsuario = _context.Usuario.FromSqlRaw(consultaLike).ToList();
                }
                return PartialView("_TablaUsuario", liListarUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos (Insersión o modificación)
        [HttpPost]
        public string Guardar(Usuario usuario, int? id, string confirmarContra, string validacionColeccion)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Usuario> liListaUsuario = new List<Usuario>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaUsuario = _context.Usuario.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaUsuario.Where(
                            p => p.nombreUsuario == usuario.nombreUsuario).Count(); //Validación de boRepetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de liBD
                        }
                        else
                        {
                            if (confirmarContra == null)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(C)Favor de confirmar la contraseña.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (confirmarContra != usuario.Contrasena)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(C)Las contraseñas no coinciden.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (usuario.nuncaCaduca == false && usuario.fechaCaducidad == null)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(E)La fecha de caducidad es obligatoria.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            //------------------------------VALIDACIONES DE COLECCIÓN-----------------

                            //Validar que la colección tenga por lo menos un registro
                            if (validacionColeccion == "[]")
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)Debes de seleccionar mínimo un perfil para el usuario</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }


                            //Validar que se haya seleccionado en cada registro todos los campos
                            bool boValidacion = validacionColeccion.Contains("x");
                            if (boValidacion == true)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)Debes de seleccionar todos los campos en cada registro</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            //Crear el asArreglo de colección
                            asArreglo = validacionColeccion.TrimStart('[').TrimEnd(']').Split(',');

                            //Obtener los id's de sucursales para ver si existen repetidos
                            bool boRepetido = false;
                            for (int i = 1; i < asArreglo.Length; i = i + 4)
                            {
                                for (var j = 1; j < asArreglo.Length; j = j + 4)
                                {
                                    if (asArreglo[i] == asArreglo[j] && i != j)
                                    {
                                        boRepetido = true;
                                        break;
                                    }
                                }
                            }
                            if (boRepetido == true)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)No debes seleccionar mas de un perfil para cada sucursal</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            //Insersión del usuario
                            usuario.Habilitado = true;
                            usuario.fechaCr = DateTime.Now;
                            usuario.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Usuario.Add(usuario);
                            _context.SaveChanges();

                            //Obtener el id del usuario registrado
                            int inIdU = usuario.idUsuario;

                            //Insersión en la colección                          
                            List<Usuario_Empresa_Sucursal_Sis_Per> liUESSP = new List<Usuario_Empresa_Sucursal_Sis_Per>();

                            for (int i = 0; i < asArreglo.Length; i = i + 4)
                            {
                                liUESSP.Add(new Usuario_Empresa_Sucursal_Sis_Per()
                                {
                                    fkEmpresa = int.Parse(asArreglo[i]),
                                    fkSucursal = int.Parse(asArreglo[i + 1]),
                                    fkSistema = int.Parse(asArreglo[i + 2]),
                                    fkPerfil = int.Parse(asArreglo[i + 3]),
                                    fkUsuario = inIdU,
                                    Habilitado = true,
                                    fechaCr = DateTime.Now,
                                    fkUsuarioCr = fkUsuarioLogin
                                });
                            }
                            _context.Usuario_Empresa_Sucursal_Sis_Per.AddRange(liUESSP);
                            _context.SaveChanges();

                            return "1";

                        }
                    }
                    else  //Modificar
                    {
                        liListaUsuario = _context.Usuario.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaUsuario.Where(
                            p => (p.nombreUsuario == usuario.nombreUsuario)
                            && p.idUsuario != id).Count(); //Validación de boRepetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de liBD
                        }
                        else
                        {
                            if (confirmarContra == null)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(C)Favor de confirmar la contraseña.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (confirmarContra != usuario.Contrasena)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(C)Las contraseñas no coinciden.</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            if (usuario.nuncaCaduca == false && usuario.fechaCaducidad == null)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(E)La fecha de caducidad es obligatoria.</li>";
                                stRpta += "</ul>";
                                return stRpta;

                            }
                            //------------------------------VALIDACIONES DE EMPRESA_SUCURSAL-----------------
                            //Validar que la tabla empresas y sucursales tenga por lo menos un registro
                            if (validacionColeccion == "[]")
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)Debes de seleccionar mínimo un perfil para el usuario</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }
                            //Validar que se haya seleccionado en cada registro una empresa y una sucursal
                            bool boValidacion = validacionColeccion.Contains("x");
                            if (boValidacion == true)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)Debes de seleccionar todos los campos en cada registro</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }

                            //Crear el asArreglo de empresas y sucursales
                            asArreglo = validacionColeccion.TrimStart('[').TrimEnd(']').Split(',');

                            //Obtener los id's de sucursales para ver si existen repetidos
                            bool boRepetido = false;
                            for (int i = 1; i < asArreglo.Length; i = i + 4)
                            {
                                for (var j = 1; j < asArreglo.Length; j = j + 4)
                                {
                                    if (asArreglo[i] == asArreglo[j] && i != j)
                                    {
                                        boRepetido = true;
                                        break;
                                    }
                                }
                            }
                            if (boRepetido == true)
                            {
                                stRpta += "<ul class='list-group'>";
                                stRpta += "<li class='list-group-item'>(F)No debes seleccionar mas de un perfil para cada sucursal</li>";
                                stRpta += "</ul>";
                                return stRpta;
                            }


                            //Actualización de los datos
                            var vaObj = _context.Usuario.Find(id);
                            vaObj.nombreUsuario = usuario.nombreUsuario;
                            vaObj.Contrasena = usuario.Contrasena;
                            vaObj.Nombre = usuario.Nombre;
                            vaObj.correoElectronico = usuario.correoElectronico;
                            vaObj.fechaCaducidad = usuario.fechaCaducidad;
                            vaObj.imagePath = usuario.imagePath;
                            vaObj.menuProduccion = usuario.menuProduccion;
                            vaObj.nuncaCaduca = usuario.nuncaCaduca;
                            vaObj.fechaUm = DateTime.Now;
                            vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            _context.SaveChanges();


                            //Actualización o insersión de los datos de la tabla de empresa_sucursal
                            //--1 Obtener los registros de liBD con ese usuario
                            int inIdU = vaObj.idUsuario;
                            List<Usuario_Empresa_Sucursal_Sis_Per> liBD;
                            liBD = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkUsuario == inIdU && p.Habilitado == true).ToList();

                            //--2 Buscar los datos de la tabla en liBD y los sobrantes quitarlos de liBD (Deshabilitarlos)
                            asArreglo = validacionColeccion.TrimStart('[').TrimEnd(']').Split(',');
                            foreach (var item in liBD)
                            {
                                bool boBandera = false;
                                for (int i = 1; i < asArreglo.Length; i = i + 4)
                                {
                                    if (item.fkSucursal == int.Parse(asArreglo[i]) && item.fkSistema == int.Parse(asArreglo[i+1]) && item.fkPerfil == int.Parse(asArreglo[i + 2])) //Repetidos
                                    {
                                        boBandera = true;
                                        break;
                                    }
                                }
                                if (boBandera == false) //Los que sobran en liBD
                                {
                                    var vaObjeto = _context.Usuario_Empresa_Sucursal_Sis_Per.Find(item.idUsuEmpSucSisPer);
                                    vaObjeto.fechaUm = DateTime.Now;
                                    vaObjeto.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                                    vaObjeto.Habilitado = false;
                                    _context.SaveChanges();
                                }
                            }

                            //--3 Agregar los datos de la tabla que faltan en liBD (Adecuaciones)
                            List<Usuario_Empresa_Sucursal_Sis_Per> liRegistroInsertar = new List<Usuario_Empresa_Sucursal_Sis_Per>();
                            for (int i = 1; i < asArreglo.Length; i = i + 4)
                            {
                                bool boBandera = false;
                                foreach (var item in liBD)
                                {
                                    if (item.fkSucursal == int.Parse(asArreglo[i]) && item.fkSistema == int.Parse(asArreglo[i + 1]) && item.fkPerfil == int.Parse(asArreglo[i + 2])) //Repetidos
                                    {
                                        boBandera = true;
                                        break;
                                    }
                                }
                                if (boBandera == false)
                                {
                                    //Obtener los valores del asArreglo
                                    int inEmpresa = int.Parse(asArreglo[i - 1]);
                                    int inSucursal = int.Parse(asArreglo[i]);
                                    int inSistema = int.Parse(asArreglo[i + 1]);
                                    int inPerfil = int.Parse(asArreglo[i +2]);
                                    int inUs = inIdU;

                                    //Verificar que exista algun registro deshabilitado con esos datos
                                    int inConsulta = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkEmpresa == inEmpresa && p.fkSucursal == inSucursal
                                                    && p.fkSistema == inSistema && p.fkPerfil == inPerfil && p.fkUsuario == inUs &&
                                                    p.Habilitado == false).Count();
                                    if (inConsulta > 0) //Habilitar el registro
                                    {
                                        var vaRegistroEncontrado = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkEmpresa == inEmpresa && p.fkSucursal == inSucursal
                                                    && p.fkSistema == inSistema && p.fkPerfil == inPerfil && p.fkUsuario == inUs &&
                                                    p.Habilitado == false).ToList();

                                        vaRegistroEncontrado[0].fechaUm = DateTime.Now;
                                        vaRegistroEncontrado[0].fkUsuarioUm = 1; //Se reemplaza por el usuario que se logueo
                                        vaRegistroEncontrado[0].Habilitado = true;
                                        _context.SaveChanges();

                                    }
                                    else //Insertarlo
                                    {
                                        liRegistroInsertar.Add(new Usuario_Empresa_Sucursal_Sis_Per()
                                        {
                                            fkEmpresa = inEmpresa,
                                            fkSucursal = inSucursal,
                                            fkSistema = inSistema,
                                            fkPerfil = inPerfil,
                                            fkUsuario = inUs,
                                            Habilitado = true,
                                            fechaCr = DateTime.Now,
                                            fkUsuarioCr = fkUsuarioLogin
                                        });
                                    }
                                }
                            }
                            _context.Usuario_Empresa_Sucursal_Sis_Per.AddRange(liRegistroInsertar);
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

        //Método para eliminar un registro (Deshabilitarlo)
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                //Eliminar el usuario
                var vaObj = _context.Usuario.Find(id);
                vaObj.Habilitado = false;
                vaObj.fechaUm = DateTime.Now;
                vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                _context.SaveChanges();

                //Eliminar los datos de la colección asociados al usuario
                List<Usuario_Empresa_Sucursal_Sis_Per> liBD;
                liBD = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkUsuario == id && p.Habilitado == true).ToList();

                foreach (var item in liBD)
                {
                    var vaObjeto = _context.Usuario_Empresa_Sucursal_Sis_Per.Find(item.idUsuEmpSucSisPer);
                    vaObjeto.fechaUm = DateTime.Now;
                    vaObjeto.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                    vaObjeto.Habilitado = false;
                    _context.SaveChanges();
                }

                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }

        #endregion

        #region "Querys"

        //Recuperar los datos para cuando se va a modificar
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaUsuario = _context.Usuario.Find(id);
                return Ok(vaUsuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Recuperar los datos para empresas para los combos
        public IActionResult obtenerEmpresas(int id)
        {
            try
            {
                var vaEmpresas = _context.Empresa.Where(p=>p.Habilitado==true);
                return Ok(vaEmpresas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Recuperar los datos para sucursales para los combos
        public IActionResult obtenerSucursales(int id)
        {
            try
            {
                var vaSucursal = _context.Sucursal.Where(p => p.fkEmpresa == id & p.Habilitado == true).ToList();
                return Ok(vaSucursal);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Recuperar los datos para el sistema para los combos
        public IActionResult obtenerSistema(int id)
        {
            try
            {
                var vaSistemas = _context.Acceso_Sistema.Where(p => p.Habilitado == true && p.fkEmpresa == id);
                return Ok(vaSistemas);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Recuperar los datos para los perfiles para los combos
        public IActionResult obtenerPerfil(int id)
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



        //Recuperar los datos de la colección para Actualizar
        public IActionResult obtenerColeccion(int id)
        {
            try
            {
                var vaColeccion = _context.Usuario_Empresa_Sucursal_Sis_Per.Where(p => p.fkUsuario == id & p.Habilitado == true).ToList();
                return Ok(vaColeccion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

    }
}
