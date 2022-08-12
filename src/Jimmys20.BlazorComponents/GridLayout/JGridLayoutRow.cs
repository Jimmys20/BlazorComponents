using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents
{
    public class JGridLayoutRow<T> : ComponentBase
    {
        [Parameter]
        public string Height { get; set; } = "none";

        [CascadingParameter]
        public JGridLayout<T> GridLayout { get; set; }

        protected override void OnInitialized()
        {
            GridLayout.AddRow(this);
        }
    }
}
