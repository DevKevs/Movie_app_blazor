#pragma checksum "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\Shared\MainLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0bf87d31973759d58e6858d6fb429182ca44136f"
// <auto-generated/>
#pragma warning disable 1591
namespace Movie_app.Client.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Movie_app.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Movie_app.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style b-aecznetsmu>\r\n    .sidebar[b-aecznetsmu] {\r\n        background-color: #1c57b9 !important;\r\n    }\r\n</style>\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "page");
            __builder.AddAttribute(3, "b-aecznetsmu");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "sidebar");
            __builder.AddAttribute(6, "style", "background-image:none;background-color: #1c57b9");
            __builder.AddAttribute(7, "b-aecznetsmu");
            __builder.OpenComponent<Movie_app.Client.Shared.NavMenu>(8);
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n\r\n    ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "main");
            __builder.AddAttribute(12, "b-aecznetsmu");
            __builder.AddMarkupContent(13, "<div class=\"top-row px-4\" style=\"background-color: #1c57b9\" b-aecznetsmu><a href=\"http://blazor.net\" target=\"_blank\" class=\"ml-md-auto\" b-aecznetsmu>About</a></div>\r\n\r\n        ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "content px-4");
            __builder.AddAttribute(16, "b-aecznetsmu");
#nullable restore
#line 18 "D:\Kevin Backup\repos\Movie_app\Movie_app\Client\Shared\MainLayout.razor"
__builder.AddContent(17, Body);

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
