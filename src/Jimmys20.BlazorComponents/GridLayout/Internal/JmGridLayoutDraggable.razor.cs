using Microsoft.AspNetCore.Components;
using System;

namespace Jimmys20.BlazorComponents.GridLayout.Internal
{
    public partial class JmGridLayoutDraggable<T>
    {
        [Parameter]
        public T Item { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public JmGridLayout<T> GridLayout { get; set; }

        private bool Draggable => GridLayout.Draggable;

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
