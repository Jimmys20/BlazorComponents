using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents;

public class JmSpinningWheelSector : ComponentBase, IDisposable
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string Color { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public string Label { get; set; }

    [CascadingParameter]
    private JmSpinningWheel SpinningWheel { get; set; }

    protected override void OnInitialized()
    {
        SpinningWheel.AddSector(this);
    }

    public void Dispose()
    {
        SpinningWheel.RemoveSector(this);
    }
}
