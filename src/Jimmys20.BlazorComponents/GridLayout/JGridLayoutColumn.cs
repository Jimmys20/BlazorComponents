using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents
{
    public class JGridLayoutColumn<T> : ComponentBase
    {
        [Parameter]
        public string Width { get; set; } = "none";

        [CascadingParameter]
        public JGridLayout<T> GridLayout { get; set; }

        protected override void OnInitialized()
        {
            GridLayout.AddColumn(this);
        }
    }
}
