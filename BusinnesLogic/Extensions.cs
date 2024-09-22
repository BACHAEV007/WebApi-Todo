using Microsoft.Extensions.DependencyInjection;

namespace BusinnesLogic;

public static class Extensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INoteService, NoteService>();
        return serviceCollection;
    }
}