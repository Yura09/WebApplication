#pragma checksum "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "46d98571ee549d58f318e869849c203fd38c4960"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"46d98571ee549d58f318e869849c203fd38c4960", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
  
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
.logoutLblPos{

   position:fixed;
   right:10px;
   top:5px;
}
table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
}
th, td {
  padding: 5px;
  text-align: left;    
}
</style>
<h3>users</h3>
<table>
   
        <div style=""padding-bottom: 10px"">
        <p>
            ");
#nullable restore
#line 28 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
       Write(Html.ActionLink("Create New", "Register","Account"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>
        </div>
    <tr>
        <td>
            <p>id</p>
        </td>
        <td>
            <p>first_name</p>
        </td>
        <td>
            <p>last_name</p>
        </td>
        <td>
            <p>email</p>
        </td>
        <td>
            <p>role</p>
        </td>
        <td>
            <p>active</p>
        </td>

    </tr>
");
#nullable restore
#line 52 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 56 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.user_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 59 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.first_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 62 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.last_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 65 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 68 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 71 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
                 using (Html.BeginForm("Active", "User", FormMethod.Post))
                {
                    User user = item;


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <fieldset>\r\n                        ");
#nullable restore
#line 76 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
                   Write(Html.HiddenFor(m => user.user_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n                        <p>\r\n                            ");
#nullable restore
#line 80 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
                       Write(Html.CheckBoxFor(m => user.active, new {id = user.user_id, onchange = "this.form.submit()"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                        </p>\r\n\r\n                      \r\n                    </fieldset>\r\n");
#nullable restore
#line 86 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 89 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
           Write(Html.ActionLink("Get", "GetUserData", new {id = item.user_id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
#nullable restore
#line 93 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 94 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
     using (Html.BeginForm("Logout", "Account", FormMethod.Get))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label class=\"logoutLblPos\">\r\n            <input name=\"submit2\" type=\"submit\" id=\"submit2\" value=\"log out\">\r\n        </label>\r\n");
#nullable restore
#line 99 "C:\Users\Yura\RiderProjects\WebApplication\WebApplication\Views\User\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
