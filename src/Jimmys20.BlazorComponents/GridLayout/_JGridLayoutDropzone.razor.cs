using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jimmys20.BlazorComponents
{
    public partial class _JGridLayoutDropzone<T>
    {
        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public Func<T, int> IndexField { get; set; }

        [Parameter]
        public Func<T, int, bool> CanDrop { get; set; }

        [Parameter]
        public bool Draggable { get; set; }

        [CascadingParameter]
        public JGridLayout<T> GridLayout { get; set; }

        private string _dropClass;
        private int _counter;

        private async Task HandleDrop()
        {
            _counter = 0;
            _dropClass = null;

            if (!Draggable ||
                EqualityComparer<T>.Default.Equals(GridLayout.Payload, default) ||
                IndexField.Invoke(GridLayout.Payload) == Index ||
                CanDrop?.Invoke(GridLayout.Payload, Index) == false)
            {
                return;
            }

            Console.WriteLine("HandleDrop");

            await GridLayout.InvokeItemDroppedAsync(Index);
        }

        private void HandleDragEnter()
        {
            if (!Draggable ||
                EqualityComparer<T>.Default.Equals(GridLayout.Payload, default) ||
                IndexField.Invoke(GridLayout.Payload) == Index)
            {
                return;
            }

            Console.WriteLine("HandleDragEnter");

            _counter++;

            if (CanDrop?.Invoke(GridLayout.Payload, Index) == false)
            {
                _dropClass = "j-no-drop";
            }
            else
            {
                _dropClass = "j-can-drop";
            }
        }

        private void HandleDragLeave()
        {
            if (!Draggable ||
                EqualityComparer<T>.Default.Equals(GridLayout.Payload, default) ||
                IndexField.Invoke(GridLayout.Payload) == Index)
            {
                return;
            }

            Console.WriteLine("HandleDragLeave");

            _counter--;

            if (_counter == 0)
            {
                _dropClass = null;
            }
        }
    }
}
