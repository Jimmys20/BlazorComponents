using Microsoft.AspNetCore.Components;
using System;

namespace Jimmys20.BlazorComponents
{
    public partial class _JGridLayoutDraggable<T>
    {
        [Parameter]
        public bool Draggable { get; set; }

        [Parameter]
        public T Item { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public JGridLayout<T> GridLayout { get; set; }

        private void HandleDragStart()
        {
            Console.WriteLine("HandleDragStart");

            GridLayout.Payload = Item;
        }

        private void HandleDragEnd()
        {
            Console.WriteLine("HandleDragEnd");

            GridLayout.Payload = default;
        }
    }
}
