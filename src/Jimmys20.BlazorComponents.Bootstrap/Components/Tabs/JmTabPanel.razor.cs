using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmTabPanel : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies a unique name for the tab panel.
        /// </summary>
        [Parameter] public string Name { get; set; }

        /// <summary>
        /// Specifies the content of the tab panel.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        private JmTabs Tabs { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("tab-pane")
            .AddClass("active", when: Tabs.SelectedTab == Name);
    }
}
