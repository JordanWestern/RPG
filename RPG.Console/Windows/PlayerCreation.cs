using Microsoft.Extensions.DependencyInjection;
using RPG.App.Contracts;
using RPG.App.Services;
using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class PlayerCreation : Window
    {
        private readonly IServiceProvider _serviceProvider;

        public PlayerCreation(IServiceProvider serviceProvider, IPlayerService playerService) : base("Player Creation")
        {
            _serviceProvider = serviceProvider;
            // Create name input
            var nameLabel = new Label("Name:")
            {
                X = 2,
                Y = 2,
            };
            var nameField = new TextField("")
            {
                X = Pos.Right(nameLabel) + 1,
                Y = Pos.Top(nameLabel),
                Width = 40,
            };

            // Create button
            var createButton = new Button("Create")
            {
                X = Pos.Center(),
                Y = Pos.Bottom(nameField) + 2,
            };
            createButton.Clicked += () =>
            {
                var newPlayer = new NewPlayer(nameField.Text.ToString());
                
                if (newPlayer.IsValid())
                {
                    playerService.CreateNewPlayer(newPlayer);
                    StartGame();
                }
                else
                {
                    MessageBox.ErrorQuery("Error", "Invalid name", "Ok");
                }
            };

            // Add controls to the window
            Add(nameLabel, nameField, createButton);
        }
        
        private void StartGame()
        {
            var start = _serviceProvider.GetRequiredService<Start>();
            Application.Top.RemoveAll();
            Application.Top.Add(start);
            Application.Refresh();
        }
    }
}