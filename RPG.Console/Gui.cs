using RPG.App;
using RPG.App.Views;
using RPG.Console.Views;
using Terminal.Gui;

namespace RPG.Console;

public class Gui : IGui
{
    public void Initialize<TMenuView>(TMenuView view) where TMenuView : IView, IMenu
    {
        Application.Init();

        var win = new Window("ListView Example")
        {
            X = 0,
            Y = 1, // Leave space for the top-level menu
            Width = Dim.Fill(),
            Height = Dim.Fill()
        };

        win.Add(new MenuView<TMenuView>(view));

        Application.Top.Add(win);
        Application.Run();
    }
}