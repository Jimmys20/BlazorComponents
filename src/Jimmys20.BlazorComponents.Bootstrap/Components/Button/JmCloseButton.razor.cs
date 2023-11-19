using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmCloseButton : BootstrapComponentBase
{
    /// <summary>
    /// Fires when the close button is clicked.
    /// </summary>
    [Parameter] public EventCallback Clicked { get; set; }

    /// <summary>
    /// Specifies if the close button is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Specifies if the close button is white.
    /// </summary>
    [Parameter] public bool White { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("btn-close")
        .AddClass("btn-close-white", when: White);

    private async Task HandleClick()
    {
        if (Disabled)
        {
            return;
        }

        await Clicked.InvokeAsync();
    }
}
