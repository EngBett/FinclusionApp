#pragma checksum "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86aa8894b63a8a2583531a444e110d38685ff55d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Show), @"mvc.1.0.view", @"/Views/Account/Show.cshtml")]
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
#line 1 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86aa8894b63a8a2583531a444e110d38685ff55d", @"/Views/Account/Show.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7039e4da5799ff8759f5b3df1a8aadf6d719d02", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Show : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Account>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Deactivate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Activate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
  
    ViewData["Title"] = "Account";
    var success = ViewData["Success"]?.ToString();
    var error = ViewData["Error"]?.ToString();
    var transactions = (IEnumerable<AccountTransaction>)ViewBag.Transactions;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-md-12 d-flex flex-column justify-content-round align-items-center\">\r\n    <div class=\"card col-md-6 mt-5\">\r\n\r\n        <div class=\"mt-3\">\r\n            <span");
            BeginWriteAttribute("class", " class=\"", 439, "\"", 503, 5);
            WriteAttributeValue("", 447, "badge", 447, 5, true);
            WriteAttributeValue(" ", 452, "badge-", 453, 7, true);
#nullable restore
#line 14 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
WriteAttributeValue("", 459, Model.Active?"success":"danger", 459, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 493, "mt-1", 494, 5, true);
            WriteAttributeValue(" ", 498, "mb-3", 499, 5, true);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 14 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                               Write(Model.Active?"Active":"Inactive");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span><br/>\r\n");
#nullable restore
#line 15 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
             if (!string.IsNullOrEmpty(success))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-success text-center\" role=\"alert\">");
#nullable restore
#line 17 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                     Write(success);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 18 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
             if (!string.IsNullOrEmpty(error))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-danger text-center\" role=\"alert\">");
#nullable restore
#line 21 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                    Write(error);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 22 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <h4>Balance: <small style=\"font-size: 12px\">ZAR</small>");
#nullable restore
#line 24 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                               Write(Model.Balance == 0 ? "0.00" : Model.Balance.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            <small class=\"text-black-50\">Account No. <span class=\"text-muted\">");
#nullable restore
#line 25 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                         Write(Model.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></small>\r\n        </div>\r\n        <div class=\"card-footer mb-3\" style=\"background-color: white\">\r\n");
#nullable restore
#line 28 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
             if (Model.Active)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86aa8894b63a8a2583531a444e110d38685ff55d9519", async() => {
                WriteLiteral("Dectivate");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                                                     WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 31 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86aa8894b63a8a2583531a444e110d38685ff55d12291", async() => {
                WriteLiteral("Activate");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                                                    WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 35 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
    </div>

    <div class=""card col-md-12 mt-5"">
        <div class=""mt-3"">
            <h5>Transactions</h5>
        </div>
        <div class=""card-footer d-flex justify-content-between align-items-center mb-3"" style=""background-color: white"">
");
#nullable restore
#line 44 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
             if (transactions.Any())
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <table class=""table table-striped table-borderless"" style=""font-size: 12px"">
                    <thead>
                    <tr>
                        <th scope=""col"">TransactionId</th>
                        <th scope=""col"">Account No.</th>
                        <th scope=""col"">Description</th>
                        <th scope=""col"">Amount</th>
                        <th scope=""col"">Status</th>
                        <th scope=""col"">Type</th>
                        <th scope=""col"">Initiated At</th>
                        <th scope=""col"">Completed At</th>
                    </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 60 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                     foreach (var transaction in transactions)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"col\">");
#nullable restore
#line 63 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                       Write(transaction.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 64 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                           Write(transaction.Account.AccountNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 65 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                           Write(transaction.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 66 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                            Write(transaction.Amount.ToString("#.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 67 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                            Write(Enum.GetName(typeof(AccountTransaction.TransactionStatus), transaction.TranStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 68 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                            Write(Enum.GetName(typeof(AccountTransaction.TransactionType), transaction.TranType));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 69 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                           Write(transaction.InitiatedAt.ToString(CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>\r\n");
#nullable restore
#line 71 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                 if (transaction.CompletedAt != null)
                                {
                                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                               Write(transaction.CompletedAt.Value.ToString(CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                                                                                         
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <code>pending...</code>\r\n");
#nullable restore
#line 78 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 82 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n");
#nullable restore
#line 85 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <small class=\"text-black-50 text-muted\">No transactions yet!</small>\r\n");
#nullable restore
#line 89 "D:\CodeProjects\Finclussion\FinclusionApp\src\AccManagement\Views\Account\Show.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Account> Html { get; private set; }
    }
}
#pragma warning restore 1591
