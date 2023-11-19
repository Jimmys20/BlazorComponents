namespace Jimmys20.BlazorComponents.Bootstrap;

public abstract class DropdownComponent : BootstrapComponentBase
{
    internal bool Visible { get; private set; }

    internal void Toggle()
    {
        Visible = !Visible;
        StateHasChanged();
    }

    internal void Hide()
    {
        Visible = false;
        StateHasChanged();
    }
}
