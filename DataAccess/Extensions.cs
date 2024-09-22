using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<INoteRepository, NoteRepository>();
        serviceCollection.AddDbContext<AppContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Database=NoteDb;Username=postgres;Password=Vfhfn2020vfhfn");
        });
        return serviceCollection;
    }
}