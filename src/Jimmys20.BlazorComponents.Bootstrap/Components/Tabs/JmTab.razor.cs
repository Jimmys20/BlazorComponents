using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmTab : BootstrapComponentBase
{
    /// <summary>
    /// Specifies a unique name for the tab.
    /// </summary>
    [Parameter] public string Name { get; set; }

    /// <summary>
    /// Specifies if the tab is disabled.
    /// </summary>
    [Parameter] public bool Disabled { get; set; }

    /// <summary>
    /// Specifies the content of the tab.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    [CascadingParameter]
    private JmTabs Tabs { get; set; }

    private bool Active => Tabs.SelectedTab == Name;

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("nav-link")
        .AddClass("active", when: Active);

    private async Task HandleClick()
    {
        if (Disabled || Active)
        {
            return;
        }

        await Tabs.InvokeSelectedTabChangedAsync(Name);
    }
}
