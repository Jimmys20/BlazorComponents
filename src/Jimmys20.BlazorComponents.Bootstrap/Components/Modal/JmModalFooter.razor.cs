using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmModalFooter : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies the content of the modal footer.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("modal-footer");
    }
}
