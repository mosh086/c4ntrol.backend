using C4.Application.Common.Patterns.MediatRPattern.Behaviours;
using C4.Application.Providers.ObjectMapper;
using C4.Application.Providers.Serializer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace C4.Application;

public static class DependencyInjections
{
    public static IServiceCollection AddApplicationLibrary(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddAutoMapperProfiles(configuration);

        services.AddMicrosoftSerializer();

        services.AddScoped<ProviderServices>();

        services.AddMediatRService(configuration, assemblies);

        return services;
    }
    private static IServiceCollection AddMediatRService(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        services.AddMediatR(option =>
        {
            option.RegisterServicesFromAssemblies(assemblies.ToArray());
            option.AddOpenBehavior(typeof(AuthorizationBehaviour<,>));
            option.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            option.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            option.AddOpenBehavior(typeof(PerformanceBehaviour<,>));
            option.AddOpenBehavior(typeof(UnhandledExceptionBehaviour<,>));
        });

        return services;
    }
}