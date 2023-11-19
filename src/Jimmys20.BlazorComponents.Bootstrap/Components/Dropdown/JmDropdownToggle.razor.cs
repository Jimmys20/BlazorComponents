using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmDropdownToggle : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the color of the dropdown toggle.
    /// </summary>
    [Parameter] public Color Color { get; set; }

    /// <summary>
    /// Specifies if the dropdown toggle is outline.
    /// </summary>
    [Parameter] public bool Outline { get; set; }

    /// <summary>
    /// Specifies if the dropdown toggle is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Specifies if the dropdown toggle is split.
    /// </summary>
    //[Parameter] public bool Split { get; set; }

    /// <summary>
    /// Specifies the content of the dropdown toggle.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    [CascadingParameter]
    private DropdownComponent Dropdown { get; set; }

    private bool Visible => Dropdown.Visible;

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("btn dropdown-toggle")
        .AddClass(Outline ? $"btn-outline-{Color.ToColorString()}" : $"btn-{Color.ToColorString()}", when: Color != Color.Default)
        .AddClass("show", when: Visible);

    private void HandleClick()
    {
        Dropdown.Toggle();
    }
}
