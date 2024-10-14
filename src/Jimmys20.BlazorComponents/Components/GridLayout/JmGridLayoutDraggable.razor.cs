using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Jimmys20.BlazorComponents;

public partial class JmGridLayoutDraggable<T> : IDisposable
{
    [Inject]
    private IJSRuntime JS { get; set; }

    [Inject]
    private DragDropService<T> DragDropService { get; set; }

    [Parameter]
    public T Item { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    [Parameter]
    public string Handle { get; set; }

    [CascadingParameter]
    private JmGridLayout<T> GridLayout { get; set; }

    private bool Draggable => GridLayout?.Draggable ?? true;

    private ElementReference _draggableRef;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && Draggable && !string.IsNullOrEmpty(Handle))
        {
            var module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./_content/Jimmys20.BlazorComponents/js/grid-layout.js");

            await module.InvokeVoidAsync("enableDragHandle", _draggableRef, Handle);
        }
    }

    private void HandleDragStart()
    {
        Console.WriteLine("HandleDragStart");

        DragDropService.Payload = Item;
    }

    private void HandleDragEnd()
    {
        Console.WriteLine("HandleDragEnd");

        DragDropService.Payload = default;
    }

    public void Dispose()
    {
        Console.WriteLine("Dispose");

        DragDropService.Payload = default;
    }
}
