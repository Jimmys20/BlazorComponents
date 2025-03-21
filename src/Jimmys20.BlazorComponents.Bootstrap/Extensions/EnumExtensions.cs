namespace Jimmys20.BlazorComponents.Bootstrap;

internal static class EnumExtensions
{
    public static string ToBackgroundString(this Background background) => background switch
    {
        Background.Default => null,
        Background.Primary => "bg-primary",
        Background.Secondary => "bg-secondary",
        Background.Success => "bg-success",
        Background.Danger => "bg-danger",
        Background.Warning => "bg-warning",
        Background.Info => "bg-info",
        Background.Light => "bg-light",
        Background.Dark => "bg-dark",
        Background.Body => "bg-body",
        Background.White => "bg-white",
        Background.Transparent => "bg-transparent",
        _ => throw new ArgumentOutOfRangeException(nameof(background), $"Not expected background value: {background}"),
    };

    public static string ToBreakpointString(this Breakpoint breakpoint) => breakpoint switch
    {
        Breakpoint.Default => null,
        Breakpoint.Small => "sm",
        Breakpoint.Medium => "md",
        Breakpoint.Large => "lg",
        Breakpoint.ExtraLarge => "xl",
        Breakpoint.ExtraExtraLarge => "xxl",
        _ => throw new ArgumentOutOfRangeException(nameof(breakpoint), $"Not expected breakpoint value: {breakpoint}"),
    };

    public static string ToButtonTypeString(this ButtonType buttonType) => buttonType switch
    {
        ButtonType.Button => "button",
        ButtonType.Submit => "submit",
        ButtonType.Reset => "reset",
        _ => throw new ArgumentOutOfRangeException(nameof(buttonType), $"Not expected button type value: {buttonType}"),
    };

    public static string ToColorString(this Color color) => color switch
    {
        Color.Default => null,
        Color.Primary => "primary",
        Color.Secondary => "secondary",
        Color.Success => "success",
        Color.Danger => "danger",
        Color.Warning => "warning",
        Color.Info => "info",
        Color.Light => "light",
        Color.Dark => "dark",
        _ => throw new ArgumentOutOfRangeException(nameof(color), $"Not expected color value: {color}"),
    };

    public static string ToFontSizeString(this FontSize fontSize) => fontSize switch
    {
        FontSize.Default => null,
        FontSize.Is1 => "fs-1",
        FontSize.Is2 => "fs-2",
        FontSize.Is3 => "fs-3",
        FontSize.Is4 => "fs-4",
        FontSize.Is5 => "fs-5",
        FontSize.Is6 => "fs-6",
        _ => throw new ArgumentOutOfRangeException(nameof(fontSize), $"Not expected font size value: {fontSize}"),
    };

    public static string ToModalSizeString(this ModalSize modalSize) => modalSize switch
    {
        ModalSize.Default => null,
        ModalSize.Small => "modal-sm",
        ModalSize.Large => "modal-lg",
        ModalSize.ExtraLarge => "modal-xl",
        ModalSize.Fullscreen => "modal-fullscreen",
        _ => throw new ArgumentOutOfRangeException(nameof(modalSize), $"Not expected modal size value: {modalSize}"),
    };

    public static string ToTextColorString(this TextColor textColor) => textColor switch
    {
        TextColor.Default => null,
        TextColor.Primary => "text-primary",
        TextColor.Secondary => "text-secondary",
        TextColor.Success => "text-success",
        TextColor.Danger => "text-danger",
        TextColor.Warning => "text-warning",
        TextColor.Info => "text-info",
        TextColor.Light => "text-light",
        TextColor.Dark => "text-dark",
        TextColor.Body => "text-body",
        TextColor.Muted => "text-muted",
        TextColor.White => "text-white",
        TextColor.Black50 => "text-black-50",
        TextColor.White50 => "text-white-50",
        _ => throw new ArgumentOutOfRangeException(nameof(textColor), $"Not expected text color value: {textColor}"),
    };

    public static string ToButtonSizeString(this ButtonSize buttonSize) => buttonSize switch
    {
        ButtonSize.Default => null,
        ButtonSize.Small => "btn-sm",
        ButtonSize.Large => "btn-lg",
        _ => throw new ArgumentOutOfRangeException(nameof(buttonSize), $"Not expected button size value: {buttonSize}"),
    };
}
