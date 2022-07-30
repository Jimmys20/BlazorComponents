using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace Jimmys20.BlazorComponents
{
    public partial class JSelect<T>
    {
        [Parameter]
        public IEnumerable<T> Data { get; set; }
        [Parameter]
        public string DisplayItem { get; set; }
        [Parameter]
        public string ValueItem { get; set; }

        private bool isVisible { get; set; }
    }
}
