#pragma checksum "F:\Working\Telestream\Telestream_modified\Telestream\Views\Shared\_Footer.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b16cf1458b3df71fd0295e459a2f05d38d0e5612dbd1c2dddfde1ef8e1371367"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Footer), @"mvc.1.0.view", @"/Views/Shared/_Footer.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "F:\Working\Telestream\Telestream_modified\Telestream\Views\_ViewImports.cshtml"
using Telestream;

#line default
#line hidden
#line 2 "F:\Working\Telestream\Telestream_modified\Telestream\Views\_ViewImports.cshtml"
using Telestream.Models;

#line default
#line hidden
#line 3 "F:\Working\Telestream\Telestream_modified\Telestream\Views\_ViewImports.cshtml"
using Telestream.Models.Entities;

#line default
#line hidden
#line 4 "F:\Working\Telestream\Telestream_modified\Telestream\Views\_ViewImports.cshtml"
using Telestream.Models.ViewModel;

#line default
#line hidden
#line 5 "F:\Working\Telestream\Telestream_modified\Telestream\Views\_ViewImports.cshtml"
using System.Collections.Generic;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"b16cf1458b3df71fd0295e459a2f05d38d0e5612dbd1c2dddfde1ef8e1371367", @"/Views/Shared/_Footer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"eee173eab7038f8f61ae46f3e5ce0549ea55745c94c480b533c57108d084e94b", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Footer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<input type=\"hidden\" id=\"RequestVerificationToken\"\n       name=\"RequestVerificationToken\"");
            BeginWriteAttribute("value", " value=\"", 280, "\"", 314, 1);
#line 10 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Shared\_Footer.cshtml"
WriteAttributeValue("", 288, GetAntiXsrfRequestToken(), 288, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            WriteLiteral(@">

<footer class=""footer"">
    <div class=""row align-items-center justify-content-xl-between"">
        <div class=""col-xl-6"">
            <div class=""copyright text-center text-xl-left text-muted"">
                &copy; 2020
                <a href=""https://www.creative-tim.com"" class=""font-weight-bold ml-1"" target=""_blank"">Creative Tim</a>
                &
                <a href=""https://udevoffice.com/"" class=""font-weight-bold ml-1"" target=""_blank"">Udevoffice</a>
            </div>
        </div>
        <div class=""col-xl-6"">
            <ul class=""nav nav-footer justify-content-center justify-content-xl-end"">
                <li class=""nav-item"">
                    <a href=""https://www.creative-tim.com"" class=""nav-link"" target=""_blank"">Creative Tim</a>
                </li>
                <li class=""nav-item"">
                    <a href=""https://udevoffice.com/"" class=""nav-link"" target=""_blank"">Udevoffice</a>
                </li>
                <li class=""nav-item"">
                    <a href=""ht");
            WriteLiteral(@"tps://www.creative-tim.com/presentation"" class=""nav-link"" target=""_blank"">About Us</a>
                </li>
                <li class=""nav-item"">
                    <a href=""http://blog.creative-tim.com"" class=""nav-link"" target=""_blank"">Blog</a>
                </li>
                <li class=""nav-item"">
                    <a href=""https://github.com/creativetimofficial/argon-dashboard/blob/master/LICENSE.md"" class=""nav-link"" target=""_blank"">MIT License</a>
                </li>
            </ul>
        </div>
    </div>
</footer>
");
        }
        #pragma warning restore 1998
#line 2 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Shared\_Footer.cshtml"
           
    public string GetAntiXsrfRequestToken()
    {
        return Xsrf.GetAndStoreTokens(Context).RequestToken;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Antiforgery.IAntiforgery Xsrf { get; private set; }
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
