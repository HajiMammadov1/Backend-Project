#pragma checksum "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ad945e6ea0ac36ab6564179f096983f0d77e7bff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Profile), @"mvc.1.0.view", @"/Views/Account/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ad945e6ea0ac36ab6564179f096983f0d77e7bff", @"/Views/Account/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b29a4448f9af5910fdc1dbc61cc5f0b9a2ca987b", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MemberProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    int orderCounter = 0;
    int orderItemCounter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <main>
        <!-- breadcrumb area start -->
        <div class=""breadcrumb-area bg-img"" data-bg=""assets/img/banner/breadcrumb-banner.jpg"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-12"">
                        <div class=""breadcrumb-wrap text-center"">
                            <nav aria-label=""breadcrumb"">
                                <h1 class=""breadcrumb-title"">My Account</h1>
                                <ul class=""breadcrumb"">
                                    <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ad945e6ea0ac36ab6564179f096983f0d77e7bff5075", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                                    <li class=""breadcrumb-item active"" aria-current=""page"">My Account</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- breadcrumb area end -->
        <!-- my account wrapper start -->
        <div class=""my-account-wrapper section-padding"">
            <div class=""container custom-container"">
                <div class=""row"">
                    <div class=""col-lg-12"">
                        <!-- My Account Page Start -->
                        <div class=""myaccount-page-wrapper"">
                            <!-- My Account Tab Menu Start -->
                            <div class=""row"">
                                <div class=""col-lg-3 col-md-4"">
                                    <div class=""myaccount-tab-menu nav"" role=""tablist"">
                                        <a href=""#account-");
            WriteLiteral(@"info"" data-toggle=""tab"" class=""active""><i class=""fa fa-user""></i> Account Details</a>
                                        <a href=""#orders"" data-toggle=""tab""><i class=""fa fa-cart-arrow-down""></i> Orders</a>
                                        <a href=""#dashboad"" data-toggle=""tab"">
                                            <i class=""fa fa-dashboard""></i>
                                            Dashboard
                                        </a>

                                        <a href=""#download"" data-toggle=""tab""><i class=""fa fa-cloud-download""></i> Download</a>
                                        <a href=""#payment-method"" data-toggle=""tab"">
                                            <i class=""fa fa-credit-card""></i> Payment
                                            Method
                                        </a>
                                        <a href=""#address-edit"" data-toggle=""tab""><i class=""fa fa-map-marker""></i> address</a>
                       ");
            WriteLiteral(@"                 <a href=""login-register.html""><i class=""fa fa-sign-out""></i> Logout</a>
                                    </div>
                                </div>
                                <!-- My Account Tab Menu End -->
                                <!-- My Account Tab Content Start -->
                                <div class=""col-lg-9 col-md-8"">
                                    <div class=""tab-content"" id=""myaccountContent"">
                                        <!-- Single Tab Content Start -->
                                        <div class=""tab-pane fade"" id=""dashboad"" role=""tabpanel"">
                                            <div class=""myaccount-content"">
                                                <h3>Dashboard</h3>
                                                <div class=""welcome"">
                                                    <p>Hello, <strong>Alex Tuntuni</strong> (If Not <strong>Tuntuni !</strong><a href=""login-register.html"" class=""logout""> L");
            WriteLiteral(@"ogout</a>)</p>
                                                </div>
                                                <p class=""mb-0"">From your account dashboard. you can easily check & view your recent orders, manage your shipping and billing addresses and edit your password and account details.</p>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->
                                        <!-- Single Tab Content Start -->
                                        <div class=""tab-pane fade"" id=""orders"" role=""tabpanel"">
                                            <div class=""myaccount-content"">
                                                <h3>Orders</h3>
                                                <div class=""myaccount-table table-responsive text-center"">
                                                    <table class=""table table-condensed table-striped"">
                   ");
            WriteLiteral(@"                                     <thead>
                                                            <tr>
                                                                <th></th>
                                                                <th>Items count</th>
                                                                <th>Phone </th>
                                                                <th>Total</th>
                                                                <th>Date</th>
                                                                <th>Status</th>
                                                            </tr>
                                                        </thead>

                                                        <tbody>

");
#nullable restore
#line 89 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                             foreach (var order in Model.Orders)
                                                            {
                                                                orderItemCounter = 0;
                                                                orderCounter++;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                <tr data-toggle=\"collapse\" data-target=\"#demo-");
#nullable restore
#line 93 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                                         Write(order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"accordion-toggle\">\r\n                                                                    <td>");
#nullable restore
#line 94 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                   Write(orderCounter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 95 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                   Write(order.OrderItems.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 96 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                   Write(order.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 97 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                   Write(order.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 98 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                   Write(order.CreatedAt.ToString("dd-MM-yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                    <td>");
#nullable restore
#line 99 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                   Write(order.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                </tr>\r\n");
            WriteLiteral(@"                                                                <tr>
                                                                    <td colspan=""12"" class=""hiddenRow"">
                                                                        <div class=""accordian-body collapse""");
            BeginWriteAttribute("id", " id=\"", 7101, "\"", 7120, 2);
            WriteAttributeValue("", 7106, "demo-", 7106, 5, true);
#nullable restore
#line 104 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
WriteAttributeValue("", 7111, order.Id, 7111, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                                                            <table class=""table table-striped"">
                                                                                <thead>
                                                                                    <tr class=""info"">
                                                                                        <th></th>
                                                                                        <th>Product Name</th>
                                                                                        <th>Count</th>
                                                                                        <th>Unit price</th>
                                                                                    </tr>
                                                                                </thead>

                                                                                <tbody>

");
#nullable restore
#line 117 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                     foreach (var orderItem in order.OrderItems)
                                                                                    {
                                                                                        orderItemCounter++;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                                        <tr data-toggle=""collapse"" class=""accordion-toggle"" data-target=""#demo10"">
                                                                                            <td>");
#nullable restore
#line 121 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                           Write(orderItemCounter);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                                            <td>");
#nullable restore
#line 122 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                           Write(orderItem.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                                            <td>");
#nullable restore
#line 123 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                           Write(orderItem.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                                                                            <td>");
#nullable restore
#line 124 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                           Write(orderItem.DiscountedPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                                                        </tr>\r\n");
#nullable restore
#line 126 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"




                                                                                </tbody>
                                                                            </table>

                                                                        </div>
                                                                    </td>
                                                                </tr>
");
#nullable restore
#line 138 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->
                                        <!-- Single Tab Content Start -->
                                        <div class=""tab-pane fade"" id=""download"" role=""tabpanel"">
                                            <div class=""myaccount-content"">
                                                <h3>Downloads</h3>
                                                <div class=""myaccount-table table-responsive text-center"">
                                                    <table class=""table table-bordered"">
                                                        <thead class=""thead-light"">
                                                           ");
            WriteLiteral(@" <tr>
                                                                <th>Product</th>
                                                                <th>Date</th>
                                                                <th>Expire</th>
                                                                <th>Download</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                            <tr>
                                                                <td>Haven - Free Real Estate PSD Template</td>
                                                                <td>Aug 22, 2018</td>
                                                                <td>Yes</td>
                                                                <td><a href=""#"" class=""btn ""><i class=""fa fa-cloud-download""></i> Download File</a></td");
            WriteLiteral(@">
                                                            </tr>
                                                            <tr>
                                                                <td>HasTech - Profolio Business Template</td>
                                                                <td>Sep 12, 2018</td>
                                                                <td>Never</td>
                                                                <td><a href=""#"" class=""btn ""><i class=""fa fa-cloud-download""></i> Download File</a></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->
                                ");
            WriteLiteral(@"        <!-- Single Tab Content Start -->
                                        <div class=""tab-pane fade"" id=""payment-method"" role=""tabpanel"">
                                            <div class=""myaccount-content"">
                                                <h3>Payment Method</h3>
                                                <p class=""saved-message"">You Can't Saved Your Payment Method yet.</p>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->
                                        <!-- Single Tab Content Start -->
                                        <div class=""tab-pane fade"" id=""address-edit"" role=""tabpanel"">
                                            <div class=""myaccount-content"">
                                                <h3>Billing Address</h3>
                                                <address>
                                              ");
            WriteLiteral(@"      <p><strong>Alex Tuntuni</strong></p>
                                                    <p>
                                                        1355 Market St, Suite 900 <br>
                                                        San Francisco, CA 94103
                                                    </p>
                                                    <p>Mobile: (123) 456-7890</p>
                                                </address>
                                                <a href=""#"" class=""check-btn sqr-btn ""><i class=""fa fa-edit""></i> Edit Address</a>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->
                                        <!-- Single Tab Content Start -->
                                        <div class=""tab-pane fade show active"" id=""account-info"" role=""tabpanel"">
                                            <div class=""my");
            WriteLiteral("account-content\">\r\n                                                <h3>Account Details</h3>\r\n                                                <div class=\"account-details-form\">\r\n                                                    ");
#nullable restore
#line 210 "C:\Users\Lenovo\Desktop\p124_backend_project-HajiMammadov1\BackendProject\BackendProjectJuan\BackendProjectJuan\Views\Account\Profile.cshtml"
                                               Write(Html.Partial("_AccountUpdateFormPartial", Model.Member));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                                </div>
                                            </div>
                                        </div> <!-- Single Tab Content End -->
                                    </div>
                                </div> <!-- My Account Tab Content End -->
                            </div>
                        </div> <!-- My Account Page End -->
                    </div>
                </div>
            </div>
        </div>
        <!-- my account wrapper end -->
    </main>
    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MemberProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
