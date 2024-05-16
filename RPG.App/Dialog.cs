using RPG.App.Menus;

namespace RPG.App;

public class Dialog : IDialog
{
    private readonly Func<IMenu, string> _getMenuSelection;
    private readonly Func<string, string> _getPrompt;

    public Dialog(Func<IMenu, string> getMenuSelection, Func<string, string> getPrompt)
    {
        _getMenuSelection = getMenuSelection;
        _getPrompt = getPrompt;
    }

    public string GetMenuSelection(IMenu menu) => _getMenuSelection(menu);

    public string GetSelection(string prompt) => _getPrompt(prompt);
}