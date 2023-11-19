namespace Jimmys20.BlazorComponents.Extensions;

internal static class ObjectExtensions
{
    public static object GetPropertyValue(this object obj, string propertyName)
    {
        var type = obj.GetType();
        var property = type.GetProperty(propertyName);
        var value = property.GetValue(obj, null);

        return value;
    }
}
