using C4.Application.Providers.DataDapper;
using Microsoft.Data.SqlClient;

namespace C4.Infrastructure.Providers.DataDapper;

public static class DependencyInjection
{
    public static IServiceCollection AddDataDapper(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(); // Use your specific DbConnection here
            connection.ConnectionString = configuration.GetConnectionString("DefaultConnection");
            return connection;
        });

        services.AddScoped<IDataDapper, DataDapper>();

        return services;
    }
}