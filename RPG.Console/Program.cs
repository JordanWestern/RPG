using Microsoft.Extensions.DependencyInjection;
using RPG.App.Services;
using RPG.Console;
using RPG.Console.Windows;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;
using Terminal.Gui;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

Application.Init();
Application.Top.Add(serviceProvider.GetRequiredService<MainMenuWindow>());
Application.Run();

static void ConfigureServices(IServiceCollection services)
{
    AddViews(services);
    services.AddTransient<INavigate, Navigate>();
    services.AddTransient<IPlayerService, PlayerService>();
    services.AddTransient<IPlayerRepository, PlayerRepository>();
    services.AddDbContext<PlayerDbContext>();
}

static void AddViews(IServiceCollection services)
{
    services.AddTransient<MainMenuWindow>();
    services.AddTransient<PlayerCreationWindow>();
    services.AddTransient<PlayerSelectionWindow>();
    services.AddTransient<ContinueWindow>();
    services.AddTransient<BattleScreen>();
}