#pragma checksum "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4181c99aaf6495f4a9808e614affe2041ce83313"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TablaNutrimental__TablaNutrimentalMaestro), @"mvc.1.0.view", @"/Views/TablaNutrimental/_TablaNutrimentalMaestro.cshtml")]
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
#line 1 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\_ViewImports.cshtml"
using GrupoBJ;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\_ViewImports.cshtml"
using GrupoBJ.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4181c99aaf6495f4a9808e614affe2041ce83313", @"/Views/TablaNutrimental/_TablaNutrimentalMaestro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"79f2c547ea4ceb33512a41ebbf7d7e60ee20d777", @"/Views/_ViewImports.cshtml")]
    public class Views_TablaNutrimental__TablaNutrimentalMaestro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GrupoBJ.Models.Tabla_Nutrimental>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
#nullable restore
#line 4 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
 if (Model.Count() > 0)
{

    

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td hidden>");
#nullable restore
#line 10 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
          Write(Html.DisplayFor(m => item.id_Tabla_Nutrimental));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 11 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
   Write(Html.DisplayFor(m => item.Nombre_Tabla_Nutrimental));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td style=\"text-align: center;\">");
#nullable restore
#line 12 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
                               Write(Html.DisplayFor(m => item.Activo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 13 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
   Write(Html.DisplayFor(m => item.Carateristica_Valores.Valor));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 14 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
   Write(Html.DisplayFor(m => item.fkUsuarioCr));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 15 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
   Write(Html.DisplayFor(m => item.fechaCr));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 16 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
   Write(Html.DisplayFor(m => item.fkUsuarioUm));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 17 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
   Write(Html.DisplayFor(m => item.fechaUm));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n</tr>\n");
#nullable restore
#line 20 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
     

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n    <p>No hay registros</p>\n");
#nullable restore
#line 27 "C:\Users\PC-TI-DEV04\Documents\Proyectos\GitHub\GrupoBJ-Clon\GrupoBJ\Views\TablaNutrimental\_TablaNutrimentalMaestro.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GrupoBJ.Models.Tabla_Nutrimental>> Html { get; private set; }
    }
}
#pragma warning restore 1591
