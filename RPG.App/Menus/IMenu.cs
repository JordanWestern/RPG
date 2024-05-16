namespace RPG.App.Menus;

public interface IMenu
{
    string Title { get; }

    string[] Options { get; }
}