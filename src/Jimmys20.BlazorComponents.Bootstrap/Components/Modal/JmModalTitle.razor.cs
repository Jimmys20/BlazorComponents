using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap;

public partial class JmModalTitle : BootstrapComponentBase
{
    /// <summary>
    /// Specifies the content of the modal title.
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override CssBuilder CssBuilder => base.CssBuilder
        .AddClass("modal-title");

    public override async Task SetParametersAsync(ParameterView parameters)
    {
        await base.SetParametersAsync(parameters);

        if (!parameters.TryGetValue<FontSize>(nameof(FontSize), out var fontSize))
        {
            FontSize = FontSize.Is5;
        }
    }
}
