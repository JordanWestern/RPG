namespace RPG.App.Menus;

public class PlayerClassMenu : IMenu
{
    public string Title => "Select a class:";

    public string[] Options => new[]
    {
        "Warrior",
        "Mage",
        "Rogue"
    };
}