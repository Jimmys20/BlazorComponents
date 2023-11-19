using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmListGroupItem : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the color of the list group item.
    /// </summary>
    [Parameter] public Color Color { get; set; }

    /// <summary>
    /// Fires when the list group item is clicked.
    /// </summary>
    [Parameter] public EventCallback Clicked { get; set; }

    /// <summary>
    /// Specifies if the list group item is active.
    /// </summary>
    [Parameter] public bool Active { get; set; }

    /// <summary>
    /// Specifies if the list group item is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Specifies the content of the list group item.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    private bool IsButton => Clicked.HasDelegate;

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("list-group-item")
        .AddClass("list-group-item-action", when: IsButton)
        .AddClass($"list-group-item-{Color.ToColorString()}", when: Color != Color.Default)
        .AddClass("active", when: Active)
        .AddClass("disabled", when: Disabled && !IsButton);

    private async Task HandleClick(MouseEventArgs args)
    {
        if (Disabled)
        {
            return;
        }

        await Clicked.InvokeAsync();
    }
}
