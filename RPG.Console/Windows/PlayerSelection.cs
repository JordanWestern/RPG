using Microsoft.Extensions.DependencyInjection;
using RPG.App.Contracts;
using RPG.App.Services;
using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class PlayerSelection : Window
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IPlayerService _playerService;
        private ExistingPlayer _selectedPlayer;

        public PlayerSelection(IServiceProvider serviceProvider, IPlayerService playerService) : base("Continue")
        {
            _serviceProvider = serviceProvider;
            _playerService = playerService;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var existingPlayers = _playerService.GetExistingPlayers().ToList();

            var titleLabel = new Label("Select a player to continue:")
            {
                X = Pos.Center(),
                Y = 1
            };
            Add(titleLabel);

            var listView = new ListView(existingPlayers.Select(player => player.Name).ToList())
            {
                X = Pos.Percent(10),
                Y = Pos.Top(titleLabel) + 1,
                Height = Dim.Percent(80),
                Width = Dim.Percent(80),
                AllowsMarking = false,
            };
            listView.SelectedItemChanged += _ =>
            {
                _selectedPlayer = existingPlayers.Single(player => player.Id == existingPlayers[listView.SelectedItem].Id);
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
                    // Handle continuation logic with selected player
                    MessageBox.Query("Continue", $"Selected player: {_selectedPlayer.Name}", "Ok");
                    // Implement the logic to continue the game with the selected player
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
                // Navigate back to the start screen
                var startScreen = _serviceProvider.GetRequiredService<Start>();
                Application.Top.RemoveAll();
                Application.Top.Add(startScreen);
                Application.Refresh();
            };
            Add(backButton);
        }
    }
}
