using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmNavbarDropdown : DropdownComponent
    {
        /// <summary>
        /// Specifies the content of the navbar dropdown.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("nav-item dropdown");

        private void HandleFocusOut(FocusEventArgs args)
        {
            Hide();
        }
    }
}
