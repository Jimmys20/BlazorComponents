using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents;

public class JmGridLayoutColumn<T> : ComponentBase, IDisposable
{
    /// <summary>
    /// Specifies the column's width.
    /// </summary>
    [Parameter] public string Width { get; set; } = "none";

    [CascadingParameter]
    private JmGridLayout<T> GridLayout { get; set; }

    protected override void OnInitialized()
    {
        GridLayout.AddColumn(this);
    }

    public void Dispose()
    {
        GridLayout.RemoveColumn(this);
    }
}
