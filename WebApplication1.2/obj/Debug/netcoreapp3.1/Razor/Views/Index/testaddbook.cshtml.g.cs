#pragma checksum "E:\Coduri2.0\Semestru 2 jale\WebApplication\Views\Index\testaddbook.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ea5cd5870632462cfd8f09e6e3edbecf9283036"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Index_testaddbook), @"mvc.1.0.view", @"/Views/Index/testaddbook.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ea5cd5870632462cfd8f09e6e3edbecf9283036", @"/Views/Index/testaddbook.cshtml")]
    public class Views_Index_testaddbook : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication.context.Book>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Coduri2.0\Semestru 2 jale\WebApplication\Views\Index\testaddbook.cshtml"
  
    ViewData["Title"] = "testaddbook";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>testaddbook</h1>

<h4>Book</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""testaddbook"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group"">
                <label asp-for=""BookId"" class=""control-label"" ></label>
                <input asp-for=""BookId"" class=""form-control"" />
                <span asp-validation-for=""BookId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Title"" class=""control-label""></label>
                <input asp-for=""Title"" class=""form-control"" />
                <span asp-validation-for=""Title"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""AuthorId"" class=""control-label""></label>
                <select asp-for=""AuthorId"" class =""form-control"" asp-items=""ViewBag.AuthorId""></select>
            </div>
            <div class=""");
            WriteLiteral("form-group\">\r\n                <input type=\"submit\" value=\"Create\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication.context.Book> Html { get; private set; }
    }
}
#pragma warning restore 1591
