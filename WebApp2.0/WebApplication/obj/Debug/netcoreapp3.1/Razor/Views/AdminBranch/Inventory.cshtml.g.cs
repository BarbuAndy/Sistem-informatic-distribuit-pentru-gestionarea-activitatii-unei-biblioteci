#pragma checksum "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5fda3e5998badcc0364164ff8239a7b8a427b3ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminBranch_Inventory), @"mvc.1.0.view", @"/Views/AdminBranch/Inventory.cshtml")]
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
#line 1 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\_ViewImports.cshtml"
using WebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5fda3e5998badcc0364164ff8239a7b8a427b3ab", @"/Views/AdminBranch/Inventory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa0ef8da47a84ffb33e8bc853509aa4fa5703a26", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminBranch_Inventory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebApplication.Models.BranchModel>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
  
    ViewData["Title"] = "Inventory";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5fda3e5998badcc0364164ff8239a7b8a427b3ab3425", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\"");
                BeginWriteAttribute("href", " href=\"", 208, "\"", 250, 1);
#nullable restore
#line 9 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
WriteAttributeValue("", 215, Url.Content("~/CSS/inventory.css"), 215, 35, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <link rel=\"stylesheet\" type=\"text/css\"");
                BeginWriteAttribute("href", " href=\"", 298, "\"", 343, 1);
#nullable restore
#line 10 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
WriteAttributeValue("", 305, Url.Content("~/CSS/accountStyle.css"), 305, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <script src=\"https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js\"></script>\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<style>
.content-table{
                border-collapse:collapse;
                 margin-left:auto;
                 margin-right:auto;

                 font-size:1.5em;
                 min-width:400px;
                 border-radius: 5px 5px 0 0;
                 overflow:hidden ;
                 box-shadow: 0  0 20px rgba(0,0,0,15)
    }
    .content-table thead tr{
        background-color:#009879;
        color:#ffffff;
        text-align:left;
        font-weight:bold;
    }
    .content-table th,
    .content-table td{
        padding:5px 15px;
    }
    .content-table tbody tr{
        border-bottom:1px solid #000000;

    }
    .content-table tbody tr:nth-of-type(even){
        background-color :gainsboro;

    }
    .content-table tbody tr:last-of-type{
        border-bottom:3px solid #000000;
    }
    </style >

    <div class=""container"" >
    <table class=""content-table"" border=""1"" id=""branchesInventory"" >
    <thead >
    <tr >
    <th >
    ");
#nullable restore
#line 56 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </th >\r\n    <th >\r\n    ");
#nullable restore
#line 59 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
Write(Html.DisplayNameFor(model => model.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </th >\r\n    <th >\r\n    Books available\r\n    </th >\r\n    </tr >\r\n    </thead >\r\n    <tbody >\r\n");
#nullable restore
#line 67 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
     foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                 <tr >\r\n    <td >\r\n    ");
#nullable restore
#line 71 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td >\r\n    <td >\r\n    ");
#nullable restore
#line 74 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
Write(Html.DisplayFor(modelItem => item.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td >\r\n    <td >\r\n    ");
#nullable restore
#line 77 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
Write(ViewData[item.Name]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </td >\r\n    </tr >\r\n");
#nullable restore
#line 80 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody >
    </table >
    </div >


    <script type=""text/javascript"" >
    $('#branchesInventory').find('tr').click(function () {
        var branch = $(this).find('td:first').text().trim();
        console.log(branch);
        window.location.href = '");
#nullable restore
#line 90 "E:\facultate\Proiect Databases\WebApp2.0\WebApplication\Views\AdminBranch\Inventory.cshtml"
                           Write(Url.Action("SpecificInventory", "Inventory"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\' + \"?branch=\" + branch;\r\n\r\n    });\r\n    </script >\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebApplication.Models.BranchModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
