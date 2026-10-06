using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.DAL.Data;
using Portfolio.DAL.Repositories;

namespace Portfolio.DAL;

/// <summary>
/// Extension method that registers all DAL-layer services.
/// Called by BAL's DependencyInjection — never called directly from the API.
/// This keeps the API decoupled from knowing how or where data is stored.
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PortfolioDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            ));

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<ITechnologyRepository, TechnologyRepository>();

        return services;
    }
}
