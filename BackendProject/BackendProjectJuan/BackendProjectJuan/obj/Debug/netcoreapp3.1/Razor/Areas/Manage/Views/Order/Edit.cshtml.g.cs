#pragma checksum "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86e08f76c383fe97ac53c248a064f36b8ad3e63b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Order_Edit), @"mvc.1.0.view", @"/Areas/Manage/Views/Order/Edit.cshtml")]
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
#line 1 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\_ViewImports.cshtml"
using BackendProjectJuan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\_ViewImports.cshtml"
using BackendProjectJuan.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\_ViewImports.cshtml"
using BackendProjectJuan.Areas.Manage.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86e08f76c383fe97ac53c248a064f36b8ad3e63b", @"/Areas/Manage/Views/Order/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e4e28f387e7385f6d1adf797bc250ca73dbb71c", @"/Areas/Manage/Views/_ViewImports.cshtml")]
    public class Areas_Manage_Views_Order_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Order>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
  
    ViewData["Title"] = "Edit";
    int counter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12 mx-auto"" style=""margin-top: 100px;"">
            <h1>Edit</h1>
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-6"">
                            <h5 class=""card-title"">FullName: ");
#nullable restore
#line 15 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                        Write(Model.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h5 class=\"card-title\">Phone: ");
#nullable restore
#line 16 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                     Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h5 class=\"card-title\">Email: ");
#nullable restore
#line 17 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                     Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h5 class=\"card-title\">Country: ");
#nullable restore
#line 18 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                       Write(Model.Country);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                        </div>\r\n                        <div class=\"col-6\">\r\n                            <h5 class=\"card-title\">City: ");
#nullable restore
#line 21 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                    Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h5 class=\"card-title\">Address: ");
#nullable restore
#line 22 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                       Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h5 class=\"card-title\">TotalPrice: ");
#nullable restore
#line 23 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                          Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                            <h5 class=\"card-title\">Date: ");
#nullable restore
#line 24 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                                    Write(Model.CreatedAt.ToString("dd.MM.yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>
                        </div>
                    </div>
                    

                    <table class=""table"">
                        <thead>
                            <tr>
                                <th scope=""col"">#</th>
                                <th scope=""col"">Name</th>
                                <th scope=""col"">Count</th>
                                <th scope=""col"">Unit Price</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 39 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                             foreach (var item in Model.OrderItems)
                            {
                                counter++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <th scope=\"row\">");
#nullable restore
#line 43 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                               Write(counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                    <td>");
#nullable restore
#line 44 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                   Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 45 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 46 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                                   Write(item.DiscountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </tbody>\r\n                    </table>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86e08f76c383fe97ac53c248a064f36b8ad3e63b12271", async() => {
                WriteLiteral("\r\n                        <input type=\"hidden\" name=\"id\"");
                BeginWriteAttribute("value", " value=\"", 2357, "\"", 2374, 1);
#nullable restore
#line 53 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
WriteAttributeValue("", 2365, Model.Id, 2365, 9, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <div class=\"form-row\">\r\n                            <div class=\"row\">\r\n                                <div class=\"form-group col-md-6\">\r\n                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86e08f76c383fe97ac53c248a064f36b8ad3e63b13247", async() => {
                    WriteLiteral("\r\n                                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#nullable restore
#line 57 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Status);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 57 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = Html.GetEnumSelectList<BackendProjectJuan.Enums.OrderStatus>();

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                </div>
                                <div class=""form-group col-md-3"">
                                    <button type=""submit"" class=""btn btn-primary"">Save</button>
                                </div>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86e08f76c383fe97ac53c248a064f36b8ad3e63b15844", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 63 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Areas\Manage\Views\Order\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
