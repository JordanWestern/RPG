using RPG.App.Services;
using Terminal.Gui;

namespace RPG.Console.Windows;

public class MainMenuWindow : Window
{
    public MainMenuWindow(IPlayerService playerService, INavigate navigate, IServiceProvider serviceProvider) : base("RPG Game")
    {
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
            continueButton.Clicked += navigate.To<PlayerSelectionWindow>;
            Add(continueButton);
        }

        var startButton = new Button("New Game")
        {
            X = Pos.Center(),
            Y = Pos.Center() - 1,
        };
        startButton.Clicked += navigate.To<PlayerCreationWindow>;
        Add(startButton);

        var exitButton = new Button("Exit")
        {
            X = Pos.Center(),
            Y = Pos.Center() + 1,
        };
        exitButton.Clicked += () => Application.RequestStop();
        Add(exitButton);
    }
}