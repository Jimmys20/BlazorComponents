using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmCardHeader : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the color of the card header.
    /// </summary>
    [Parameter] public Color Color { get; set; }

    /// <summary>
    /// Specifies the content of the card header.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("card-header")
        .AddClass($"text-bg-{Color.ToColorString()}", when: Color != Color.Default);
}
