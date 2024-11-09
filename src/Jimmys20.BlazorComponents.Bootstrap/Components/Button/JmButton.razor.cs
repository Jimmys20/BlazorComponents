using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmButton : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the color of the button.
    /// </summary>
    [Parameter] public Color Color { get; set; }

    /// <summary>
    /// Specifies the type of the button.
    /// </summary>
    [Parameter] public ButtonType Type { get; set; }

    /// <summary>
    /// Specifies the size of the button.
    /// </summary>
    [Parameter] public ButtonSize Size { get; set; }

    /// <summary>
    /// Fires when the button is clicked.
    /// </summary>
    [Parameter] public EventCallback Clicked { get; set; }

    /// <summary>
    /// Set to true to prevent the default action for the onclick event.
    /// </summary>
    [Parameter] public bool PreventDefault { get; set; }

    /// <summary>
    /// Specifies if the button is outline.
    /// </summary>
    [Parameter] public bool Outline { get; set; }

    /// <summary>
    /// Specifies if the button is active.
    /// </summary>
    [Parameter] public bool Active { get; set; }

    /// <summary>
    /// Specifies if the button is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Specifies if a loading indicator should be displayed.
    /// </summary>
    [Parameter] public bool Loading { get; set; }

    /// <summary>
    /// Specifies a template that will be displayed instead of the default loading indicator.
    /// </summary>
    [Parameter] public RenderFragment LoadingTemplate { get; set; }

    /// <summary>
    /// Specifies the content of the button.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("btn")
        .AddClass(Outline ? $"btn-outline-{Color.ToColorString()}" : $"btn-{Color.ToColorString()}", when: Color != Color.Default)
        .AddClass(Size.ToButtonSizeString(), when: Size != ButtonSize.Default)
        .AddClass("active", when: Active);

    private async Task HandleClick(MouseEventArgs args)
    {
        if (Disabled)
        {
            return;
        }

        await Clicked.InvokeAsync();
    }
}

