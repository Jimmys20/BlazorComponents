﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jimmys20.BlazorComponents.GridLayout.Internal
{
    public partial class JmGridLayoutDropzone<T>
    {
        [Parameter]
        public int Index { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public JmGridLayout<T> GridLayout { get; set; }

        private Func<T, int> IndexField => GridLayout.IndexField;

        private Func<T, int, bool> CanDrop => GridLayout.CanDrop;

        private bool Draggable => GridLayout.Draggable;

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
