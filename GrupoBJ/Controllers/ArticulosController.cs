using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrupoBJ.DataBase;
using GrupoBJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
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


namespace GrupoBJ.Controllers
{
    public class ArticulosController : Controller
    {
        public string[] arCamposDatos;
        public string[] arCamposId;
        private readonly GrupoBJDBContext _context;
      
        
        public ArticulosController(GrupoBJDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            listarComboSMercado();
            listarComboSPresentacion();
            listarComboSEstado();
            listarComboSTipo();
            listarComboSLinea();
            listarComboSMarca();
            listarComboSDivision();
            listarComboSTablaNutrimental();
            listarComboSDivisionBusq();
            listarComboSEstadoBusq();
            listarComboSTipoBusq();
            List<Articulos> listaArticulos = new List<Articulos>();
            listaArticulos = _context.Articulos.Include(c => c.Usuario).AsNoTracking().Where(p => p.Activo == true).ToList();
            return View(listaArticulos);
        }



        //Método para Carga Detalles generales modal
        [HttpPost]
        public ActionResult CamposGenerales()
        {
            try
            {
                List<Articulos_Campos> lista = new List<Articulos_Campos>();
                lista = _context.Articulos_Campos.Where(p => p.Habilitado == true).ToList();
                return PartialView("_ArticulosDetalles", lista);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult Busqueda(string BuscadorArticulo,string cbDivisionBusq ,string cbEstadoBusq, string cbTipoBusq)
        {
            try
            {
                if (BuscadorArticulo == null)
                    BuscadorArticulo = "";
                if (cbDivisionBusq == null)
                    cbDivisionBusq = "0";
                if (cbEstadoBusq == null)
                    cbEstadoBusq = "0";
                if (cbTipoBusq == null)
                    cbTipoBusq = "0";

                int inProdVenta = 0;
                if (cbTipoBusq == "10")
                    inProdVenta = 1;
                else if (cbTipoBusq == "11")
                    inProdVenta = 0;



                List<Articulos> listaArticulos = new List<Articulos>();
                string stsql = "";

                var listaCarateristicas = _context.Articulos_Carateristicas.FromSqlRaw("SELECT DISTINCT id_Articulos " +
                                                                                       "FROM Articulos_Carateristicas " +
                                                                                       "WHERE id_Carateristica_Valores IN(" + cbDivisionBusq + "," + cbEstadoBusq + ")").
                                                                                       Select(c => c.id_Articulos).ToList();
                if (cbDivisionBusq != "0" && cbEstadoBusq !="0") {
                    listaCarateristicas.RemoveRange(0, (listaCarateristicas.Count - 1));
                    var listadivision = _context.Articulos_Carateristicas.FromSqlRaw("SELECT DISTINCT id_Articulos " +
                                                                                      "FROM Articulos_Carateristicas " +
                                                                                      "WHERE id_Carateristica_Valores IN(" + cbDivisionBusq + ")").
                                                                                      Select(c => c.id_Articulos).ToList();

                     var listaEstado = _context.Articulos_Carateristicas.FromSqlRaw("SELECT DISTINCT id_Articulos " +
                                                                                    "FROM Articulos_Carateristicas " +
                                                                                    "WHERE id_Carateristica_Valores IN(" + cbEstadoBusq + ")").
                                                                                    Select(c => c.id_Articulos).ToList();

                    if (listadivision.Count > listaEstado.Count)
                    {
                        listaCarateristicas = _context.Articulos_Carateristicas.FromSqlRaw("SELECT DISTINCT ArtC1.id_Articulos  " +
                                                                                       "FROM Articulos_Carateristicas AS ArtC1 " +
                                                                                       "INNER JOIN Articulos_Carateristicas AS ArtC2 ON ArtC2.id_Carateristica_Valores = "+ cbDivisionBusq+"" +
                                                                                       "WHERE ArtC1.id_Carateristica_Valores = "+ cbEstadoBusq + "").
                                                                                       Select(c => c.id_Articulos).ToList();
                        //for (int i = 0; i < listadivision.Count; i++)
                        //{
                        //    for (int j = 0; i < listaEstado.Count; j++)
                        //    {
                        //        if (listadivision[i] == listaEstado[j])
                        //        {
                        //            listaCarateristicas.Add(listadivision[i]);
                        //            listaEstado.RemoveAt(j);
                        //            break;
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        listaCarateristicas = _context.Articulos_Carateristicas.FromSqlRaw("SELECT DISTINCT ArtC1.id_Articulos  " +
                                                                                       "FROM Articulos_Carateristicas AS ArtC1 " +
                                                                                       "INNER JOIN Articulos_Carateristicas AS ArtC2 ON ArtC2.id_Carateristica_Valores = " + cbEstadoBusq + "" +
                                                                                       "WHERE ArtC1.id_Carateristica_Valores = " + cbDivisionBusq + "").
                                                                                       Select(c => c.id_Articulos).ToList();
                        //for (int i = 0; i < listaEstado.Count; i++)
                        //{
                        //    for (int j = 0; i < listadivision.Count; j++)
                        //    {
                        //        if (listaEstado[i] == listadivision[j])
                        //        {
                        //            listaCarateristicas.Add(listaEstado[i]);
                        //            listadivision.RemoveAt(j);
                        //            break;
                        //        }
                        //    }
                        //}
                    }


                    //    listaEstado.RemoveAll(c => c !=  listadivision);
                    //listaCarateristicas.RemoveAll(c => c.);
                }
               if (listaCarateristicas.Count > 0)
                {
                    for (int i = 0; i < listaCarateristicas.Count; i++)
                    {
                        if (i == 0)
                            stsql += listaCarateristicas[i];
                        else
                            stsql += "," + listaCarateristicas[i];
                    } 
                    if(cbTipoBusq=="0")
                        listaArticulos = _context.Articulos.FromSqlRaw("SELECT * " +
                                                                       "FROM Articulos " +
                                                                       "WHERE id_Articulos in (" + stsql + ")")
                                                           .Include(c => c.Usuario).AsNoTracking().ToList();
                    else
                        listaArticulos = _context.Articulos.FromSqlRaw("SELECT * " +
                                                                       "FROM Articulos " +
                                                                       "WHERE id_Articulos in (" + stsql + ") AND Producto_Venta = "+inProdVenta)
                                                           .Include(c => c.Usuario).AsNoTracking().ToList();
                }
                else
                {
                    listaArticulos = _context.Articulos.Include(c => c.Usuario).AsNoTracking().Where(c=>c.Activo==true).ToList();
                }
                if (!string.IsNullOrEmpty(BuscadorArticulo))
                {
                    BuscadorArticulo = BuscadorArticulo.ToUpper();
                    listaArticulos = listaArticulos.Where(
                        s => s.Nombre_Articulo.ToUpper().Contains(BuscadorArticulo) ||
                        s.id_Articulo.ToUpper().Contains(BuscadorArticulo) ||
                        s.Costo_Estandar.ToString().ToUpper().Contains(BuscadorArticulo)
                    ).ToList();
                }
                return PartialView("_ArticulosMaestros", listaArticulos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para guardar los datos, ya sea insertar o modificar
        [HttpPost]
        public string Guardar(Articulos articulos, int? id, string ArregloCampoDatos, string ArregloCampoId,string cboTipo, string cboPresentacion, string cboDivision,
                              string cboEstado, string cboLinea,string cboMarca,string cboMercado)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string rpta = "";
                bool ProductoVenta = false;
                if (cboTipo == "10")
                    ProductoVenta = true;
                if (ModelState.IsValid)
                {
                    int cantidad = 0;
                    List<Articulos> listaArticulos = new List<Articulos>();
                    arCamposDatos = ArregloCampoDatos.TrimStart('[').TrimEnd(']').Split(',');
                    arCamposId = ArregloCampoId.TrimStart('[').TrimEnd(']').Split(',');
                    if (id.Equals(-1)) //Insertar
                    {
                        listaArticulos = _context.Articulos.ToList();
                        cantidad = listaArticulos.Where((p => p.Nombre_Articulo.ToUpper() == articulos.Nombre_Articulo.ToUpper())).Count(); //Validación por nombre de la empresa

                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            articulos.Producto_Venta = ProductoVenta;
                            articulos.Activo = true;
                            articulos.fechaCr = DateTime.Now;
                            articulos.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            articulos.fechaUm = DateTime.Now;
                            articulos.fkUsuarioUm = fkUsuarioLogin;
                            _context.Articulos.Add(articulos);
                            _context.SaveChanges();
                            listaArticulos = _context.Articulos.Where(p => p.id_Articulo == articulos.id_Articulo).ToList();
                            
                            //Altas de Cararteristicas   
                            if (cboTipo != null)                            
                                AltaCaracteristicas(cboTipo, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);                            
                            if (cboPresentacion != null)
                                AltaCaracteristicas(cboPresentacion, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);
                            if (cboDivision != null)
                                AltaCaracteristicas(cboDivision, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);
                            if (cboEstado != null)
                                AltaCaracteristicas(cboEstado, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);
                            if (cboLinea != null)
                                AltaCaracteristicas(cboLinea, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);
                            if (cboMarca != null)
                                AltaCaracteristicas(cboMarca, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);
                            if (cboMercado != null)
                                AltaCaracteristicas(cboMercado, listaArticulos[0].id_Articulos.ToString(), fkUsuarioLogin);
                            for (int i = 0; i < arCamposId.Length; i++)
                            {
                                Articulos_Valores ArtValores = new Articulos_Valores();
                                ArtValores.idArticulos_Campos = Convert.ToInt32(arCamposId[i]);
                                ArtValores.id_Articulos = Convert.ToInt32(listaArticulos[0].id_Articulos);
                                ArtValores.Valor = arCamposDatos[i];
                                ArtValores.fechaCr = DateTime.Now;
                                ArtValores.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                                _context.Articulos_Valores.Add(ArtValores);
                            }
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        listaArticulos = _context.Articulos.Where(p => p.id_Articulos != id).ToList();
                        cantidad = listaArticulos.Where(p => p.Nombre_Articulo.ToUpper() == articulos.Nombre_Articulo.ToUpper()).Count(); //Validación de registro no repetido
                        if (cantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var obj = _context.Articulos.Find(id);
                            obj.Nombre_Articulo = articulos.Nombre_Articulo;
                            obj.Producto_Venta = ProductoVenta;
                            obj.fechaUm = DateTime.Now;
                            obj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            //Modificacion de Cararteristicas
                            if (cboTipo != null)
                                ModificacionCaracteristicas(cboTipo, id.ToString(), fkUsuarioLogin);
                            if (cboPresentacion != null)
                                ModificacionCaracteristicas(cboPresentacion, id.ToString(), fkUsuarioLogin);
                            if (cboDivision != null)
                                ModificacionCaracteristicas(cboDivision, id.ToString(), fkUsuarioLogin);
                            if (cboEstado != null)
                                ModificacionCaracteristicas(cboEstado, id.ToString(), fkUsuarioLogin);
                            if (cboLinea != null)
                                ModificacionCaracteristicas(cboLinea, id.ToString(), fkUsuarioLogin);
                            if (cboMarca != null)
                                ModificacionCaracteristicas(cboMarca, id.ToString(), fkUsuarioLogin);
                            if (cboMercado != null)
                                ModificacionCaracteristicas(cboMercado, id.ToString(), fkUsuarioLogin);
                            for (int i = 0; i < arCamposId.Length; i++)
                            {
                                if(arCamposId[i]==""){
                                    continue;
                                }
                                var idValor = _context.Articulos_Valores.Where(c => c.id_Articulos == id && c.idArticulos_Campos == Convert.ToInt32(arCamposId[i])).ToList();
                                var objValores = _context.Articulos_Valores.Find(Convert.ToInt32(idValor[0].idArticulos_Valores));
                                objValores.Valor = arCamposDatos[i];
                                objValores.fechaUm = DateTime.Now;
                                objValores.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                            }
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                }
                else
                {
                    var query = (from state in ModelState.Values
                                 from error in state.Errors
                                 select error.ErrorMessage).ToList();
                    rpta += "<ul class='list-group'>";
                    query.Sort();
                    rpta += "<li class='list-group-item'>" + query[0].ToString() + "</li>";
                    rpta += "</ul>";
                    return rpta;
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
                List<Articulos> listaArticulos = new List<Articulos>();
                listaArticulos = _context.Articulos.Where(p => p.id_Articulos == id).ToList();
                listaArticulos[0].Activo = false;
                listaArticulos[0].fechaUm = DateTime.Now;
                listaArticulos[0].fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }


        //Alta de caracteristicas
        private void AltaCaracteristicas(string idCarateristica,string idArticulo,int fkUsuarioLogin)
        {
            var objCarateristica = _context.Carateristica_Valores.Where(p => p.id_Carateristica_Valores == Convert.ToInt32(idCarateristica)).ToList();
            Articulos_Carateristicas ArtCarateristicas = new Articulos_Carateristicas();
            ArtCarateristicas.id_Cararteristica = objCarateristica[0].id_Cararteristica;
            ArtCarateristicas.id_Carateristica_Valores = Convert.ToInt32(idCarateristica);
            ArtCarateristicas.id_Articulos = Convert.ToInt32(idArticulo);
            ArtCarateristicas.fechaCr = DateTime.Now;
            ArtCarateristicas.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
            _context.Articulos_Carateristicas.Add(ArtCarateristicas);
        }
        //Modificacion de caracteristicas
        private void ModificacionCaracteristicas(string idCarateristica, string idArticulo, int fkUsuarioLogin)
        {
            var objCarateristica = _context.Carateristica_Valores.Where(p => p.id_Carateristica_Valores == Convert.ToInt32(idCarateristica)).ToList();
            List<Articulos_Carateristicas> ArtCaracteristicas = new List<Articulos_Carateristicas>();
            ArtCaracteristicas = _context.Articulos_Carateristicas.Where(p => p.id_Articulos == Convert.ToInt32(idArticulo) && p.id_Cararteristica == objCarateristica[0].id_Cararteristica).ToList();            
            if (ArtCaracteristicas.Count > 0)
            {
                if (ArtCaracteristicas[0].id_Carateristica_Valores == Convert.ToInt32(idCarateristica))
                    return;
                var obj = _context.Articulos_Carateristicas.Find(ArtCaracteristicas[0].id_Articulos_Carateristicas);
                obj.id_Carateristica_Valores = Convert.ToInt32(idCarateristica);
                obj.fechaUm = DateTime.Now;
                obj.fkUsuarioUm = fkUsuarioLogin;
                _context.SaveChanges();
            }
            else
                AltaCaracteristicas(idCarateristica, idArticulo, fkUsuarioLogin);


            //var objValores = _context.Articulos_Valores.Find(Convert.ToInt32(idValor[0].idArticulos_Valores));
        }

        //Método para recuperar los datos del registro seleccionado
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var Articulo = _context.Articulos.Where(p => p.id_Articulos == id);
                
                return Ok(Articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para recuperar las cararteristicas del registro seleccionado
        public IActionResult recuperarCarateristicas(int id)
        {
            try
            {
                var Articulo = _context.Articulos_Carateristicas.Include(c => c.Carateristicas).Include(ca=>ca.Carateristica_Valores).AsNoTracking().Where(p => p.id_Articulos == id);

                return Ok(Articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para recuperar los campos detalles
        public IActionResult LlenarCamposDetallesNuevo()
        {
            try
            {
                var Articulo = _context.Articulos_Campos.Where(c => c.Habilitado == true);
                return Ok(Articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //Método para recuperar los campos detalles
        public IActionResult LlenarTablaNutrimentalNuevo(int idTablanuTrimental)
        {
            try
            {
                var Articulo = _context.Tabla_Nutrimental_Campos.Where(c =>  c.id_Tabla_Nutrimental== idTablanuTrimental);
                return Ok(Articulo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para recuperar los campos detalles
        public IActionResult LlenarCamposDetalles(int idArticulos)
        {
            try
            {
                string query = "";
                var Campos = _context.Articulos_Campos.Where(c => c.Habilitado == true);
                // var Valores = _context.Articulos_Valores.Include(c => c.Articulos_Campos).AsNoTracking().Where(p => p.id_Articulos == idArticulos).ToList();

                var Valores = _context.Articulos_Valores.FromSqlRaw("  SELECT artV.idArticulos_Valores, artC.idArticulos_Campos,artV.Valor,artV.fkUsuarioCr,artV.fechaCr,artV.fkUsuarioUm,artV.fechaUm,artV.id_Articulos " +
                                                                "      FROM Articulos_Valores AS artV " +
                                                                "      LEFT JOIN Articulos_Campos AS artC ON artC.idArticulos_Campos = artV.idArticulos_Campos " +
                                                                "      WHERE artV.id_Articulos = " + idArticulos + " " +


                                                                "      UNION " +
                                                                "      SELECT '' AS idArticulos_Valores, artC.idArticulos_Campos, '' AS Valor, '' AS fkUsuarioCr, '' AS fechaCr, '' AS fkUsuarioUm, '' AS fechaUm,'' AS id_Articulos " +
                                                                "      FROM Articulos_Campos AS artC " +
                                                                "      inner JOIN Articulos_Valores AS artV ON artC.idArticulos_Campos <> artV.idArticulos_Campos " +
                                                                "      WHERE artC.Habilitado = 1 AND artC.idArticulos_Campos  NOT IN(  " +
                                                                "      SELECT artV.idArticulos_Campos " +
                                                                "      FROM Articulos_Valores AS artV " +
                                                                "      LEFT JOIN Articulos_Campos AS artC ON artV.idArticulos_Campos = artV.idArticulos_Campos " +
                                                                "      WHERE artV.id_Articulos = " + idArticulos + " " +
                                                                "      )").Include(c => c.Articulos_Campos).AsNoTracking().ToList();
                return Ok(Valores);
            }
            catch (Exception)
            {
                throw;
            }
        }



        //Método para llenar el combo de Mercado del modal
        public void listarComboSMercado()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 1).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un mercado--",
                    Value = ""
                });
                ViewBag.listaMercado = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Presentacion del modal
        public void listarComboSPresentacion()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 4).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una presentación--",
                    Value = ""
                });
                ViewBag.listaPresentacion = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Estado del modal
        public void listarComboSEstado()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 5).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un estado--",
                    Value = ""
                });
                ViewBag.listaEstado= lista;
               
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Método para llenar el combo de Estado Busqueda del modal
        public void listarComboSEstadoBusq()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 5).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,                   
                    Text = "--Todos--",
                    Value = ""
                });
               
                ViewBag.listaEstadoBusq = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Tipo del modal
        public void listarComboSTipo()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 6).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un tipo--",
                    Value = ""
                });
                ViewBag.listaTipo = lista;

            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Tipo Bbusqueda del modal
        public void listarComboSTipoBusq()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 6).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Text = "--Todo--",
                    Value = ""
                });

                ViewBag.listaTipoBusq = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Linea del modal
        public void listarComboSLinea()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 7).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una línea--",
                    Value = ""
                });
                ViewBag.listaLinea = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Marca del modal
        public void listarComboSMarca()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 8).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una marca--",
                    Value = ""
                });
                ViewBag.listaMarca = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Division del modal
        public void listarComboSDivision()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 9).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una división--",
                    Value = ""
                });
                ViewBag.listaDivision = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Division busquedad del modal
        public void listarComboSDivisionBusq()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Carateristica_Valores.Where(p => p.id_Cararteristica == 9).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Valor,
                                          Value = x.id_Carateristica_Valores.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Text = "--Todos--",
                    Value = ""
                });
                ViewBag.listaDivisionBusq = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para llenar el combo de Division del modal
        public void listarComboSTablaNutrimental()
        {
            try
            {
                List<SelectListItem> lista;
                lista = _context.Tabla_Nutrimental.Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre_Tabla_Nutrimental,
                                          Value = x.id_Tabla_Nutrimental.ToString()
                                      }).ToList();
                lista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una tabla nutrimental--",
                    Value = ""
                });
                ViewBag.listaTablaNutrimental = lista;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
