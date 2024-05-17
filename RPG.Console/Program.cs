using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.App;
using RPG.App.Game;
using RPG.App.Menus;
using RPG.App.States;
using RPG.Console;
using RPG.Domain.Events;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;
using Terminal.Gui;
using Dialog = RPG.App.Dialog;


Application.Init();

// Create a window
var win = new Window("ListView Example")
{
    X = 0,
    Y = 1, // Leave space for the top-level menu
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

// Create a list view
var listView = new ListView(new string[] { "Item 1", "Item 2", "Item 3" })
{
    X = 1,
    Y = 1,
    Width = Dim.Fill() - 2, // Leave some space for the border
    Height = Dim.Fill() - 2 // Leave some space for the border
};

// Add the list view to the window
win.Add(listView);

// Add the window to the application
Application.Top.Add(win);

// Run the application
Application.Run();

using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<IGame>().Start();

IHostBuilder CreateHostBuilder(string[] strings) =>
    Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            AddGame(services);
            RegisterMenus(services);
            RegisterStates(services);
            RegisterCommands(services);
            RegisterEvents(services);
            RegisterRepositories(services);
            AddDbContexts(services);
        });

void AddGame(IServiceCollection services)
{
    services.AddScoped<IGame, Game>();
    services.AddScoped<IGameLoop, GameLoop>();
}

void RegisterMenus(IServiceCollection services)
{
    services.AddTransient<StartMenu>();
    services.AddTransient<PlayerClassMenu>();
}

void RegisterStates(IServiceCollection services)
{
    services.AddTransient<StartGame>();
    services.AddTransient<GameExit>();
    services.AddTransient<NewGame>();
}

void RegisterCommands(IServiceCollection services) =>
    services.AddTransient<IDialog>(_ => new Dialog(Prompt.Menu, Prompt.Single));

void RegisterEvents(IServiceCollection services) => services.AddTransient<IPlayerCreatedEventHandler, PlayerCreatedEventHandler>();

void RegisterRepositories(IServiceCollection services) => services.AddTransient<IPlayerRepository, PlayerRepository>();

void AddDbContexts(IServiceCollection services) => services.AddDbContext<PlayerDbContext>();