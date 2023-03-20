using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmDropdownItem : BootstrapComponentBase
    {
        /// <summary>
        /// Fires when the dropdown item is clicked.
        /// </summary>
        [Parameter] public EventCallback Clicked { get; set; }

        /// <summary>
        /// Specifies if the dropdown item is disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Specifies the content of the dropdown item.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("dropdown-item");

        private async Task HandleMouseUp(MouseEventArgs args)
        {
            if (Disabled)
            {
                return;
            }

            if (args.Button == 0)
            {
                await Clicked.InvokeAsync();
            }
        }
    }
}
