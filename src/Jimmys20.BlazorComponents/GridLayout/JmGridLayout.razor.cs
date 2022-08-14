using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jimmys20.BlazorComponents
{
#if NET6_0
    [CascadingTypeParameter(nameof(T))]
#endif
    public partial class JmGridLayout<T>
    {
        [Parameter] public IEnumerable<T> Items { get; set; }

        [Parameter] public EventCallback<DropEventArgs<T>> ItemDropped { get; set; }

        [Parameter] public RenderFragment Columns { get; set; }

        [Parameter] public RenderFragment Rows { get; set; }

        [Parameter] public RenderFragment<T> ItemTemplate { get; set; }

        [Parameter] public Func<T, int> IndexField { get; set; }

        [Parameter] public Func<T, int, bool> CanDrop { get; set; }

        [Parameter] public string ColumnGap { get; set; } = "normal";

        [Parameter] public string RowGap { get; set; } = "normal";

        [Parameter] public string Class { get; set; }

        [Parameter] public bool Draggable { get; set; }

        internal T Payload { get; set; }

        private int Capacity => _columns.Count * _rows.Count;

        private readonly List<JmGridLayoutColumn<T>> _columns = new();
        private readonly List<JmGridLayoutRow<T>> _rows = new();

        internal void AddColumn(JmGridLayoutColumn<T> gridLayoutColumn)
        {
            _columns.Add(gridLayoutColumn);
            StateHasChanged();
        }

        internal void AddRow(JmGridLayoutRow<T> gridLayoutRow)
        {
            _rows.Add(gridLayoutRow);
            StateHasChanged();
        }

        internal void RemoveColumn(JmGridLayoutColumn<T> gridLayoutColumn)
        {
            _columns.Remove(gridLayoutColumn);
            StateHasChanged();
        }

        internal void RemoveRow(JmGridLayoutRow<T> gridLayoutRow)
        {
            _rows.Remove(gridLayoutRow);
            StateHasChanged();
        }

        internal async Task InvokeItemDroppedAsync(int index)
        {
            await ItemDropped.InvokeAsync(new DropEventArgs<T>
            {
                Item = Payload,
                Index = index,
            });
        }
    }
}
