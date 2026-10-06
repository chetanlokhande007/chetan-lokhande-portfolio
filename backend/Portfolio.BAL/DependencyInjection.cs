using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.BAL.Services;
using Portfolio.DAL;

namespace Portfolio.BAL;

/// <summary>
/// Extension method that registers all BAL-layer services
/// and cascades down to register DAL-layer services.
///
/// The API only needs to call AddBusinessAccess().
/// It does not need to know that a database exists.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddBusinessAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register DAL (database + EF Core + repositories)
        services.AddDataAccess(configuration);

        // Register BAL services
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ITechnologyService, TechnologyService>();

        return services;
    }
}
