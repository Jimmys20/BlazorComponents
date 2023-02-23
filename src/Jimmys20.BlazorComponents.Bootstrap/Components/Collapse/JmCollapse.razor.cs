using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmCollapse : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies if the collapse is visible.
        /// </summary>
        [Parameter] public bool Visible { get; set; }

        /// <summary>
        /// Specifies the content of the collapse.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("collapse")
            .AddClass("show", when: Visible);
    }
}
