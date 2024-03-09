using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Geekiam.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddFeedsDatabase(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString(ConnectionStringNames.Name);

        if (string.IsNullOrEmpty(connectionString)) throw new Exception(PersistenceErrors.NoConnectionStringDefined);
        
        services.AddDbContext<FeedsContext>(options =>
            options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly(typeof(FeedsContext).Assembly.FullName)  
            ), ServiceLifetime.Transient);
        return services;
    }
}