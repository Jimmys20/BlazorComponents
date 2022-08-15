﻿using Microsoft.AspNetCore.Components;
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
        /// <summary>
        /// Specifies the collection of items that will be displayed.
        /// </summary>
        [Parameter] public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Fires when an item is dropped inside a grid cell.
        /// </summary>
        [Parameter] public EventCallback<DropEventArgs<T>> ItemDropped { get; set; }

        /// <summary>
        /// Allows you to specify grid columns.
        /// </summary>
        [Parameter] public RenderFragment Columns { get; set; }

        /// <summary>
        /// Allows you to specify grid rows.
        /// </summary>
        [Parameter] public RenderFragment Rows { get; set; }

        /// <summary>
        /// Specifies the template used to display the items.
        /// </summary>
        [Parameter] public RenderFragment<T> ItemTemplate { get; set; }

        /// <summary>
        /// Specifies the property that defines the item's index.
        /// </summary>
        [Parameter] public Func<T, int> IndexField { get; set; }

        /// <summary>
        /// Specifies if the item should be allowed to drop to the specific index.
        /// </summary>
        [Parameter] public Func<T, int, bool> CanDrop { get; set; }

        /// <summary>
        /// Specifies the gap between the columns.
        /// </summary>
        [Parameter] public string ColumnGap { get; set; } = "normal";

        /// <summary>
        /// Specifies the gap between the rows.
        /// </summary>
        [Parameter] public string RowGap { get; set; } = "normal";

        /// <summary>
        /// Specifies the classes to be applied to the grid container.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Specifies if the items should be draggable. When set to false, drag and drop is disabled.
        /// </summary>
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
            var args = new DropEventArgs<T>(Payload, index);
            await ItemDropped.InvokeAsync(args);
        }
    }
}