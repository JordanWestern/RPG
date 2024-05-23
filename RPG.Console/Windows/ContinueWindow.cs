using Terminal.Gui;

namespace RPG.Console.Windows
{
    public class ContinueWindow : Window
    {
        public ContinueWindow() : base("RPG Game")
        {
            // Menu Bar
            var menu = new MenuBar(new MenuBarItem[] {
                new MenuBarItem("_File", new MenuItem [] {
                    new MenuItem("_Save", "", Save),
                    new MenuItem("_Exit", "", () => Application.RequestStop())
                })
            });
            Add(menu);

            // Player Stats
            var statsFrame = new FrameView("Player Stats")
            {
                X = 0,
                Y = 1, // Below the menu bar
                Width = Dim.Percent(25),
                Height = Dim.Percent(30),
                CanFocus = false
            };
            var statsLabel = new Label("HP: 100\nMP: 50\nXP: 200")
            {
                X = 1,
                Y = 1,
            };
            statsFrame.Add(statsLabel);
            Add(statsFrame);

            // Map
            var mapFrame = new FrameView("Map")
            {
                X = Pos.Right(statsFrame),
                Y = 1, // Below the menu bar
                Width = 20, // Fixed width
                Height = 20, // Fixed height (making it square)
                CanFocus = false
            };
            var mapLabel = new Label("Map Area")
            {
                X = Pos.Center(),
                Y = Pos.Center(),
            };
            mapFrame.Add(mapLabel);
            Add(mapFrame);

            // Dialog
            var dialogFrame = new FrameView("Dialog")
            {
                X = Pos.Right(mapFrame), // To the right of the map
                Y = 1, // Below the menu bar
                Width = Dim.Fill(), // Fill remaining width
                Height = Dim.Percent(50), // Use a portion of the height
                CanFocus = false
            };

            var dialogTextView = new TextView()
            {
                X = 1,
                Y = 1,
                Width = Dim.Fill() - 2,
                Height = Dim.Fill() - 2,
                ReadOnly = true,
                Text = "NPC: Welcome to the RPG Game!\n\n" +
                       "Here is a long dialog to demonstrate scrolling...\n" +
                       "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                       "Proin laoreet mollis ligula, eget venenatis mauris commodo non. " +
                       "Vivamus laoreet urna eu velit bibendum, ac fermentum orci cursus. " +
                       "Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; " +
                       "Integer facilisis odio in magna consequat varius. " +
                       "Sed eget risus in nisi sollicitudin pretium.\n\n" +
                       "This is the end of the dialog."
            };
            dialogFrame.Add(dialogTextView);
            Add(dialogFrame);

            // Action Menu
            var actionFrame = new FrameView("Actions")
            {
                X = 0,
                Y = Pos.Bottom(statsFrame), // Below the player stats
                Width = Dim.Percent(25), // Same width as statsFrame
                Height = Dim.Fill(), // Fill remaining height
                CanFocus = false
            };
            var equipButton = new Button("Equip Items")
            {
                X = 1,
                Y = 1
            };
            var inventoryButton = new Button("Manage Inventory")
            {
                X = 1,
                Y = 3
            };
            var moveButton = new Button("Move Location")
            {
                X = 1,
                Y = 5
            };
            actionFrame.Add(equipButton);
            actionFrame.Add(inventoryButton);
            actionFrame.Add(moveButton);
            Add(actionFrame);
        }

        private void Save()
        {
            MessageBox.Query("Save", "Game Saved!", "Ok");
        }
    }
}
