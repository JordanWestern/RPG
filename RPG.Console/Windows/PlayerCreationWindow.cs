using RPG.App.Contracts;
using RPG.App.Services;
using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class PlayerCreationWindow : Window
    {
        public PlayerCreationWindow(IPlayerService playerService, INavigate navigate) : base("Player Creation")
        {
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
                    var existingPlayer = playerService.CreateNewPlayer(newPlayer);
                    navigate.To<BattleScreen>();
                }
                else
                {
                    MessageBox.ErrorQuery("Error", "Invalid name", "Ok");
                }
            };

            Add(nameLabel, nameField, createButton);
        }
    }
}