using BlazorComponentUtilities;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmDropdownDivider : BootstrapComponentBase
{
    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("dropdown-divider");
}
