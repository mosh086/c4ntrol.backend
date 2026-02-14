using C4.Application.Common.Repository;
using C4.Application.Common.Service;
using C4.Application.Interfaces;
using C4.Application.Providers.CacheSystem;
using C4.Domain.UseCases.Security;
using C4.Infrastructure.Data;
using C4.Infrastructure.Data.Interceptors;
using C4.Infrastructure.Identity;
using C4.Infrastructure.Providers.CacheSystem.InMemory;
using C4.Infrastructure.Providers.DataDapper;
using C4.Infrastructure.Providers.Scrutor;
using C4.Infrastructure.Services;

namespace C4.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureLibrary(this IServiceCollection services, IConfiguration configuration, Assembly[] assemblies)
    {
        return services
            .AddScrutor(configuration, assemblies, [typeof(IRepository<,>), typeof(IEntityService<,,>)])
            .AddDatabase(configuration)
            .AddDatabaseInterceptors()
            .AddInMemoryCaching()
            .AddIdentityConfigurations()
            .AddDataDapper(configuration);
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<C4ntrolDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                   .AddInterceptors(new AddAuditDataInterceptor());
        });

        // Register the password hasher
        services.AddScoped<IPasswordHasher<AppUserEntity>, PasswordHasher<AppUserEntity>>();

        services.AddTransient<IIdentityFactory, IdentityFactory>();
        return services;
    }

    private static IServiceCollection AddDatabaseInterceptors(this IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AddAuditDataInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        return services;
    }

    private static IServiceCollection AddInMemoryCaching(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
    }
}