using RPG.App.Views;
using Terminal.Gui;

namespace RPG.Console.Views;

internal class MenuView<TMenuView> : View where TMenuView : IView, IMenu
{
    public MenuView(TMenuView view)
    {
        Initialize(view);
    }

    private void Initialize(TMenuView view)
    {
        var viewTitle = ViewTitle(view);
        var menu = MenuBar(view);

        Add(viewTitle, menu);
    }

    private static MenuBar MenuBar(IMenu menu) =>
        new(new MenuBarItem[]
        {
            new(menu.Title, CreateMenuItems(menu))
        });

    private static Label ViewTitle(IView view) =>
        new(view.Title);

    private static MenuItem[] CreateMenuItems(IMenu menu)
    {
        var menuItems = new MenuItem[menu.MenuItems.Length];
            
        for (var i = 0; i < menu.MenuItems.Length; i++)
        {
            var item = menu.MenuItems[i];
            menuItems[i] = new MenuItem(item, "", () => menu.OnMenuItemSelected(item));
        }
            
        return menuItems;
    }
}