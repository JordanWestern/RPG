using RPG.App.Contracts;
using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class PlayerSelectionWindow : Window
    {
        private readonly INavigate _navigate;
        private readonly IReadOnlyList<ExistingPlayer> _existingPlayers;
        private ExistingPlayer _selectedPlayer;

        public PlayerSelectionWindow(IEnumerable<ExistingPlayer> existingPlayers, INavigate navigate) : base("Continue")
        {
            _navigate = navigate;
            _existingPlayers = existingPlayers.ToList();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var titleLabel = new Label("Select a player to continue:")
            {
                X = Pos.Center(),
                Y = 1
            };
            Add(titleLabel);

            var listView = new ListView(_existingPlayers.Select(player => player.Name).ToList())
            {
                X = Pos.Percent(10),
                Y = Pos.Top(titleLabel) + 1,
                Height = Dim.Percent(80),
                Width = Dim.Percent(80),
                AllowsMarking = false,
            };
            listView.SelectedItemChanged += _ =>
            {
                _selectedPlayer = _existingPlayers.Single(player => player.Id == _existingPlayers[listView.SelectedItem].Id);
            };
            Add(listView);

            var continueButton = new Button("Continue")
            {
                X = Pos.Center(),
                Y = Pos.Percent(90)
            };
            continueButton.Clicked += () =>
            {
                if (_selectedPlayer != null)
                {
                    MessageBox.Query("Continue", $"Selected player: {_selectedPlayer.Name}", "Ok");
                }
                else
                {
                    MessageBox.ErrorQuery("Error", "Please select a player to continue.", "Ok");
                }
            };
            Add(continueButton);

            var backButton = new Button("Back")
            {
                X = Pos.Percent(10),
                Y = Pos.Percent(90)
            };
            backButton.Clicked += () =>
            {
                _navigate.To<ContinueWindow>();
            };
            Add(backButton);
        }
    }
}
