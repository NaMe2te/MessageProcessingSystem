using MessageProcessingSystem.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MessageProcessingSystem.DataAccess.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataAccess(this IServiceCollection collection, Action<DbContextOptionsBuilder> configuration)
    {
        collection.AddDbContext<DatabaseContext>(configuration);
        collection.AddScoped<IDatabaseContext>(x => x.GetRequiredService<DatabaseContext>());
        return collection;
    }
}