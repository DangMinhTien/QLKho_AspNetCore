#pragma checksum "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\Account\AccessDenied.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f595d39d54b6aea4d196c88cb56f5673390e89cafe3e2130e15ae4e14e0d583d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Identity_Pages_Account_AccessDenied), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/AccessDenied.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\_ViewImports.cshtml"
using QLKHO.Areas.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\_ViewImports.cshtml"
using QLKHO.Areas.Identity.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\_ViewImports.cshtml"
using QLKHO.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using QLKHO.Areas.Identity.Pages.Account;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/accessdenied")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"f595d39d54b6aea4d196c88cb56f5673390e89cafe3e2130e15ae4e14e0d583d", @"/Areas/Identity/Pages/Account/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"74cea18991124c53c15c3a7bf0fba46f916391c00017bf8d2ac345290b85634c", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"51eee65b2a6c62df5e988a01de5922a90ae4af9827e1793590395abf37cf5434", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Identity_Pages_Account_AccessDenied : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\Account\AccessDenied.cshtml"
  
    ViewData["Title"] = "Hạn chế truy cập";
    Layout = "/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header>\r\n    <h1 class=\"text-danger\">");
#nullable restore
#line 9 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO_NHOM9\QLKHO\Areas\Identity\Pages\Account\AccessDenied.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n    <p class=\"text-danger\">Bạn đã bị hạn chế truy cập vào chức năng này.</p>\r\n</header>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccessDeniedModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccessDeniedModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccessDeniedModel>)PageContext?.ViewData;
        public AccessDeniedModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591