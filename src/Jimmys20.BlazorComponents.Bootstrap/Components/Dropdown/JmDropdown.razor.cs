using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmDropdown : DropdownComponent
{
    /// <summary>
    /// Specifies the content of the dropdown.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("btn-group");

    private void HandleFocusOut(FocusEventArgs args)
    {
        Hide();
    }
}
