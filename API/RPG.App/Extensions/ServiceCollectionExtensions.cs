using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPG.App.EventHandlers;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;

namespace RPG.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSignalR();

        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IGameLogRepository, GameLogRepository>();
        services.AddScoped<IMapFileRepository, MapFileRepository>();
        services.AddScoped<IMapFileSource, JsonFileMapSource>();

        services.AddDbContext<ApplicationDbContext>(optionsBuilder => optionsBuilder.UseSqlite("Data Source=rpg.db", options => options.MigrationsAssembly("RPG.Infrastructure")));

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(PlayerCreatedEventHandler).Assembly));
    }
}
