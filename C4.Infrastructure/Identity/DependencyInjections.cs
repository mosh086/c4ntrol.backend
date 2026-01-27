using C4.Infrastructure.Identity.Handlers;
using Microsoft.AspNetCore.Authorization;

namespace C4.Infrastructure.Identity;

public static class DependencyInjections
{
    public static IServiceCollection AddIdentityConfigurations(this IServiceCollection services)
    {

        services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
        return services;
    }
}