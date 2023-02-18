using Microsoft.JSInterop;

namespace Jimmys20.BlazorComponents
{
    public class DialogService : IDialogService
    {
        private readonly IJSRuntime _jsRuntime;

        public DialogService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        /// <inheritdoc />
        public ValueTask Alert()
            => _jsRuntime.InvokeVoidAsync("alert");

        /// <inheritdoc />
        public ValueTask Alert(string message)
            => _jsRuntime.InvokeVoidAsync("alert", message);

        /// <inheritdoc />
        public ValueTask<bool> Confirm(string message)
            => _jsRuntime.InvokeAsync<bool>("confirm", message);

        /// <inheritdoc />
        public ValueTask<string> Prompt()
            => _jsRuntime.InvokeAsync<string>("prompt");

        /// <inheritdoc />
        public ValueTask<string> Prompt(string message)
            => _jsRuntime.InvokeAsync<string>("prompt", message);

        /// <inheritdoc />
        public ValueTask<string> Prompt(string message, string defaultValue)
            => _jsRuntime.InvokeAsync<string>("prompt", message, defaultValue);
    }
}
