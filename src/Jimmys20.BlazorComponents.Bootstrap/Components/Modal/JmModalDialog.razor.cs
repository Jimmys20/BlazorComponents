using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public partial class JmModalDialog : BootstrapComponentBase
    {
        /// <summary>
        /// Specifies if the modal dialog is scrollable.
        /// </summary>
        [Parameter] public bool Scrollable { get; set; }

        /// <summary>
        /// Specifies if the modal dialog is centered.
        /// </summary>
        [Parameter] public bool Centered { get; set; }

        /// <summary>
        /// Specifies the size of the modal dialog.
        /// </summary>
        [Parameter] public ModalSize Size { get; set; }

        /// <summary>
        /// Specifies the content of the modal dialog.
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }

        protected override CssBuilder CssBuilder => base.CssBuilder
            .AddClass("modal-dialog")
            .AddClass("modal-dialog-scrollable", when: Scrollable)
            .AddClass("modal-dialog-centered", when: Centered)
            .AddClass(Size.ToModalSizeString(), when: Size != ModalSize.Default);
    }
}
