using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmDropdownMenu : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies if the dropdown menu is right aligned.
        /// </summary>
        [Parameter] public bool RightAligned { get; set; }

        /// <summary>
        /// Specifies the content of the dropdown menu.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        private DropdownComponent Dropdown { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("dropdown-menu")
            .AddClass("dropdown-menu-end", when: RightAligned)
            .AddClass("show", when: Dropdown.Visible);

        private void HandleClick()
        {
            Dropdown.Hide();
        }
    }
}
