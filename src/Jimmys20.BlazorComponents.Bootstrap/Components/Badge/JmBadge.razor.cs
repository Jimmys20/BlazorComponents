using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmBadge : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the color of the badge.
    /// </summary>
    [Parameter] public Color Color { get; set; }

    /// <summary>
    /// Specifies if the badge is pill.
    /// </summary>
    [Parameter] public bool Pill { get; set; }

    /// <summary>
    /// Specifies the content of the badge.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("badge")
        .AddClass("rounded-pill", when: Pill)
        .AddClass($"text-bg-{Color.ToColorString()}", when: Color != Color.Default);
}
