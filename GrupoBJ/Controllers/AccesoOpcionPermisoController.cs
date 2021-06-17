using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Filters;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrupoBJ.Controllers
{
    public class AccesoOpcionPermisoController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        #endregion

        #region "Constructor"
        public AccesoOpcionPermisoController(GrupoBJDBContext context)
        {
            _context = context;
        }

        #endregion

        #region "Funciones de permisos"

        //Obtener revisar los permisos de la pantalla
        [HttpPost]
        public string revisionPermisosPorPantalla(string data)
        {
            int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
            //Obtener y convertir en arreglo los permisos y el controlador
            string[] asDatos;
            asDatos = data.TrimStart('[').TrimEnd(']').Split(',');
            string stControlador = asDatos[0];

            //Obtener la opción que tiene ese controlador
            var vaRegistro = _context.Acceso_Opcion.Where(p => p.Controlador == stControlador && p.Habilitado == true && p.tipoSistema == 1).ToList();

            //Verificar que se encuentra un controlador
            if (vaRegistro.Count == 1)
            {
                int inIdOpcion = vaRegistro[0].idOpcion;
                //Buscar los datos de la tabla en BD y los sobrantes quitarlos de BD (Deshabilitarlos)
                List<Acceso_Opcion_Permiso> liBD;
                liBD = _context.Acceso_Opcion_Permiso.Where(p => p.fkOpcion == inIdOpcion && p.Habilitado == true).ToList();

                foreach (var item in liBD)
                {
                    bool boBandera = false;
                    for (int i = 1; i < asDatos.Length; i++)
                    {
                        if (item.Clase == asDatos[i]) //Repetidos
                        {
                            boBandera = true;
                            break;
                        }
                    }
                    if (boBandera == false) //Los que sobran en BD
                    {
                        var vaObjeto = _context.Acceso_Opcion_Permiso.Find(item.idOpcionPermiso);
                        vaObjeto.fechaUm = DateTime.Now;
                        vaObjeto.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                        vaObjeto.Habilitado = false;
                        _context.SaveChanges();

                        //Deshabilitar los perfiles que tenian este permiso
                        int inIdOpcionPermiso = item.idOpcionPermiso;

                        List<Acceso_Permiso_Perfil_Opcion> liAPPO = new List<Acceso_Permiso_Perfil_Opcion>();
                        liAPPO = _context.Acceso_Permiso_Perfil_Opcion.
                                             Where(p => p.fkOpcionPermiso == inIdOpcionPermiso && p.Habilitado == true).ToList();

                        foreach (var x in liAPPO)
                        {
                            var vaObj = _context.Acceso_Permiso_Perfil_Opcion.Find(x.idPermisoPerfilOpcion);
                            vaObj.fechaUm = DateTime.Now;
                            vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            vaObj.Habilitado = false;
                            _context.SaveChanges();
                        }
                    }
                }

                //--Agregar los datos de la tabla que faltan en BD
                List<Acceso_Opcion_Permiso> liRegistroInsertar = new List<Acceso_Opcion_Permiso>();
                for (int i = 1; i < asDatos.Length; i++)
                {
                    bool boBandera = false;
                    foreach (var item in liBD)
                    {
                        if (item.Clase == asDatos[i]) //Repetidos
                        {
                            boBandera = true;
                            break;
                        }
                    }
                    if (boBandera == false)
                    {
                        //Obtener el id permiso
                        string stClase = asDatos[i].Substring(4, asDatos[i].Length - 4);
                        var vaBDPermisos = _context.Acceso_Permiso.Where(p => p.Clave == stClase && p.Habilitado == true).ToList();

                        //Validar que obtenga un permiso
                        if (vaBDPermisos.Count == 1)
                        {
                            //Obtener datos
                            int inIdPermiso = vaBDPermisos[0].idPermiso;
                            int inOpcion = inIdOpcion;

                            //Verificar que exista algun registro deshabilitado con esos datos
                            int inConsulta = _context.Acceso_Opcion_Permiso.Where(p => p.fkOpcion == inOpcion && p.fkPermiso == inIdPermiso &&
                                            p.Habilitado == false).Count();

                            if (inConsulta > 0)//Habilitar el registro
                            {
                                var vaRegistroEncontrado = _context.Acceso_Opcion_Permiso.Where(p => p.fkOpcion == inOpcion && p.fkPermiso == inIdPermiso &&
                                            p.Habilitado == false).ToList();
                                vaRegistroEncontrado[0].fechaUm = DateTime.Now;
                                vaRegistroEncontrado[0].fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                                vaRegistroEncontrado[0].Habilitado = true;
                                _context.SaveChanges();
                            }
                            else//Insersión
                            {
                                liRegistroInsertar.Add(new Acceso_Opcion_Permiso()
                                {
                                    fkOpcion = inIdOpcion,
                                    fkPermiso = inIdPermiso,
                                    Clase = asDatos[i],
                                    Habilitado = true,
                                    fechaCr = DateTime.Now,
                                    fkUsuarioCr = fkUsuarioLogin
                                });
                            }
                        }
                    }
                }

                //Validar que se vayan a insertar registros
                if (liRegistroInsertar.Count > 0)
                {
                    _context.Acceso_Opcion_Permiso.AddRange(liRegistroInsertar);
                    _context.SaveChanges();
                }
            }

            return "Correcto";
        }

        public IActionResult ajaxConcederPermisos(string Controlador)
        {
            try
            {
                //Obtener la pantalla actual
                var vaAccesoOpcion = _context.Acceso_Opcion.Where(p => p.Controlador == Controlador && p.Habilitado == true && p.tipoSistema == 1).ToList();
                if (vaAccesoOpcion.Count > 0)
                {
                    int inPerfil = (int)HttpContext.Session.GetInt32("PerfilSession");

                    //Obtener los permisos que tiene el usuario en esa pantalla
                    int inIdOpcion = vaAccesoOpcion[0].idOpcion;
                    List<Acceso_Permiso_Perfil_Opcion> liPermisos = new List<Acceso_Permiso_Perfil_Opcion>();
                    liPermisos = _context.Acceso_Permiso_Perfil_Opcion.Where(p => p.fkOpcion == inIdOpcion && p.fkPerfil == inPerfil
                                && p.Habilitado == true).ToList();
                    if (liPermisos.Count > 0)
                    {
                        List<int> liArrayPermisos = new List<int>();
                        foreach (var item in liPermisos)
                        {
                            liArrayPermisos.Add((int)item.fkOpcionPermiso);
                        }
                        //Obtener las clases de esos permisos del usuario
                        string stIds = String.Join(",", liArrayPermisos.Select(p => p.ToString()).ToArray());
                        List<Acceso_Opcion_Permiso> liClases = new List<Acceso_Opcion_Permiso>();
                        liClases = _context.Acceso_Opcion_Permiso.FromSqlRaw("Select * from Acceso_Opcion_Permiso where idOpcionPermiso in (" + stIds + ") and Habilitado = 1").ToList();                       
                        return Ok(liClases);
                    }
                    return Ok("{}");
                }
                return Ok("{}");
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
