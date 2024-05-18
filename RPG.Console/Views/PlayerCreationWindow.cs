using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class PlayerCreationWindow : Window
    {
        public PlayerCreationWindow()
        {
            Title = "New player";

            // Create input components and labels
            var playerNameLabel = new Label()
            {
                Text = "Player name:"
            }; 

            var playerNameTextField = new TextField("")
            {
                // Position text field adjacent to the label
                X = Pos.Right(playerNameLabel) + 1,

                // Fill remaining horizontal space
                Width = Dim.Fill(),
            };

            var createButton = new Button()
            {
                Text = "Create",
                Y = Pos.Bottom(playerNameLabel) + 1,
                X = Pos.Center(),
                IsDefault = true,
            };

            Add(playerNameLabel, playerNameTextField, createButton);
        }
    }
}
