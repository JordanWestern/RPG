using Microsoft.Extensions.DependencyInjection;
using RPG.App.Services;
using RPG.Console.Windows;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;
using Terminal.Gui;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var serviceProvider = serviceCollection.BuildServiceProvider();

Application.Init();
var startScreen = serviceProvider.GetService<Start>();
Application.Top.Add(startScreen);
Application.Run();

static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<Start>();
    services.AddTransient<PlayerCreation>();
    services.AddTransient<PlayerSelection>();
    services.AddTransient<IPlayerService, PlayerService>();
    services.AddTransient<IPlayerRepository, PlayerRepository>();
    services.AddDbContext<PlayerDbContext>();
}