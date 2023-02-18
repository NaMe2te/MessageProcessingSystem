using MessageProcessingSystem.Application.Services;
using MessageProcessingSystem.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace MessageProcessingSystem.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IManagerService, ManagerService>();
        collection.AddScoped<ISourceService, SourceService>();
        collection.AddScoped<ISubordinatesService, SubordinatesService>();
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<IAuthenticationService, AuthenticationService>();
        
        return collection;
    }
}