#pragma checksum "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "388a285da577d3ddf669573d70492f9807721e208a961c42abdabf6eecc12d08"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AlertMessage), @"mvc.1.0.view", @"/Views/Shared/_AlertMessage.cshtml")]
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
#line 2 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\_ViewImports.cshtml"
using QLKHO.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"388a285da577d3ddf669573d70492f9807721e208a961c42abdabf6eecc12d08", @"/Views/Shared/_AlertMessage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"7b63ca7ed8c68b9b38f43da4beab7af88e54df964a8163e0d7ab9cbd100da50c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__AlertMessage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
 if (!String.IsNullOrEmpty(Model))
{
    var statusMessageClass = Model.StartsWith("Error") ? "danger" : "success";
    if (statusMessageClass == "danger")
    {
        var content = Model.Substring(Model.IndexOf(' ') + 1);

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 260, "\"", 317, 4);
            WriteAttributeValue("", 268, "alert", 268, 5, true);
            WriteAttributeValue(" ", 273, "alert-", 274, 7, true);
#nullable restore
#line 9 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
WriteAttributeValue("", 280, statusMessageClass, 280, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 299, "alert-dismissible", 300, 18, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n            ");
#nullable restore
#line 11 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
       Write(content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 13 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
    }
    if (statusMessageClass == "success")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("         <div");
            BeginWriteAttribute("class", " class=\"", 579, "\"", 636, 4);
            WriteAttributeValue("", 587, "alert", 587, 5, true);
            WriteAttributeValue(" ", 592, "alert-", 593, 7, true);
#nullable restore
#line 16 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
WriteAttributeValue("", 599, statusMessageClass, 599, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 618, "alert-dismissible", 619, 18, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n                    <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>\r\n            ");
#nullable restore
#line 18 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
       Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n         </div>\r\n");
#nullable restore
#line 20 "C:\Users\LENOVO\OneDrive\Documents\Wordspace\ThucTapCN\Code\QLKHO\QLKHO\Views\Shared\_AlertMessage.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
