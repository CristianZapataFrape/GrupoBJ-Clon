#pragma checksum "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04b7638fa0bbaf61f5841fcdcf693bc3e81a5af4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Banco__TablaBanco), @"mvc.1.0.view", @"/Views/Banco/_TablaBanco.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"04b7638fa0bbaf61f5841fcdcf693bc3e81a5af4", @"/Views/Banco/_TablaBanco.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f2c547ea4ceb33512a41ebbf7d7e60ee20d777", @"/Views/_ViewImports.cshtml")]
    public class Views_Banco__TablaBanco : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GrupoBJ.Models.Banco>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
 if (Model.Count() > 0)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td hidden>");
#nullable restore
#line 7 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
              Write(Html.DisplayFor(m => item.idBanco));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tBan-Codigo\">");
#nullable restore
#line 8 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
                                  Write(Html.DisplayFor(m => item.Codigo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tBan-Banco\">");
#nullable restore
#line 9 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
                                 Write(Html.DisplayFor(m => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tBan-Clave\">");
#nullable restore
#line 10 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
                                 Write(Html.DisplayFor(m => item.Clave));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td hidden class=\"tBan-RFC\">");
#nullable restore
#line 11 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
                               Write(Html.DisplayFor(m => item.RFC));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    </tr>\n");
#nullable restore
#line 13 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n    <p>No hay registros</p>\n");
#nullable restore
#line 19 "C:\Users\PC-TI-DEV04\Documents\GrupoBJ-master\GrupoBJ\GrupoBJ\Views\Banco\_TablaBanco.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GrupoBJ.Models.Banco>> Html { get; private set; }
    }
}
#pragma warning restore 1591