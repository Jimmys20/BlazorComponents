using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmListGroup : BootstrapComponentBase
{
    /// <summary>
    /// Specifies if the list group is flush.
    /// </summary>
    [Parameter] public bool Flush { get; set; }

    /// <summary>
    /// Specifies if the list group is numbered.
    /// </summary>
    [Parameter] public bool Numbered { get; set; }

    /// <summary>
    /// Specifies the content of the list group.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("list-group")
        .AddClass("list-group-flush", when: Flush)
        .AddClass("list-group-numbered", when: Numbered);
}
