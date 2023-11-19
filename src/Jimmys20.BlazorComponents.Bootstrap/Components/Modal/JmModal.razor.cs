using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmModal : BootstrapComponentBase
{
    /// <summary>
    /// Specifies if the modal is visible.
    /// </summary>
    [Parameter] public bool Visible { get; set; }

    /// <summary>
    /// Fires when the modal visibility is changed.
    /// </summary>
    [Parameter] public EventCallback<bool> VisibleChanged { get; set; }

    /// <summary>
    /// Specifies the content of the modal.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("modal")
        .AddClass("show", when: Visible)
        .AddClass(Visible ? "d-block" : "d-none");

    private async Task OnModalBackdropClicked()
    {
        await VisibleChanged.InvokeAsync(false);
    }
}
