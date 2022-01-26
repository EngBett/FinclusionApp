#pragma checksum "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b33a297254fb911dfd140f454b477d4b3d2e3c35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Checkout), @"mvc.1.0.view", @"/Views/Shop/Checkout.cshtml")]
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
#line 1 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\_ViewImports.cshtml"
using AccManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\_ViewImports.cshtml"
using AccManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\_ViewImports.cshtml"
using AccManagement.Data.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b33a297254fb911dfd140f454b477d4b3d2e3c35", @"/Views/Shop/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7039e4da5799ff8759f5b3df1a8aadf6d719d02", @"/Views/_ViewImports.cshtml")]
    public class Views_Shop_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProductViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Shop", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("cart"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display: none;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
  
    ViewData["Title"] = "Checkout";
    decimal total = 0;
    var cart = HttpContextAccessor.HttpContext.Session.GetString("Cart");
    IEnumerable<ProductViewModel> products = new List<ProductViewModel>();
    if (!string.IsNullOrEmpty(cart))
    {
        products = JsonSerializer.Deserialize<IEnumerable<ProductViewModel>>(cart).ToList();
        total = products.Sum(p => p.Price * p.Qty);
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-md-12 d-flex flex-column justify-content-round align-items-center\">\r\n    <div class=\"card col-md-12 mt-5\">\r\n        <div class=\"mt-3\">\r\n            <h5>Cart</h5>\r\n        </div>\r\n\r\n");
#nullable restore
#line 24 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
         if (products.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""card-footer d-flex justify-content-between align-items-center mb-3"" style=""background-color: white"">
                <table class=""table table-striped table-borderless"" style=""font-size: 12px"">
                    <thead>
                    <tr>
                        <th scope=""col""></th>
                        <th scope=""col"">Name</th>
                        <th scope=""col"">Qty</th>
                        <th scope=""col"">Price</th>
                    </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 37 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
                     foreach (var product in products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1547, "\"", 1571, 1);
#nullable restore
#line 41 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
WriteAttributeValue("", 1553, product.Thumbnail, 1553, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1572, "\"", 1591, 1);
#nullable restore
#line 41 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
WriteAttributeValue("", 1578, product.Name, 1578, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" height=\"50px\"/>\r\n                            </td>\r\n                            <td>");
#nullable restore
#line 43 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 44 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
                           Write(product.Qty);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n                                <small class=\"text-muted\">ZAR.</small>");
#nullable restore
#line 46 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
                                                                 Write(product.Price.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 49 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n");
            WriteLiteral("            <div class=\"card-footer d-flex justify-content-between align-items-center mb-2\" style=\"background-color: white\">\r\n                <p>Total: <small>ZAR</small><strong>");
#nullable restore
#line 55 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
                                                Write(total.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n                <div>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b33a297254fb911dfd140f454b477d4b3d2e3c3510189", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2441, "\"", 2448, 0);
            EndWriteAttribute();
            WriteLiteral(" onclick=\"event.preventDefault();document.getElementById(\'cart\').submit();\" class=\"btn btn-success btn-lg\">Checkout</a>\r\n                </div>\r\n\r\n            </div>\r\n");
#nullable restore
#line 62 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card-footer d-flex justify-content-between align-items-center mb-3\" style=\"background-color: white\">\r\n                <small class=\"text-black-50 text-muted\">Your cart is empty!</small>\r\n            </div>\r\n");
#nullable restore
#line 68 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Shop\Checkout.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
