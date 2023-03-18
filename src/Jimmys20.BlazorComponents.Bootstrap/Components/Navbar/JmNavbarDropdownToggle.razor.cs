using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmNavbarDropdownToggle : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies if the navbar dropdown toggle is disabled.
        /// </summary>
        [Parameter] public bool Disabled { get; set; }

        /// <summary>
        /// Specifies the content of the navbar dropdown toggle.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        private DropdownComponent Dropdown { get; set; }

        private bool Expanded => Dropdown.Visible;

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("btn btn-link nav-link dropdown-toggle");

        private void HandleClick()
        {
            Dropdown.Toggle();
        }
    }
}
