#pragma checksum "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\App.razor" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6c6d51d29641b0f28fa05f9b99221b9c0433270501538cda631c080373ce6528"
// <auto-generated/>
#pragma warning disable 1591
namespace ControleAtividades.Blazor.Server
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using DevExpress.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using DevExpress.ExpressApp.Blazor.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\_Imports.razor"
using ControleAtividades.Blazor.Server;

#line default
#line hidden
#nullable disable
    public partial class App : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Routing.Router>(0);
            __builder.AddAttribute(1, "AppAssembly", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Reflection.Assembly>(
#nullable restore
#line 1 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\App.razor"
                      typeof(Program).Assembly

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(2, "AdditionalAssemblies", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::System.Collections.Generic.IEnumerable<System.Reflection.Assembly>>(
#nullable restore
#line 1 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\App.razor"
                                                                      new[] { typeof(DevExpress.ExpressApp.Blazor.BlazorApplication).Assembly }

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "Found", (global::Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.RouteData>)((routeData) => (__builder2) => {
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.RouteView>(4);
                __builder2.AddAttribute(5, "RouteData", (object)(global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::Microsoft.AspNetCore.Components.RouteData>(
#nullable restore
#line 3 "C:\Users\jsilveira\Desktop\ControleAtividades\ControleAtividades.Blazor.Server\App.razor"
                               routeData

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(6, "NotFound", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<global::Microsoft.AspNetCore.Components.LayoutView>(7);
                __builder2.AddAttribute(8, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<global::Microsoft.AspNetCore.Components.Web.PageTitle>(9);
                    __builder3.AddAttribute(10, "ChildContent", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(11, "Not found");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(12, "\r\n            ");
                    __builder3.AddMarkupContent(13, "<p role=\"alert\">Sorry, there\'s nothing at this address.</p>");
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
