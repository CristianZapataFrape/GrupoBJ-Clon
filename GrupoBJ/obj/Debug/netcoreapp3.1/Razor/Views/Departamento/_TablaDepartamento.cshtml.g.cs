#pragma checksum "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf870336a7a094f800618f7fa2c748baec44ae4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamento__TablaDepartamento), @"mvc.1.0.view", @"/Views/Departamento/_TablaDepartamento.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf870336a7a094f800618f7fa2c748baec44ae4d", @"/Views/Departamento/_TablaDepartamento.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f2c547ea4ceb33512a41ebbf7d7e60ee20d777", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamento__TablaDepartamento : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GrupoBJ.Models.Departamento>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
 if (Model.Count() > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td hidden>");
#nullable restore
#line 8 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
              Write(Html.DisplayFor(m => item.idDepartamento));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tDep-Empresa\">");
#nullable restore
#line 9 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
                                   Write(Html.DisplayFor(m => item.Empresa.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tDep-Departamento\">");
#nullable restore
#line 10 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
                                        Write(Html.DisplayFor(m => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n");
#nullable restore
#line 12 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n    <p>No hay registros</p>\n");
#nullable restore
#line 18 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Departamento\_TablaDepartamento.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GrupoBJ.Models.Departamento>> Html { get; private set; }
    }
}
#pragma warning restore 1591