#pragma checksum "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6b72024acd6878104f7f101cb716157efc854e3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login__TablaEmpresaSucursal), @"mvc.1.0.view", @"/Views/Login/_TablaEmpresaSucursal.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\_ViewImports.cshtml"
using GrupoBJ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\_ViewImports.cshtml"
using GrupoBJ.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6b72024acd6878104f7f101cb716157efc854e3e", @"/Views/Login/_TablaEmpresaSucursal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f2c547ea4ceb33512a41ebbf7d7e60ee20d777", @"/Views/_ViewImports.cshtml")]
    public class Views_Login__TablaEmpresaSucursal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GrupoBJ.Models.Usuario_Empresa_Sucursal_Sis_Per>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""table-responsive"">
        <table class=""table table-bordered table-hover table-striped no-seleccionable"" id=""tablaEmpresaSucursal"">
            <thead>
                <tr>
                    <th style=""width:45%"">Empresa</th>
                    <th style=""width:45%"">Sucursal</th>
                    <th style=""width:10%; text-align:center;"">Sel.</th>

                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 16 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
                 foreach (var item in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\n                        <td>");
#nullable restore
#line 20 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
                       Write(Html.DisplayFor(m => item.Empresa.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td>");
#nullable restore
#line 21 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
                       Write(Html.DisplayFor(m => item.Sucursal.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                        <td style=\"text-align:center\">\n                            <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 878, "\"", 915, 3);
            WriteAttributeValue("", 888, "Seleccionar(", 888, 12, true);
#nullable restore
#line 23 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
WriteAttributeValue("", 900, item.fkPerfil, 900, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 914, ")", 914, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">\n                                <i class=\"fa fa-edit\"></i>\n                            </button>\n                        </td>\n                    </tr>\n");
#nullable restore
#line 28 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n    </div>\n");
#nullable restore
#line 32 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>No hay registros</p>\n");
#nullable restore
#line 36 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Login\_TablaEmpresaSucursal.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GrupoBJ.Models.Usuario_Empresa_Sucursal_Sis_Per>> Html { get; private set; }
    }
}
#pragma warning restore 1591
