using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.App;
using RPG.App.Game;
using RPG.App.States;
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
            services.AddScoped<IGame, Game>();
            services.AddScoped<IGameLoop, GameLoop>();
            RegisterStates(services);
            RegisterCommands(services);
            RegisterEvents(services);
            RegisterRepositories(services);
            AddDbContexts(services);
        });

void RegisterStates(IServiceCollection services) => services.AddScoped<GameStart>();

void RegisterCommands(IServiceCollection services) =>
    services.AddScoped<ICommandHandler>(_ => new CommandHandler(RequestPlayerName));

void RegisterEvents(IServiceCollection services) => services.AddScoped<IPlayerCreatedEventHandler, PlayerCreatedEventHandler>();

void RegisterRepositories(IServiceCollection services) => services.AddScoped<IPlayerRepository, PlayerRepository>();

void AddDbContexts(IServiceCollection services) => services.AddDbContext<PlayerDbContext>();

string RequestPlayerName()
{
    Console.WriteLine("What is your name?");

    string? name;

    do
    {
        name = Console.ReadLine();

    } while (string.IsNullOrWhiteSpace(name));

    return name;
}