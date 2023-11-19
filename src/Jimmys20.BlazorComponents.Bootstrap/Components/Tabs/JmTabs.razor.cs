using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmTabs : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the currently selected tab.
    /// </summary>
    [Parameter] public string SelectedTab { get; set; }

    /// <summary>
    /// Fires when the selected tab is changed.
    /// </summary>
    [Parameter] public EventCallback<string> SelectedTabChanged { get; set; }

    /// <summary>
    /// Specifies if the tabs are pills.
    /// </summary>
    [Parameter] public bool Pills { get; set; }

    /// <summary>
    /// Make the tabs fill all available space. The tabs will not have the same width.
    /// </summary>
    [Parameter] public bool Fill { get; set; }

    /// <summary>
    /// Make the tabs fill all available space. The tabs will have the same width.
    /// </summary>
    [Parameter] public bool Justified { get; set; }

    /// <summary>
    /// Allows you to specify tabs.
    /// </summary>
    [Parameter] public RenderFragment Items { get; set; }

    /// <summary>
    /// Allows you to specify tab panels.
    /// </summary>
    [Parameter] public RenderFragment Content { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("nav")
        .AddClass(Pills ? "nav-pills" : "nav-tabs")
        .AddClass("nav-fill", when: Fill)
        .AddClass("nav-justified", when: Justified);

    internal async Task InvokeSelectedTabChangedAsync(string selectedTab)
    {
        await SelectedTabChanged.InvokeAsync(selectedTab);
    }
}
