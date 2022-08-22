﻿using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Jimmys20.BlazorComponents.GridLayout.Internal
{
    public partial class JmGridLayoutDraggable<T>
    {
        [Inject]
        private IJSRuntime JS { get; set; }

        [Parameter]
        public T Item { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [CascadingParameter]
        public JmGridLayout<T> GridLayout { get; set; }

        private bool Draggable => GridLayout.Draggable;

        private string Handle => GridLayout.Handle;

        private ElementReference draggableRef;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && Draggable && !string.IsNullOrEmpty(Handle))
            {
                var module = await JS.InvokeAsync<IJSObjectReference>("import",
                    "./_content/Jimmys20.BlazorComponents/js/grid-layout.js");

                await module.InvokeVoidAsync("enableDragHandle", draggableRef, Handle);
            }
        }

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
