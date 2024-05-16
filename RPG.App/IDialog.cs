using RPG.App.Menus;

namespace RPG.App;

public interface IDialog
{
    string GetMenuSelection(IMenu menu);

    string GetSelection(string prompt);
}