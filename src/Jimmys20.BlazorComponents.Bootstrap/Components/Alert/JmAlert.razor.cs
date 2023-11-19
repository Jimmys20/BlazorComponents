using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmAlert : BootstrapComponentBase
{
    /// <summary>
    /// Specifies if the alert is visible.
    /// </summary>
    [Parameter] public bool Visible { get; set; }

    /// <summary>
    /// Fires when the alert visibility is changed.
    /// </summary>
    [Parameter] public EventCallback<bool> VisibleChanged { get; set; }

    /// <summary>
    /// Specifies if the alert is dismissible.
    /// </summary>
    [Parameter] public bool Dismissible { get; set; }

    /// <summary>
    /// Specifies the color of the alert.
    /// </summary>
    [Parameter] public Color Color { get; set; }

    /// <summary>
    /// Specifies content of the alert.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("alert")
        .AddClass($"alert-{Color.ToColorString()}", when: Color != Color.Default)
        .AddClass("alert-dismissible", when: Dismissible);

    private async Task OnCloseButtonClicked()
    {
        await VisibleChanged.InvokeAsync(false);
    }
}
