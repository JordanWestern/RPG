using Microsoft.Extensions.DependencyInjection;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;

namespace RPG.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddScoped<IPlayerRepository, PlayerRepository>()
            .AddDbContext<PlayerDbContext>();
}
