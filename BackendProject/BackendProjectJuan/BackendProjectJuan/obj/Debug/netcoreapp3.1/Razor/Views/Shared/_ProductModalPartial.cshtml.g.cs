#pragma checksum "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fb12e4844e9de0cf517f81f8282c1046ab1494ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__ProductModalPartial), @"mvc.1.0.view", @"/Views/Shared/_ProductModalPartial.cshtml")]
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
#line 1 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\_ViewImports.cshtml"
using BackendProjectJuan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\_ViewImports.cshtml"
using BackendProjectJuan.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\_ViewImports.cshtml"
using BackendProjectJuan.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fb12e4844e9de0cf517f81f8282c1046ab1494ca", @"/Views/Shared/_ProductModalPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b29a4448f9af5910fdc1dbc61cc5f0b9a2ca987b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__ProductModalPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("product thumb"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "addbasket", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default addToBasket"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal-content"">
    <div class=""modal-header"">
        <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
    </div>
    <div class=""modal-body"">
        <!-- product details inner end -->
        <div class=""product-details-inner"">
            <div class=""row"">
                <div class=""col-lg-5"">
                    <div class=""product-large-slider mb-20"">

                       
                        
                            <div class=""pro-large-img img-zoom"">
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fb12e4844e9de0cf517f81f8282c1046ab1494ca5656", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 585, "~/uploads/products/", 585, 19, true);
#nullable restore
#line 16 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
AddHtmlAttributeValue("", 604, Model.ProductImages.FirstOrDefault(x=>x.PosterStatus==true)?.Image, 604, 67, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                     \r\n                    </div>\r\n");
            WriteLiteral("                </div>\r\n                <div class=\"col-lg-7\">\r\n                    <div class=\"product-details-des\">\r\n                        <h3 class=\"pro-det-title\">");
#nullable restore
#line 27 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                             Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                        <div class=\"pro-review\">\r\n                            <span><a href=\"#\">1 Review(s)</a></span>\r\n                        </div>\r\n                        <div class=\"price-box\">\r\n");
#nullable restore
#line 32 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                             if (Model.DiscountPercent > 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"price-regular\">$");
#nullable restore
#line 34 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                                         Write((Model.SalePrice * (1 - Model.DiscountPercent / 100)).ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"price-old\"><del>$");
#nullable restore
#line 35 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                                         Write(Model.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</del></span>\r\n");
#nullable restore
#line 36 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"price-regular\">$");
#nullable restore
#line 39 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                                        Write(Model.SalePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 40 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <p>");
#nullable restore
#line 42 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                      Write(Model.Desc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                        <div class=""quantity-cart-box d-flex align-items-center mb-20"">
                            <div class=""quantity"">
                                <div class=""pro-qty""><input type=""text"" value=""1""></div>
                            </div>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fb12e4844e9de0cf517f81f8282c1046ab1494ca11231", async() => {
                WriteLiteral("Add To Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
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
#line 47 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                                                                 WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n                        <div class=\"availability mb-20\">\r\n                            <h5 class=\"cat-title\">Availability:</h5>\r\n                            <span>");
#nullable restore
#line 51 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                              Write(Model.IsAvailable? "In Stock": "Not Available");

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                        <div class=\"mb-20\">\r\n                            Brand: ");
#nullable restore
#line 54 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                              Write(Model.Brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Color: ");
#nullable restore
#line 55 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                    foreach (var item in Model.ProductColors)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                           Write(item.Color.Name);

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Shared\_ProductModalPartial.cshtml"
                                                 
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </div>
                        <div class=""share-icon"">
                            <h5 class=""cat-title"">Share:</h5>
                            <a href=""#""><i class=""fa fa-facebook""></i></a>
                            <a href=""#""><i class=""fa fa-twitter""></i></a>
                            <a href=""#""><i class=""fa fa-pinterest""></i></a>
                            <a href=""#""><i class=""fa fa-google-plus""></i></a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- product details inner end -->
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product> Html { get; private set; }
    }
}
#pragma warning restore 1591
