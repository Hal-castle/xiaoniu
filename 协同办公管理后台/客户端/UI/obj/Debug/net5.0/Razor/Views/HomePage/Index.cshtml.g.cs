#pragma checksum "C:\Users\liuwanting\Desktop\xiaoniu\协同办公管理后台\客户端\UI\Views\HomePage\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74e0862639ee0912a55d9ab4340bff87e4400118"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HomePage_Index), @"mvc.1.0.view", @"/Views/HomePage/Index.cshtml")]
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
#line 1 "C:\Users\liuwanting\Desktop\xiaoniu\协同办公管理后台\客户端\UI\Views\_ViewImports.cshtml"
using UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\liuwanting\Desktop\xiaoniu\协同办公管理后台\客户端\UI\Views\_ViewImports.cshtml"
using UI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74e0862639ee0912a55d9ab4340bff87e4400118", @"/Views/HomePage/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52d79ad08d11418ded2b13adb4a9b2619d15bb23", @"/Views/_ViewImports.cshtml")]
    public class Views_HomePage_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/layui/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/layui/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-layout-body"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e0862639ee0912a55d9ab4340bff87e44001184809", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, maximum-scale=1\">\r\n    <title></title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "74e0862639ee0912a55d9ab4340bff87e44001185223", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e0862639ee0912a55d9ab4340bff87e44001187105", async() => {
                WriteLiteral(@"
    <div class=""layui-layout layui-layout-admin"">
        <div class=""layui-header"">
            <div class=""layui-logo"">协同办公管理后台</div>
            <ul class=""layui-nav layui-layout-right"">
                <li class=""layui-nav-item"">
                    <a href=""javascript:;"">
                        <img src=""http://t.cn/RCzsdCq"" class=""layui-nav-img"">
                        Admin
                    </a>
                    <dl class=""layui-nav-child"">
                        <dd><a");
                BeginWriteAttribute("href", " href=\"", 906, "\"", 913, 0);
                EndWriteAttribute();
                WriteLiteral(">基本资料</a></dd>\r\n                        <dd><a");
                BeginWriteAttribute("href", " href=\"", 960, "\"", 967, 0);
                EndWriteAttribute();
                WriteLiteral(">安全设置</a></dd>\r\n                    </dl>\r\n                </li>\r\n                <li class=\"layui-nav-item\"><a");
                BeginWriteAttribute("href", " href=\"", 1079, "\"", 1086, 0);
                EndWriteAttribute();
                WriteLiteral(@"></a></li>
            </ul>
        </div>

        <div class=""layui-side layui-bg-black"">
            <div class=""layui-side-scroll"">
                <!-- 左侧导航区域（可配合layui已有的垂直导航） -->
                <ul class=""layui-nav layui-nav-tree"" lay-filter=""test"">
                    <li class=""layui-nav-item layui-nav-itemed"">
                        <a");
                BeginWriteAttribute("class", " class=\"", 1445, "\"", 1453, 0);
                EndWriteAttribute();
                WriteLiteral(@" href=""javascript:;"">单位人事</a>
                        <dl class=""layui-nav-child"">
                            <dd><a href=""/HomePage/Unit_management"" target=""management"">单位管理</a></dd>
                            <dd><a href=""/HomePage/Division_management"" target=""management"">部门管理</a></dd>
                            <dd><a href=""/HomePage/People_management"" target=""management"">人员管理</a></dd>
                            <dd><a href=""/HomePage/Group_management"" target=""management"">群组管理</a></dd>
                            <dd><a href=""/HomePage/Post_management"" target=""management"">岗位管理</a></dd>
                        </dl>
                    </li>
                    <li class=""layui-nav-item"">
                        <a href=""javascript:;"">应用管理</a>
                        <dl class=""layui-nav-child"">
                            <dd><a href=""/HomePage/Access_application"" target=""management"">接入应用</a></dd>
                            <dd><a href=""/HomePage/Developer_Management"" target=""management"">");
                WriteLiteral(@"开发商管理</a></dd>
                            <dd><a href=""/HomePage/Application_classification"" target=""management"">应用分类</a></dd>
                            <dd><a href=""/HomePage/Operation_log"" target=""management"">操作日志</a></dd>
                        </dl>
                    </li>
                    <li class=""layui-nav-item"">
                        <a href=""javascript:;"">公众号</a>
                        <dl class=""layui-nav-child"">
                            <dd><a href=""/HomePage/Account_Management"" target=""management"">公众号管理</a></dd>
                        </dl>
                    </li>
                    <li class=""layui-nav-item"">
                        <a href=""javascript:;"">流程管理</a>
                        <dl class=""layui-nav-child"">
                            <dd><a href=""/HomePage/Process_management"" target=""management"">流程管理</a></dd>
                            <dd><a href=""/HomePage/Workorder_management"" target=""management"">工单管理</a></dd>
                        </dl>
      ");
                WriteLiteral(@"              </li>
                    <li class=""layui-nav-item"">
                        <a href=""javascript:;"">系统管理</a>
                        <dl class=""layui-nav-child"">
                            <dd><a href=""/HomePage/Role_management"" target=""management"">角色管理</a></dd>
                            <dd><a href=""/HomePage/Dictionary_management"" target=""management"">字典管理</a></dd>
                        </dl>
                    </li>
                </ul>
            </div>
        </div>

        <div class=""layui-body"">
            <!-- 内容主体区域 -->
            <!--<div style=""padding: 15px;"">内容主体区域</div>-->
            <iframe style=""width:100%;height:99.23%"" name=""management""></iframe>
        </div>

        <div class=""layui-footer"">
            <!-- 底部固定区域 -->
            layui.com - 底部固定区域
        </div>
    </div>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "74e0862639ee0912a55d9ab4340bff87e440011812102", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        //JavaScript代码区域\r\n        layui.use(\'element\', function () {\r\n            var element = layui.element;\r\n\r\n        });\r\n    </script>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>");
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
