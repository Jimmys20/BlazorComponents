using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmModalBody : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies the content of the modal body.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("modal-body");
    }
}
