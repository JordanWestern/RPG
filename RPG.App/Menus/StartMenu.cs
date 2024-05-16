namespace RPG.App.Menus;

public class StartMenu : IMenu
{
    public const string NewGame = "New Game";

    public const string Exit = "Exit";
    
    public string Title => "Start Menu";

    public string[] Options => new[] { NewGame, Exit };
}