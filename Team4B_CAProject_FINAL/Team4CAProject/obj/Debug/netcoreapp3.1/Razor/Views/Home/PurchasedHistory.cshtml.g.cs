#pragma checksum "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0019fbbfc7fcb1027a925da3def4ab8419788d7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PurchasedHistory), @"mvc.1.0.view", @"/Views/Home/PurchasedHistory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0019fbbfc7fcb1027a925da3def4ab8419788d7b", @"/Views/Home/PurchasedHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57549f290811d8d22fa228a2a8e48a3aa9d17807", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PurchasedHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Cart>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
   
    Layout = "_IndexLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div id=""purchased"" class=""container"">
    <div class=""row col-md-10 col-md-offset-1 custyle"">
        <table class=""table table-striped custab"">
            <thead>
                <tr>
                    <th>CartId</th>
                    <th>Quantity</th>
                    <th>Cost</th>
                    <th>Time</th>
                    <th></th>
                </tr>
            </thead>
");
#nullable restore
#line 18 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
              
                foreach (Cart cart in Model)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 23 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
                       Write(cart.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
                       Write(cart.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
                       Write(cart.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 26 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
                       Write(cart.CheckoutTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=", 803, "", 849, 1);
#nullable restore
#line 27 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
WriteAttributeValue("", 809, "/Home/MyPurchase?cartId=" + @cart.Id, 809, 40, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><span class=\"glyphicon glyphicon-list-alt\"></span></a></td>\r\n                    </tr>\r\n");
#nullable restore
#line 29 "E:\ISS_NUS\NETCORE\CA\Team4B_CAProject_Final\Team4B_CAProject_Final\Team4B_CAProject_FINAL\Team4CAProject\Views\Home\PurchasedHistory.cshtml"
                }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Cart>> Html { get; private set; }
    }
}
#pragma warning restore 1591
