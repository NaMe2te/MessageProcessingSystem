using System.Security.Claims;
using MessageProcessingSystem.DataAccess.Enums;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MessageProcessingSystem.UI.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCookiesAuthentication(this IServiceCollection collection)
    {
        collection
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(1);
                options.SlidingExpiration = true;

                options.LoginPath = "/api/Authentication/login";
                options.AccessDeniedPath = "/api/Authentication/error";
            });

        return collection;
    }

    public static IServiceCollection AddRoles(this IServiceCollection collection)
    {
        return collection.AddAuthorization(options =>
        {
            options.DefaultPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            
            options.AddPolicy("AdminPolicy", policyBuilder =>
            {
                AccountRole[] allowedRoles = { AccountRole.Admin };
                policyBuilder
                    .RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString("G")))
                    .Build();
            });
            options.AddPolicy("ManagerPolicy", policyBuilder =>
            {
                AccountRole[] allowedRoles = { AccountRole.Manager };
                policyBuilder
                    .RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString("G")))
                    .Build();
            });
            options.AddPolicy("SubordinatePolicy", policyBuilder =>
            {
                AccountRole[] allowedRoles = { AccountRole.Subordinate };
                policyBuilder
                    .RequireClaim(ClaimTypes.Role, allowedRoles.Select(x => x.ToString("G")))
                    .Build();
            });
        });
    }
}