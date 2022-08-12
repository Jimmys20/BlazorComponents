using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Jimmys20.BlazorComponents
{
    public partial class JGridLayout<T>
    {
        [Parameter] public IEnumerable<T> Data { get; set; }

        [Parameter] public RenderFragment Columns { get; set; }

        [Parameter] public RenderFragment Rows { get; set; }

        [Parameter] public RenderFragment<T> ChildContent { get; set; }

        [Parameter] public string D { get; set; }

        [Parameter] public string ColumnGap { get; set; } = "normal";

        [Parameter] public string RowGap { get; set; } = "normal";

        [Parameter] public string Class { get; set; }

        private List<JGridLayoutColumn<T>> _columns = new();
        private List<JGridLayoutRow<T>> _rows = new();

        public void AddColumn(JGridLayoutColumn<T> gridLayoutColumn)
        {
            _columns.Add(gridLayoutColumn);
            StateHasChanged();
        }

        public void AddRow(JGridLayoutRow<T> gridLayoutRow)
        {
            _rows.Add(gridLayoutRow);
            StateHasChanged();
        }
    }
}
