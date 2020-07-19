#pragma checksum "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d096a94e3d9a83f19794b09fbc45e494f4adcddc"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorGalaga.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using BlazorGalaga;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using BlazorGalaga.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Blazor.Extensions.Canvas;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Blazor.Extensions.Canvas.Canvas2D;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Blazor.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using Blazor.Extensions.Canvas.WebGL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using System.Drawing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using BlazorGalaga.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/Users/bcollins/BlazorGalaga/BlazorGalaga/_Imports.razor"
using BlazorGalaga.Models;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, @"<style>


    .content {
        padding: 0px !important;
    }

    div.context.px-4 {
        padding: 0px !important;
    }

    .main > div {
        padding: 0px !important;
    }

    #theCanvas canvas {
        display: block;
        width: 100%;
        height: 100%;
        position:absolute;
    }

    #theCanvas canvas:first-child{
        z-index:1000;
    }

    #theCanvas canvas:last-child{
        z-index:1;
    }

    #divBufferCanvas canvas {
        background-color: black;
        display: block;
    }

    body {
        overflow-y: hidden; /* Hide vertical scrollbar */
        overflow-x: hidden; /* Hide horizontal scrollbar */
    }
    </style>

");
            __builder.AddMarkupContent(1, @"<div id=""divDebugDash"" style=""position:absolute;left:15px;top:15px;width:300px;height:150px;background-color:lightgray;padding:5px;font-size:10px;font-size:10px"">
    <input type=""checkbox"" id=""PauseAnimation"">
    <label for=""PauseAnimation"">Pause Animation</label>
    <br>
    <input type=""checkbox"" id=""EditCurves"">
    <label for=""EditCurves"">Edit Curves</label>
    <br>
    <button id=""btnAddPath"">Add Path</button>
    <br><br>
    <button id=""btnResetAnimation"">Reset Animation</button>
    <br><br>
</div>

");
            __builder.AddMarkupContent(2, "<div id=\"divDiagnostics\" style=\"position:absolute;left:15px;top:190px;width:300px;height:400px;background-color:lightgray;padding:5px;font-size:10px;font-size:10px;overflow:scroll\">\r\n</div>\r\n\r\n");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "id", "divBufferCanvas");
            __builder.AddAttribute(5, "style", "font-family:Minecraft;position:absolute;left:1100px;top:15px;opacity:1");
            __builder.AddMarkupContent(6, "\r\n");
#nullable restore
#line 61 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
     if (BufferCanvases != null && BufferCanvases.Count>0)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
         foreach(var canvas in BufferCanvases)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(7, "            ");
            __builder.OpenComponent<Blazor.Extensions.Canvas.BECanvas>(8);
            __builder.AddAttribute(9, "Width", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 65 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                             45

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "Height", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 65 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                         45

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(11, (__value) => {
#nullable restore
#line 65 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                                    canvas.CanvasRef = (Blazor.Extensions.Canvas.BECanvas)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n");
#nullable restore
#line 66 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
         
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n\r\n");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "id", "theCanvas");
            __builder.AddAttribute(16, "style", "position: fixed; opacity: 1; background-color: black; width: 100%; height: 100%;");
            __builder.AddMarkupContent(17, "\r\n    ");
            __builder.OpenComponent<Blazor.Extensions.Canvas.BECanvas>(18);
            __builder.AddAttribute(19, "Width", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 71 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                     672

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(20, "Height", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 71 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                  944

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(21, (__value) => {
#nullable restore
#line 71 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                             DynamicCanvas = (Blazor.Extensions.Canvas.BECanvas)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(22, "\r\n    ");
            __builder.OpenComponent<Blazor.Extensions.Canvas.BECanvas>(23);
            __builder.AddAttribute(24, "Width", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 72 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                     672

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(25, "Height", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int64>(
#nullable restore
#line 72 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                  944

#line default
#line hidden
#nullable disable
            ));
            __builder.AddComponentReferenceCapture(26, (__value) => {
#nullable restore
#line 72 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                             StaticCanvas = (Blazor.Extensions.Canvas.BECanvas)__value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseComponent();
            __builder.AddMarkupContent(27, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\r\n\r\n");
            __builder.OpenElement(29, "img");
            __builder.AddAttribute(30, "id", "imgSpriteSheet");
            __builder.AddAttribute(31, "style", "display:none");
            __builder.AddAttribute(32, "src", "Assets/spritesheet_transparent.png");
            __builder.AddElementReferenceCapture(33, (__value) => {
#nullable restore
#line 75 "/Users/bcollins/BlazorGalaga/BlazorGalaga/Pages/Index.razor"
                                                    spriteSheet = __value;

#line default
#line hidden
#nullable disable
            }
            );
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
