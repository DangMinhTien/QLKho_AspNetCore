#pragma checksum "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "fac6341e842efa15c1c809fca2cb0d017b1b379f99cf691fdd6ed8f7f2f4e94e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\_ViewImports.cshtml"
using QLKHO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml"
using QLKHO.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"fac6341e842efa15c1c809fca2cb0d017b1b379f99cf691fdd6ed8f7f2f4e94e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7b63ca7ed8c68b9b38f43da4beab7af88e54df964a8163e0d7ab9cbd100da50c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 6 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml"
 if (SignInManager.IsSignedIn(User))
{
    AppUser user = await UserManager.GetUserAsync(User);
    if(user != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h1 class=\"display-4 text-center\">Xin Chào ");
#nullable restore
#line 15 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml"
                                              Write(user.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" !</h1>\r\n");
#nullable restore
#line 16 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Home\Index.cshtml"
    }
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<AppUser> UserManager { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<AppUser> SignInManager { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
