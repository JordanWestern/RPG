using Terminal.Gui;

namespace RPG.Console.Windows;

public class StartWindow : Window
{
    public StartWindow(Action<View> onSelect)
    {
        Title = "Game";

        var menuLabel = new Label("Menu")
        {
            X = Pos.Center(),
            Y = Pos.Percent(10)
        };
        var listView = new ListView(new string[] { "Start Game", "Exit" })
        {
            X = Pos.Center(),
            Y = Pos.Center(),
            Width = Dim.Percent(50),
            Height = Dim.Percent(50)
        };

        Add(menuLabel, listView);

        listView.OpenSelectedItem += _ => onSelect(this);
    }
}