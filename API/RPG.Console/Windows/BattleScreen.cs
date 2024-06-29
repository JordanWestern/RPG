using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class BattleScreen : Window
    {
        public BattleScreen() : base("Battle")
        {
            // Player's Pokémon
            var playerPokemonFrame = new FrameView("Player stats")
            {
                X = 0,
                Y = 0,
                Width = Dim.Percent(50),
                Height = Dim.Percent(50),
                CanFocus = false
            };
            var playerPokemonLabel = new Label("Player \nHP: 50/50")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };
            playerPokemonFrame.Add(playerPokemonLabel);
            Add(playerPokemonFrame);

            // Enemy Pokémon
            var enemyPokemonFrame = new FrameView("Enemy stats")
            {
                X = Pos.Percent(50),
                Y = 0,
                Width = Dim.Percent(50),
                Height = Dim.Percent(50),
                CanFocus = false
            };
            var enemyPokemonLabel = new Label("Enemy\nHP: 50/50")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };
            enemyPokemonFrame.Add(enemyPokemonLabel);
            Add(enemyPokemonFrame);

            // Battle Log
            var battleLogFrame = new FrameView("Battle Log")
            {
                X = 0,
                Y = Pos.Percent(50),
                Width = Dim.Fill(),
                Height = Dim.Percent(50),
                CanFocus = false
            };
            var battleLogTextView = new TextView()
            {
                X = 1,
                Y = 1,
                Width = Dim.Fill() - 2,
                Height = Dim.Fill() - 2,
                ReadOnly = true,
                Text = "Battle log will be displayed here..."
            };
            battleLogFrame.Add(battleLogTextView);
            Add(battleLogFrame);

            // Actions Menu
            var actionsFrame = new FrameView("Actions")
            {
                X = 0,
                Y = Pos.Percent(100) - 4, // Place it at the bottom of the window
                Width = Dim.Fill(),
                Height = 3,
                CanFocus = false
            };
            var attackButton = new Button("Attack")
            {
                X = 1,
                Y = 0
            };
            var switchPokemonButton = new Button("Switch weapon")
            {
                X = 11,
                Y = 0
            };
            actionsFrame.Add(attackButton);
            actionsFrame.Add(switchPokemonButton);
            Add(actionsFrame);
        }
    }
}
