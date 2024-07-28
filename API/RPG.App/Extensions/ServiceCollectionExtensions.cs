using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPG.App.EventHandlers;
using RPG.App.Services;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;

namespace RPG.App.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddSignalR();

        services.AddScoped<IGameEventService, GameEventService>();

        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IGameLogRepository, GameLogRepository>();

        services.AddDbContext<PlayerDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("Players"));
        services.AddDbContext<GameLogDbContext>(optionsBuilder => optionsBuilder.UseInMemoryDatabase("GameLogs"));

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(PlayerCreatedEventHandler).Assembly));
    }
}
