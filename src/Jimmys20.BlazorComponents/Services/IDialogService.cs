namespace Jimmys20.BlazorComponents
{
    public interface IDialogService
    {
        /// <summary>
        /// Instructs the browser to display a dialog with an optional message, and to wait until the user dismisses the dialog.
        /// </summary>
        /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
        ValueTask Alert();

        /// <summary>
        /// Instructs the browser to display a dialog with an optional message, and to wait until the user dismisses the dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>A <see cref="ValueTask"/> that represents the asynchronous invocation operation.</returns>
        ValueTask Alert(string message);

        /// <summary>
        /// Instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>A boolean indicating whether OK (true) or Cancel (false) was selected. If a browser is ignoring in-page dialogs, then the returned value is always false.</returns>
        ValueTask<bool> Confirm(string message);

        /// <summary>
        /// Instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
        /// </summary>
        /// <returns>A string containing the text entered by the user, or null.</returns>
        ValueTask<string> Prompt();

        /// <summary>
        /// Instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <returns>A string containing the text entered by the user, or null.</returns>
        ValueTask<string> Prompt(string message);

        /// <summary>
        /// Instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="defaultValue"></param>
        /// <returns>A string containing the text entered by the user, or null.</returns>
        ValueTask<string> Prompt(string message, string defaultValue);
    }
}
