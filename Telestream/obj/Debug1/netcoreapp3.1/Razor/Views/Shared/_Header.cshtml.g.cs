#pragma checksum "F:\Working\Telestream\Telestream\Telestream\Views\Shared\_Header.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5fcb8054b835e5b86d9abfb69d774f88bb14a6df30dcae1d3a7a607959b9b4c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Header), @"mvc.1.0.view", @"/Views/Shared/_Header.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Working\Telestream\Telestream\Telestream\Views\_ViewImports.cshtml"
using Telestream;

#line default
#line hidden
#line 2 "F:\Working\Telestream\Telestream\Telestream\Views\_ViewImports.cshtml"
using Telestream.Models;

#line default
#line hidden
#line 3 "F:\Working\Telestream\Telestream\Telestream\Views\_ViewImports.cshtml"
using Telestream.Models.Entities;

#line default
#line hidden
#line 4 "F:\Working\Telestream\Telestream\Telestream\Views\_ViewImports.cshtml"
using Telestream.Models.ViewModel;

#line default
#line hidden
#line 5 "F:\Working\Telestream\Telestream\Telestream\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"5fcb8054b835e5b86d9abfb69d774f88bb14a6df30dcae1d3a7a607959b9b4c6", @"/Views/Shared/_Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"eee173eab7038f8f61ae46f3e5ce0549ea55745c94c480b533c57108d084e94b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Breadcrumbs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!-- Header -->\n<div class=\"header bg-primary pb-6\">\n    <div class=\"container-fluid\">\n        <div class=\"header-body\">\n            <!-- 1st Row: Crumbs and filters -->\n            <div class=\"row align-items-center py-4\">\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5fcb8054b835e5b86d9abfb69d774f88bb14a6df30dcae1d3a7a607959b9b4c64055", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""col-lg-6 col-5 text-right"">
                    <a href=""#"" class=""btn btn-sm btn-neutral"">New</a>
                    <a href=""#"" class=""btn btn-sm btn-neutral"">Filters</a>
                </div>
            </div>
            <!-- 2nd Row: Card stats (only for dashboard) -->
            <div class=""row"">
                <div class=""col-xl-3 col-md-6"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">Total traffic</h5>
                                    <span class=""h2 font-weight-bold mb-0"">350,897</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-red text-white rounded-circle sha");
            WriteLiteral(@"dow"">
                                        <i class=""ni ni-active-40""></i>
                                    </div>
                                </div>
                            </div>
                            <p class=""mt-3 mb-0 text-sm"">
                                <span class=""text-success mr-2""><i class=""fa fa-arrow-up""></i> 3.48%</span>
                                <span class=""text-nowrap"">Since last month</span>
                            </p>
                        </div>
                    </div>
                </div>
                <div class=""col-xl-3 col-md-6"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">New users</h5>
                                    <span class=""h2 font-weight-bold mb-0"">2,");
            WriteLiteral(@"356</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-orange text-white rounded-circle shadow"">
                                        <i class=""ni ni-chart-pie-35""></i>
                                    </div>
                                </div>
                            </div>
                            <p class=""mt-3 mb-0 text-sm"">
                                <span class=""text-success mr-2""><i class=""fa fa-arrow-up""></i> 3.48%</span>
                                <span class=""text-nowrap"">Since last month</span>
                            </p>
                        </div>
                    </div>
                </div>
                <div class=""col-xl-3 col-md-6"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
            ");
            WriteLiteral(@"                    <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">Sales</h5>
                                    <span class=""h2 font-weight-bold mb-0"">924</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-green text-white rounded-circle shadow"">
                                        <i class=""ni ni-money-coins""></i>
                                    </div>
                                </div>
                            </div>
                            <p class=""mt-3 mb-0 text-sm"">
                                <span class=""text-success mr-2""><i class=""fa fa-arrow-up""></i> 3.48%</span>
                                <span class=""text-nowrap"">Since last month</span>
                            </p>
                        </div>
                    </div>
                </div>
                <div class=""col-xl-");
            WriteLiteral(@"3 col-md-6"">
                    <div class=""card card-stats"">
                        <!-- Card body -->
                        <div class=""card-body"">
                            <div class=""row"">
                                <div class=""col"">
                                    <h5 class=""card-title text-uppercase text-muted mb-0"">Performance</h5>
                                    <span class=""h2 font-weight-bold mb-0"">49,65%</span>
                                </div>
                                <div class=""col-auto"">
                                    <div class=""icon icon-shape bg-gradient-info text-white rounded-circle shadow"">
                                        <i class=""ni ni-chart-bar-32""></i>
                                    </div>
                                </div>
                            </div>
                            <p class=""mt-3 mb-0 text-sm"">
                                <span class=""text-success mr-2""><i class=""fa fa-arrow-up""></i> 3.48%</span>
          ");
            WriteLiteral("                      <span class=\"text-nowrap\">Since last month</span>\n                            </p>\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
