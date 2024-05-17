namespace RPG.App.Views;

public class StartGameView : IView, IMenu
{
    public string Title => "Menu";

    public string[] MenuItems => new[]
    {
        "New Game",
        "Exit"
    };

    public string OnMenuItemSelected(string item) => item;
}