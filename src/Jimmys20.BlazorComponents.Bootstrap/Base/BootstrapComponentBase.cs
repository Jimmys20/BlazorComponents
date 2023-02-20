using BlazorComponentUtilities;
using Microsoft.AspNetCore.Components;

namespace Jimmys20.BlazorComponents.Bootstrap
{
    public abstract class BootstrapComponentBase : ComponentBase
    {
        /// <summary>
        /// Specifies the background color to be applied to the component.
        /// </summary>
        [Parameter] public Background Background { get; set; }

        /// <summary>
        /// Specifies the text color to be applied to the component.
        /// </summary>
        [Parameter] public TextColor TextColor { get; set; }

        /// <summary>
        /// Specifies the font size to be applied to the component.
        /// </summary>
        [Parameter] public FontSize FontSize { get; set; }

        /// <summary>
        /// Specifies the classes to be applied to the component.
        /// </summary>
        [Parameter] public string Class { get; set; }

        /// <summary>
        /// Specifies the styles to be applied to the component.
        /// </summary>
        [Parameter] public string Style { get; set; }

        /// <summary>
        /// Captures values that don't match any other parameter.
        /// </summary>
        [Parameter(CaptureUnmatchedValues = true)] public IDictionary<string, object> AdditionalAttributes { get; set; }

        protected virtual CssBuilder CssBuilder => new CssBuilder()
            .AddClass(Background.ToBackgroundString(), when: Background != Background.Default)
            .AddClass(TextColor.ToTextColorString(), when: TextColor != TextColor.Default)
            .AddClass(FontSize.ToFontSizeString(), when: FontSize != FontSize.Default)
            .AddClass(Class, when: Class != null);

        protected string CssClass => CssBuilder.NullIfEmpty();
    }
}
