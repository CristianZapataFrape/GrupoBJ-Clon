#pragma checksum "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1149868bf9ca2442db3ba1aacb9e3a0e6fd8847a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Puesto__TablaPuesto), @"mvc.1.0.view", @"/Views/Puesto/_TablaPuesto.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1149868bf9ca2442db3ba1aacb9e3a0e6fd8847a", @"/Views/Puesto/_TablaPuesto.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f2c547ea4ceb33512a41ebbf7d7e60ee20d777", @"/Views/_ViewImports.cshtml")]
    public class Views_Puesto__TablaPuesto : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GrupoBJ.Models.Puesto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
 if (Model.Count() > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td hidden>");
#nullable restore
#line 7 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
              Write(Html.DisplayFor(m => item.idPuesto));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tPue-Empresa\">");
#nullable restore
#line 8 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
                                   Write(Html.DisplayFor(m => item.Departamento.Empresa.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tPue-Departamento\">");
#nullable restore
#line 9 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
                                        Write(Html.DisplayFor(m => item.Departamento.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tPue-Puesto\">");
#nullable restore
#line 10 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
                                  Write(Html.DisplayFor(m => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n");
#nullable restore
#line 12 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n    <p>No hay registros</p>\n");
#nullable restore
#line 18 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Puesto\_TablaPuesto.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GrupoBJ.Models.Puesto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
