#pragma checksum "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dbe16d6fb57c32eaa9a538de36125fd22dc2c151"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client_Index), @"mvc.1.0.view", @"/Views/Client/Index.cshtml")]
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
#line 1 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\_ViewImports.cshtml"
using lab7;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\_ViewImports.cshtml"
using lab7.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dbe16d6fb57c32eaa9a538de36125fd22dc2c151", @"/Views/Client/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3e2db9983bc4f93cfc5376bb01f80796fd35aa0", @"/Views/_ViewImports.cshtml")]
    public class Views_Client_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<lab7.Models.Client>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
  
    ViewData["Title"] = "Client Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    ");
#nullable restore
#line 8 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
Write(Html.ActionLink("Add user", "Add"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 10 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
     if (Model.Count > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table>\r\n            <tr>\r\n                <th>Id</th>\r\n                <th>Имя</th>\r\n                <th>Фамилия</th>\r\n                <th>Отчество</th>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 20 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 24 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
                   Write(Html.DisplayFor(model => item.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 28 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
                   Write(Html.DisplayFor(model => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 32 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
                   Write(Html.DisplayFor(model => item.SecondName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 36 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
                   Write(Html.DisplayFor(model => item.ThirdName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
                   Write(Html.ActionLink(" Edit ", "Edit", new { id = item.Id, item }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 41 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
                   Write(Html.ActionLink(" Delete ", "Delete", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
#nullable restore
#line 45 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </table>\r\n");
#nullable restore
#line 47 "C:\Users\User\Desktop\lab7\lab7\lab7\Views\Client\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<lab7.Models.Client>> Html { get; private set; }
    }
}
#pragma warning restore 1591
