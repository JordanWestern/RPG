using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.App;
using RPG.App.Game;
using RPG.App.States;
using RPG.Console;
using RPG.Domain.Events;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;

using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<IGame>().Start();

IHostBuilder CreateHostBuilder(string[] strings) =>
    Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IGui, Gui>();
            AddGame(services);
            RegisterStates(services);
            RegisterEvents(services);
            RegisterRepositories(services);
            AddDbContexts(services);
        });

void AddGame(IServiceCollection services)
{
    services.AddScoped<IGame, Game>();
    services.AddScoped<IGameLoop, GameLoop>();
}

void RegisterStates(IServiceCollection services)
{
    services.AddTransient<StartGame>();
    services.AddTransient<GameExit>();
    services.AddTransient<NewGame>();
}

void RegisterEvents(IServiceCollection services) => services.AddTransient<IPlayerCreatedEventHandler, PlayerCreatedEventHandler>();

void RegisterRepositories(IServiceCollection services) => services.AddTransient<IPlayerRepository, PlayerRepository>();

void AddDbContexts(IServiceCollection services) => services.AddDbContext<PlayerDbContext>();