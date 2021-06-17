using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using GrupoBJ.Controllers;
using GrupoBJ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using System.Text.Json;
using System.Collections;
using System.IO;
using System.Net;

namespace GrupoBJ.Filters
{
    public class Acceder : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            base.OnActionExecuting(filtercontext);
            if (filtercontext.HttpContext.Session.GetInt32("UsuarioSession") == null)
            {
                string action = filtercontext.RouteData.Values["action"].ToString();
                if (action != "Index") //Acciones en la misma pantalla
                {
                    filtercontext.HttpContext.Response.StatusCode = 403;
                }
                else //Va al Index
                    filtercontext.Result = new RedirectToActionResult("Index", "Login", null);

                //if (filtercontext.ActionArguments.Count > 0) //Acciones en la misma pantalla
                //{
                //    filtercontext.HttpContext.Response.StatusCode = 403;
                //}
                //else //Va al Index
                //    filtercontext.Result = new RedirectToActionResult("Index", "Login", null);
            }
            else
            {
                //Filtro para denegar o aceptar acceso sino esta logueado
                if (filtercontext.HttpContext.Session.GetInt32("UsuarioSession") == -1)
                    filtercontext.Result = new RedirectResult("~/Login");
                else
                {
                    ////Obtener perfil y controlador actual
                    var controlador = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)filtercontext.ActionDescriptor).ControllerName;
                    int idPerfil = (int)filtercontext.HttpContext.Session.GetInt32("PerfilSession");

                    //Obtener controladores
                    var arregloControladores = JsonSerializer.Deserialize<ArrayList>(filtercontext.HttpContext.Session.Get("Controladores"));
                    bool bandera = false;
                    foreach (var item in arregloControladores)
                    {
                        if (item.ToString() == controlador)
                        {
                            bandera = true;
                            break;
                        }
                    }

                    //Filtro para denegar o aceptar acceso si tiene permiso a la pantalla
                    if (bandera == false)
                        filtercontext.Result = new RedirectResult("~/Home");
                }
            }
        }

    }
}
