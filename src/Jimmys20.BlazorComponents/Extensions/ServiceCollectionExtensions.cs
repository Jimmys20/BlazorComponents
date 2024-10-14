using Microsoft.Extensions.DependencyInjection;

namespace Jimmys20.BlazorComponents;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJimmys20BlazorComponents(this IServiceCollection services)
    {
        return services
            .AddScoped<IDialogService, DialogService>()
            .AddScoped(typeof(DragDropService<>));
    }
}
