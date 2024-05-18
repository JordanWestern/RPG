using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.App;
using RPG.App.Game;
using RPG.App.States;
using RPG.Console.Windows;
using RPG.Domain.Events;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;
using Terminal.Gui;

using var host = CreateHostBuilder(args).Build();
Application.Init();
Application.Top.Add(host.Services.GetRequiredService<StartWindow>());
Application.Top.Add(host.Services.GetRequiredService<PlayerCreationWindow>());
//https://github.com/gui-cs/Terminal.Gui
Application.Run();
Application.Shutdown();

IHostBuilder CreateHostBuilder(string[] strings) =>
    Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            AddViews(services);
            AddGame(services);
            RegisterStates(services);
            RegisterEvents(services);
            RegisterRepositories(services);
            AddDbContexts(services);
        });

void AddViews(IServiceCollection services)
{
    services.AddSingleton(sp =>
    {
        var playerCreationWindow = sp.GetRequiredService<PlayerCreationWindow>();
        return new StartWindow(window =>
        {
            window.Visible = false;
            playerCreationWindow.Visible = true;
            playerCreationWindow.SetFocus();
        });
    });

    services.AddSingleton(_ => new PlayerCreationWindow{Visible = false});
}

void AddView(View view, IServiceCollection services) => services.AddSingleton(view);

void AddGame(IServiceCollection services)
{
    services.AddTransient<IGame, Game>();
    services.AddTransient<IGameLoop, GameLoop>();
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