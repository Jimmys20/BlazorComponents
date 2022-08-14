using Microsoft.AspNetCore.Components;
using System;

namespace Jimmys20.BlazorComponents
{
    public class JmGridLayoutColumn<T> : ComponentBase, IDisposable
    {
        [Parameter]
        public string Width { get; set; } = "none";

        [CascadingParameter]
        public JmGridLayout<T> GridLayout { get; set; }

        protected override void OnInitialized()
        {
            GridLayout.AddColumn(this);
        }

        public void Dispose()
        {
            GridLayout.RemoveColumn(this);
        }
    }
}
