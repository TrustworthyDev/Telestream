#pragma checksum "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "147cc288b48dab12d74e4a7c261b711d89bd45eeebbb55af1b7b1705ae8d36c6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Inbox), @"mvc.1.0.view", @"/Views/Home/Inbox.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"147cc288b48dab12d74e4a7c261b711d89bd45eeebbb55af1b7b1705ae8d36c6", @"/Views/Home/Inbox.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"eee173eab7038f8f61ae46f3e5ce0549ea55745c94c480b533c57108d084e94b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Inbox : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ContactDetailViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/css/inbox.css?v=1.2.0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/inbox.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#line 3 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
  
    ViewData["Title"] = "Inbox";

#line default
#line hidden
            WriteLiteral("\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "147cc288b48dab12d74e4a7c261b711d89bd45eeebbb55af1b7b1705ae8d36c65432", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LinkTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.Href = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
#line 9 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_LinkTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n");
            DefineSection("Breadcrumbs", async() => {
                WriteLiteral("\n    <div class=\"col-lg-6 col-7\">\n        <h6 class=\"h2 text-white d-inline-block mb-0\">Inbox</h6>\n    </div>\n");
            }
            );
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-12"">
        <div class=""card chat-app"">
            <div id=""plist"" class=""people-list"">
                <div class=""input-group"">
                    <input type=""text"" id=""search-people-input"" class=""form-control"" placeholder=""Search..."" onchange=""filterContact()"">
                    <div class=""input-group-append"">
                        <span class=""input-group-text""><i class=""fa fa-search""></i></span>
                    </div>
                    <button class=""btn btn-danger text-white text-uppercase pull-right mt-1 mr-4"" onclick=""deleteAllSMS()"">Clear All Messages</button>
                </div>
                
                <ul class=""list-unstyled chat-list mt-1 mb-0"" id=""contact-detail-container"">
");
#line 32 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
                     foreach (ContactDetailViewModel item in Model)
                    {

#line default
#line hidden
            WriteLiteral("                        <li class=\"clearfix mt-1\" data-phone=\"");
#line 34 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
                                                         Write(item.phoneNumber);

#line default
#line hidden
            WriteLiteral("\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1265, "\"", 1322, 6);
            WriteAttributeValue("", 1275, "openMessages(\'", 1275, 14, true);
#line 34 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
WriteAttributeValue("", 1289, item.phoneNumber, 1289, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 1306, "\',", 1306, 2, true);
            WriteAttributeValue(" ", 1308, "\'", 1309, 2, true);
#line 34 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
WriteAttributeValue("", 1310, item.name, 1310, 10, false);

#line default
#line hidden
            WriteAttributeValue("", 1320, "\')", 1320, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\n                            <div class=\"row align-items-center\">\n                                <div class=\"col\">\n                                    <div class=\"name\"><strong> ");
#line 37 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
                                                          Write(item.name);

#line default
#line hidden
            WriteLiteral("</strong></div>\n                                    <div class=\"phone-number\"> ");
#line 38 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
                                                          Write(item.phoneNumber);

#line default
#line hidden
            WriteLiteral(@" </div>
                                </div>
                                <div class=""col-auto"">
                                    <i class=""fa fa-envelope"" style=""font-size: 1.3em;""></i>
                                </div>
                                <div class=""col-auto"">
                                    <i class=""fa fa-trash"" style=""font-size: 0.8em; margin-top: 25px""");
            BeginWriteAttribute("onclick", " onclick=\"", 1999, "\"", 2043, 3);
            WriteAttributeValue("", 2009, "deleteContact(\'", 2009, 15, true);
#line 44 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
WriteAttributeValue("", 2024, item.phoneNumber, 2024, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 2041, "\')", 2041, 2, true);
            EndWriteAttribute();
            WriteLiteral("></i>\n                                </div>\n                            </div>\n                        </li>\n");
#line 48 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
                    }

#line default
#line hidden
            WriteLiteral(@"                </ul>
            </div>
            <div class=""chat"">
                <div class=""chat-history"">
                    <ul class=""m-b-0"" id=""message-container"">
                    </ul>
                </div>
                <div class=""chat-message clearfix"">
                    <textarea class=""form-control"" id=""message-textarea"" placeholder=""Reply...""></textarea>
                    <span class=""pull-right label label-default count-label"" id=""count_message"">0/1592</span>
                </div>
                <button class=""btn btn-danger text-white text-uppercase pull-right mt-1 mr-4"" onclick=""sendMessage()"">Send</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "147cc288b48dab12d74e4a7c261b711d89bd45eeebbb55af1b7b1705ae8d36c612712", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 68 "F:\Working\Telestream\Telestream_modified\Telestream\Views\Home\Inbox.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("   \n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ContactDetailViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
