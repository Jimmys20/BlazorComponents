using Excubo.Blazor.Canvas;
using Excubo.Blazor.Canvas.Contexts;
using Jimmys20.BlazorComponents.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Jimmys20.BlazorComponents;

public partial class JmSpinningWheel : IAsyncDisposable
{
    private IJSObjectReference _module;
    private DotNetObjectReference<JmSpinningWheel> _selfReference;
    private ElementReference _canvasRef;
    private Context2D _context = null;
    private bool _isSpinning = false;
    private double _angle = 0;
    private int _selectedSlotIndex = -1;
    private readonly List<JmSpinningWheelSector> _sectors = [];

    /// <summary>
    /// 
    /// </summary>
    //[Parameter] public string SelectedSlot { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public EventCallback SpinStarted { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public EventCallback<string> SpinCompleted { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public int Size { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter] public RenderFragment ChildContent { get; set; }

    /// <summary>
    /// Captures values that don't match any other parameter.
    /// </summary>
    [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> AdditionalAttributes { get; set; }

    [Inject] private IJSRuntime JS { get; set; }

    private int NumberOfSlots => _sectors.Count;
    private double Diameter => Size;
    private double Radius => Diameter / 2;
    private double Arc => Math.Tau / NumberOfSlots;

    private static double Mod(double n, double m) => (n % m + m) % m;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _module = await JS.InvokeAsync<IJSObjectReference>("import",
                "./_content/Jimmys20.BlazorComponents/js/spinning-wheel.js");
            _selfReference = DotNetObjectReference.Create(this);

            _context = await JS.GetContext2DAsync(_canvasRef);
            await DrawWheel();
        }
    }

    public async Task Redraw()
    {
        await _context.ClearRectAsync(0, 0, Size, Size);
        await DrawWheel();
    }

    private async Task DrawWheel()
    {
        await using Batch2D batch = _context.CreateBatch();

        for (var i = 0; i < NumberOfSlots; i++)
        {
            var sector = _sectors[i];

            await DrawSector(batch, sector, i);
        }
    }

    private async Task DrawSector(Batch2D batch, JmSpinningWheelSector sector, int i)
    {
        double angle = Arc * i;

        await batch.SaveAsync();

        await batch.BeginPathAsync();
        await batch.FillStyleAsync(sector.Color);
        await batch.MoveToAsync(Radius, Radius);
        await batch.ArcAsync(Radius, Radius, Radius, angle, angle + Arc);
        await batch.LineToAsync(Radius, Radius);
        await batch.FillAsync(FillRule.NonZero);

        await batch.TranslateAsync(Radius, Radius);
        await batch.RotateAsync(angle + Arc / 2);
        await batch.TextAlignAsync(TextAlign.Right);
        await batch.FillStyleAsync("#fff");
        await batch.FontAsync("bold 30px sans-serif");
        await batch.FillTextAsync(sector.Label, Radius - 10, 10);

        await batch.RestoreAsync();
    }

    public async Task Spin(int numberOfTimes, bool shouldRandomizeNumberOfSpins = false)
    {
        if (_isSpinning)
        {
            return;
        }

        _isSpinning = true;

        var angleAbsolute = Mod(_angle, Math.Tau);

        _selectedSlotIndex = Random.Shared.Next(0, NumberOfSlots);
        var angleNew = Math.Tau - Arc * _selectedSlotIndex;
        angleNew -= Random.Shared.NextDouble(0, Arc);
        angleNew = Mod(angleNew, Math.Tau);

        var angleDifference = Mod(angleNew - angleAbsolute, Math.Tau);

        var revolutions = Math.Tau * (shouldRandomizeNumberOfSpins ? Random.Shared.Next(1, numberOfTimes + 1) : numberOfTimes);

        _angle += angleDifference + revolutions;

        var duration = Random.Shared.Next(4000, 5000);
        await _module.InvokeVoidAsync("spin", _canvasRef, _angle, duration, _selfReference);

        await SpinStarted.InvokeAsync();
    }

    [JSInvokable]
    public async Task HandleAnimationFinish()
    {
        _isSpinning = false;
        //_selectedSlotIndex = -1;

        var nameOfSelectedSlot = _sectors[_selectedSlotIndex].Label;
        await SpinCompleted.InvokeAsync(nameOfSelectedSlot);
    }

    public async ValueTask DisposeAsync()
    {
        _selfReference?.Dispose();

        if (_module != null)
        {
            await _module.InvokeVoidAsync("cancelAnimations", _canvasRef);
            await _module.DisposeAsync();
        }

        if (_context != null)
        {
            await _context.DisposeAsync();
        }
    }

    internal void AddSector(JmSpinningWheelSector spinningWheelSector)
    {
        if (!_sectors.Contains(spinningWheelSector))
        {
            _sectors.Add(spinningWheelSector);
            //StateHasChanged();
        }
    }

    internal void RemoveSector(JmSpinningWheelSector spinningWheelSector)
    {
        if (_sectors.Remove(spinningWheelSector))
        {
            //StateHasChanged();
        }
    }
}
