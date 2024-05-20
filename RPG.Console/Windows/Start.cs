using Microsoft.Extensions.DependencyInjection;
using RPG.App.Services;
using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class Start : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public Start(IServiceProvider serviceProvider, IPlayerService playerService) : base("RPG Game")
        {
            _serviceProvider = serviceProvider;

            var title = new Label("Welcome to RPG Game!")
            {
                X = Pos.Center(),
                Y = 2,
            };
            Add(title);

            if (playerService.HasExistingPlayers())
            {
                var continueButton = new Button("Continue")
                {
                    X = Pos.Center(),
                    Y = Pos.Center() - 3,
                };
                continueButton.Clicked += PlayerSelection;
                Add(continueButton);
            }

            var startButton = new Button("New Game")
            {
                X = Pos.Center(),
                Y = Pos.Center() - 1,
            };
            startButton.Clicked += StartGame;
            Add(startButton);

            var exitButton = new Button("Exit")
            {
                X = Pos.Center(),
                Y = Pos.Center() + 1,
            };
            exitButton.Clicked += () => Application.RequestStop();
            Add(exitButton);
        }

        private void StartGame()
        {
            var playerCreationScreen = _serviceProvider.GetRequiredService<PlayerCreation>();
            Application.Top.RemoveAll();
            Application.Top.Add(playerCreationScreen);
            Application.Refresh();
        }

        private void PlayerSelection()
        {
            var playerCreationScreen = _serviceProvider.GetRequiredService<PlayerSelection>();
            Application.Top.RemoveAll();
            Application.Top.Add(playerCreationScreen);
            Application.Refresh();
        }
    }
}
