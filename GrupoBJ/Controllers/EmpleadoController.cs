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
    public class EmpleadoController : Controller
    {
        #region "Variables globales"
        private readonly GrupoBJDBContext _context;
        StringBuilder sbConsulta = new StringBuilder();

        #endregion
         
        #region "Constructor"

        public EmpleadoController(GrupoBJDBContext context)
        {
            _context = context;
        }
        #endregion

        #region "Load"
        //Método que se ejecuta al incio y carga la vista
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                listarComboPais();
                listarComboEstado();
                listarComboCiudad();
                listarComboSucursal();
                listarComboDepartamento();
                listarComboPuesto();
                listarComboTurno();
                listarComboBanco();
                listarComboEstadoCivil();
                listarComboEmpresa();
                listarComboFiltroSucursal();
                listarComboFiltroEmpresa();
                List<Empleado> liListaEmpleado = new List<Empleado>();
                liListaEmpleado = _context.Empleado.Include
                    (c => c.Sucursal.Empresa)
                    .Include(c => c.Puesto.Departamento)
                    .AsNoTracking().ToList(); //Incluir la información de la empresa (Relacion)
                liListaEmpleado = liListaEmpleado.Where(p => p.Habilitado == true).ToList();

                return View(liListaEmpleado);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region "Carga de datos"

        //Método para cargar los países
        public void listarComboPais()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Pais.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idPais.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un país--",
                    Value = ""
                });
                ViewBag.listaPais = liLista;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Método para cargar los estados
        public void listarComboEstado()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Estado.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idEstado.ToString()
                                      }).ToList();
                ViewBag.listaEstado = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar las ciudad
        public void listarComboCiudad()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Ciudad.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idCiudad.ToString()
                                      }).ToList();
                ViewBag.listaCiudad = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar las sucursales
        public void listarComboSucursal()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Sucursal.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idSucursal.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione una sucursal--",
                    Value = ""
                });
                ViewBag.listaSucursal = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar las empresas
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

        //Método para cargar los puestos
        public void listarComboPuesto()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Puesto.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idPuesto.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un puesto--",
                    Value = ""
                });
                ViewBag.listaPuesto = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar los departamentos
        public void listarComboDepartamento()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Departamento.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idDepartamento.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un departamento--",
                    Value = ""
                });
                ViewBag.listaDepartamento = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar los bancos
        public void listarComboBanco()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Banco.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idBanco.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un banco--",
                    Value = ""
                });
                ViewBag.listaBanco = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar el estado civil
        public void listarComboEstadoCivil()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Estado_Civil.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idEstadoCivil.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un estado civil--",
                    Value = ""
                });
                ViewBag.listaEstadoCivil = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para cargar los horarios
        public void listarComboTurno()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Turnos.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.nombre,
                                          Value = x.idTurno.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem
                {
                    Selected = true,
                    Disabled = true,
                    Text = "--Seleccione un turno--",
                    Value = ""
                });
                ViewBag.listaTurno = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para el combo de filtrar empresa
        public void listarComboFiltroEmpresa()
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
                liLista.Insert(0, new SelectListItem { Text = "Todas las empresas", Value = "" });
                ViewBag.listaFiltroEmpresa = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método para el combo de filtrar sucursal
        public void listarComboFiltroSucursal()
        {
            try
            {
                List<SelectListItem> liLista;
                liLista = _context.Sucursal.Where(p => p.Habilitado == true).Select(x =>
                                      new SelectListItem()
                                      {
                                          Text = x.Nombre,
                                          Value = x.idSucursal.ToString()
                                      }).ToList();
                liLista.Insert(0, new SelectListItem { Text = "Todas las sucursales", Value = "" });
                ViewBag.listaFiltroSucursal = liLista;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region "Funciones CRUD"
        //Método para filtrar la tabla con el buscador o combos
        public ActionResult Filtro(string BuscadorEmpleado, int? filtroComboEmpresa, int? filtroComboSucursal, string datosFiltro) //Filtro por textbox
        {
            try
            {
                // string consultaLike;
                string[] asArregloFiltro = datosFiltro.TrimStart('[').TrimEnd(']').Split(',');
                List<Empleado> liListarEmpleado = new List<Empleado>();
                string consultaLike;
                sbConsulta.Remove(0, sbConsulta.Length);
                sbConsulta.AppendLine("SELECT Em.idEmpleado, Em.Nombre, Em.apPaterno, Em.apMaterno, Em.CURP, Em.IMSS, Em.fkEstadoCivil, Em.RFC, ");
                sbConsulta.AppendLine("Em.fechaNacimiento, Em.Fotografia, Em.Telefono, Em.Celular, Em.Fax, Em.correoElectronico, ");
                sbConsulta.AppendLine("Em.cuentaBancaria, Em.fkBanco, Em.clabeInterbancaria, Em.Calle, Em.Colonia, Em.numeroInterior, ");
                sbConsulta.AppendLine("Em.numeroExterior, Em.codigoPostal, Em.Cardinalidad, Em.fkCiudad, Em.sueldoDiario, ");
                sbConsulta.AppendLine("Em.fkPuesto, Em.fkSucursal, Em.Habilitado, Em.fechaCr, Em.fkUsuarioCr, Em.fechaUm, ");
                sbConsulta.AppendLine("Em.afectado, Em.afectadoExtraordinario, Em.ajusteAlNeto, Em.altaImss, Em.bajaImss, Em.baseCotizacionImss, ");
                sbConsulta.AppendLine("Em.basePago, Em.calculado, Em.calculadoExtraordinario, Em.calculoAguinaldo, Em.calculoptu, ");
                sbConsulta.AppendLine("Em.cambioCotizacionImss, Em.causaBaja, Em.centroCosto, Em.codigoEmpleado, Em.diasPrimaVacTomadasAntesDeAlta, ");
                sbConsulta.AppendLine("Em.diasVacacionesTomadasAntesDeAlta, Em.estadoEmpleado, Em.estadoEmpleadoPeriodo, Em.extranjeroSinCurp, ");
                sbConsulta.AppendLine("Em.fechaAlta, Em.fechaBaja, Em.fechaSueldoDiario, Em.fechaSueldoIntegrado, Em.fechaSueldoMixto, ");
                sbConsulta.AppendLine("Em.fechaSueldoPromedio, Em.fechaSueldoVariable, Em.fkDepartamento, Em.fkRegistroPatronal, Em.fkTipoPeriodo, Em.fkTurno, ");
                sbConsulta.AppendLine("Em.formaPago, Em.iut, Em.lugarNacimiento, Em.modificacionSalarioImss, Em.nombreMadre, Em.nombrePadre, ");
                sbConsulta.AppendLine("Em.numeroAfore, Em.numeroFonacot, Em.porcentajePensionAlimenticia, Em.sexo, Em.subcontratacion, ");
                sbConsulta.AppendLine("Em.sucursalBanco, Em.sueldoBaseLiquidacion, Em.sueldoIntegrado, Em.sueldoMixto, Em.sueldoNetoMensual, ");
                sbConsulta.AppendLine("Em.sueldoPromedio, Em.sueldoVariable, Em.tipoContrato, Em.tipoEmpleado, Em.tipoPrestacion, ");
                sbConsulta.AppendLine("Em.tipoRegimen, Em.umf, Em.zonaSalario,");
                sbConsulta.AppendLine("Em.fkUsuarioUm  FROM Empleado AS Em ");
                sbConsulta.AppendLine("INNER JOIN Sucursal AS S ON S.idSucursal = Em.fkSucursal ");
                sbConsulta.AppendLine("INNER JOIN Empresa AS Ep ON S.fkEmpresa = Ep.idEmpresa ");
                sbConsulta.AppendLine("INNER JOIN Puesto AS P ON P.idPuesto = Em.fkPuesto ");
                sbConsulta.AppendLine("INNER JOIN Departamento AS D ON D.idDepartamento = P.fkDepartamento ");
                sbConsulta.AppendLine("WHERE Em.Habilitado = 1 AND ");
                consultaLike = sbConsulta.ToString();
                

                if (filtroComboSucursal == null && filtroComboEmpresa == null)
                {
                    consultaLike +=  "(";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%')";
                    }
                    liListarEmpleado = _context.Empleado.FromSqlRaw(consultaLike).Include(c => c.Sucursal.Empresa).Include(c => c.Puesto.Departamento).ToList();
                }
                else if(filtroComboEmpresa == null && filtroComboSucursal != null)
                {
                    consultaLike = consultaLike + "fkSucursal = "+filtroComboSucursal+" AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%')";
                    }
                    liListarEmpleado = _context.Empleado.FromSqlRaw(consultaLike).Include(c => c.Sucursal.Empresa).Include(c => c.Puesto.Departamento).ToList();
                }
                else if (filtroComboEmpresa != null && filtroComboSucursal == null)
                {
                    consultaLike +=  "S.fkEmpresa = " + filtroComboEmpresa + " AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%')";
                    }
                    liListarEmpleado = _context.Empleado.FromSqlRaw(consultaLike).Include(c => c.Sucursal.Empresa).Include(c => c.Puesto.Departamento).ToList();
                }
                else if (filtroComboEmpresa != null && filtroComboSucursal != null)
                {
                    consultaLike +=  "S.fkEmpresa = " + filtroComboEmpresa + " AND fkSucursal = "+filtroComboSucursal+" AND (";
                    for (int i = 0; i < asArregloFiltro.Length; i++)
                    {
                        if (i != asArregloFiltro.Length - 1)
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%' OR ";
                        else
                            consultaLike +=  asArregloFiltro[i] + " LIKE '%" + BuscadorEmpleado + "%')";
                    }
                    liListarEmpleado = _context.Empleado.FromSqlRaw(consultaLike).Include(c => c.Sucursal.Empresa).Include(c => c.Puesto.Departamento).ToList();
                }
                return PartialView("_TablaEmpleado", liListarEmpleado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Método guardar los datos (Insersión o Modificación)
        [HttpPost]
        public string Guardar(Empleado empleado, int? id, int fkSucursal, int fkPuesto)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                string stRpta = "";
                if (ModelState.IsValid)
                {
                    int inCantidad = 0;
                    List<Empleado> liListaEmpleado = new List<Empleado>();
                    if (id.Equals(-1)) //Insertar
                    {
                        liListaEmpleado = _context.Empleado.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaEmpleado.Where(
                            p => (p.Nombre.ToUpper() == empleado.Nombre.ToUpper()
                            && p.apPaterno.ToUpper() == empleado.apPaterno.ToUpper() 
                            && p.apMaterno.ToUpper()==empleado.apMaterno.ToUpper()
                            && p.CURP.ToUpper() == empleado.CURP.ToUpper()) 
                            || p.CURP .ToUpper() == empleado.CURP.ToUpper()).Count(); //Validación de repetido
                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            empleado.Habilitado = true;
                            empleado.fechaCr = DateTime.Now;
                            empleado.fkUsuarioCr = fkUsuarioLogin; //Se reempleaza por el usuario logueado
                            _context.Empleado.Add(empleado);
                            _context.SaveChanges();
                            return "1";
                        }
                    }
                    else  //Modificar
                    {
                        liListaEmpleado = _context.Empleado.Where(p => p.Habilitado == true).ToList();
                        inCantidad = liListaEmpleado.Where(
                            p => (p.Nombre.ToUpper() == empleado.Nombre.ToUpper()
                            && p.apPaterno.ToUpper() == empleado.apPaterno.ToUpper()
                            && p.apMaterno.ToUpper() == empleado.apMaterno.ToUpper()
                            && p.CURP.ToUpper() == empleado.CURP.ToUpper()
                            && p.idEmpleado != id) 
                            || p.CURP.ToUpper() == empleado.CURP.ToUpper() && p.idEmpleado != id).Count(); //Validación de repetido

                        if (inCantidad >= 1) //Si existe el registro
                        {
                            return "-1"; //Registro se encuentra de BD
                        }
                        else
                        {
                            var vaObj = _context.Empleado.Find(id);
                            vaObj.Nombre = empleado.Nombre;
                            vaObj.apPaterno = empleado.apPaterno;
                            vaObj.apMaterno = empleado.apMaterno;
                            vaObj.CURP = empleado.CURP;
                            vaObj.IMSS = empleado.IMSS;
                            vaObj.fkEstadoCivil = empleado.fkEstadoCivil;
                            vaObj.fechaNacimiento = empleado.fechaNacimiento;
                            vaObj.Fotografia = empleado.Fotografia;
                            vaObj.Telefono = empleado.Telefono;
                            vaObj.Celular = empleado.Celular;
                            vaObj.Fax = empleado.Fax;
                            vaObj.correoElectronico = empleado.correoElectronico;
                            vaObj.cuentaBancaria = empleado.cuentaBancaria;
                            vaObj.fkBanco = empleado.fkBanco;
                            vaObj.clabeInterbancaria = empleado.clabeInterbancaria;
                            vaObj.Calle = empleado.Calle;
                            vaObj.Colonia = empleado.Colonia;
                            vaObj.numeroInterior = empleado.numeroInterior;
                            vaObj.numeroExterior = empleado.numeroExterior;
                            vaObj.codigoPostal = empleado.codigoPostal;
                            vaObj.Cardinalidad = empleado.Cardinalidad;
                            vaObj.fkCiudad = empleado.fkCiudad;
                            vaObj.fkTurno = empleado.fkTurno;
                            vaObj.sueldoDiario = empleado.sueldoDiario;
                            vaObj.fkPuesto = empleado.fkPuesto;
                            vaObj.fkSucursal = empleado.fkSucursal;
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
            catch (Exception)
            {
                return "";
            }
        }

        //Función para deshabilitar un registro cuando se va a eliminar
        public string eliminar(int id)
        {
            try
            {
                int fkUsuarioLogin = (int)HttpContext.Session.GetInt32("UsuarioSession");
                var vaObj = _context.Empleado.Find(id);
                vaObj.Habilitado = false;
                vaObj.fechaUm = DateTime.Now;
                vaObj.fkUsuarioUm = fkUsuarioLogin; //Se reemplaza por el usuario que se logueo
                _context.SaveChanges();
                return "1";
            }
            catch (Exception)
            {
                return ""; //Error
            }
        }

        #endregion

        #region "Querys"

        //Método para recuperar los datos del registro seleccionado
        public IActionResult recuperarDatos(int id)
        {
            try
            {
                var vaEmpleado = _context.Empleado.Find(id);
                return Ok(vaEmpleado);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //-----------------------Recuperar datos para modificar------------------

        public IActionResult recuperarDatosCiudad(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Find(id);
                return Ok(vaCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IActionResult recuperarDatosEstado(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Find(id);
                return Ok(vaCiudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult recuperarDatosPais(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Find(id);
                var vaEstado = _context.Estado.Find(vaCiudad.fkEstado);
                return Ok(vaEstado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //------------------------------Cargar los datos de ciudad y estado-----------------------------------------
        public IActionResult actualizarEstado(int id)
        {
            try
            {
                var vaEstado = _context.Estado.Where(p => p.fkPais == id && p.Habilitado == true).ToList();
                return Ok(vaEstado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult actualizarCiudad(int id)
        {
            try
            {
                var vaCiudad = _context.Ciudad.Where(p => p.fkEstado == id && p.Habilitado == true).ToList();
                return Ok(vaCiudad);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //------------------------------------------------------------------------------------------------
        //-------------------Recuperar datos de sucursal, empresa, departamento y puesto----------------
        public IActionResult recuperarDatosEmpresa(int id)
        {
            try
            {
                var vaEmpresa = _context.Sucursal.Find(id);
                return Ok(vaEmpresa);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult recuperarDatosDepartamento(int id)
        {
            try
            {
                var vaDepartamento = _context.Puesto.Find(id);
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //--------------------------------------------------------------------------------------------------


        //---------------------Funciones para llenar los combos dinamicamente---------------------------------------
        public IActionResult actualizarDepartamento(int id)
        {
            try
            {
                var vaDepartamento = _context.Departamento.Where(p => p.fkEmpresa == id & p.Habilitado == true).ToList();
                return Ok(vaDepartamento);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult actualizarSucursal(int id)
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

        public IActionResult actualizarPuesto(int id)
        {
            try
            {
                var vaPuesto = _context.Puesto.Where(p => p.fkDepartamento == id & p.Habilitado == true).ToList();
                return Ok(vaPuesto);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //-----------------------------------------------------------------------------------------------------------
        //------------------------Actualizar combo de filtro de sucursal
        public IActionResult actualizarComboFitroSucursal(int id)
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

        //Método para recuperar los datos del registro a eliminar
        public IActionResult recuperarDatosEliminar(int id)
        {
            try
            {
                var vaEmpleado = _context.Empleado.Include(c => c.Sucursal.Empresa).Where(p => p.idEmpleado == id && p.Habilitado == true).ToList();
                return Ok(vaEmpleado);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
