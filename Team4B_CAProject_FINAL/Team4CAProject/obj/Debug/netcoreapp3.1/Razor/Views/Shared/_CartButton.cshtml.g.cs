#pragma checksum "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Shared\_CartButton.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bad238f986c9157d9eb6e9d1cc34e6864b11138c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CartButton), @"mvc.1.0.view", @"/Views/Shared/_CartButton.cshtml")]
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
#line 1 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\_ViewImports.cshtml"
using Team4CAProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\_ViewImports.cshtml"
using Team4CAProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bad238f986c9157d9eb6e9d1cc34e6864b11138c", @"/Views/Shared/_CartButton.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57549f290811d8d22fa228a2a8e48a3aa9d17807", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CartButton : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<a id=\"cartButton\" class=\"nav-link\" href=\"/Home/ViewCart\">\r\n    <i class=\"fa fa-globe\">\r\n");
#nullable restore
#line 3 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Shared\_CartButton.cshtml"
         if ((int)ViewData["ItemCount"] == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"glyphicon glyphicon-shopping-cart\"></span>\r\n");
#nullable restore
#line 6 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Shared\_CartButton.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <span class=\"glyphicon glyphicon-shopping-cart\">");
#nullable restore
#line 9 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Shared\_CartButton.cshtml"
                                                       Write(ViewData["ItemCount"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 10 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Shared\_CartButton.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </i>\r\n</a>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
