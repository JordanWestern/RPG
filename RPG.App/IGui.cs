using RPG.App.Views;

namespace RPG.App;

public interface IGui
{
    public void Initialize<TMenuView>(TMenuView view) where TMenuView : IView, IMenu;
}