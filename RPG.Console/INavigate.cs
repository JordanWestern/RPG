using Terminal.Gui;

namespace RPG.Console;

public interface INavigate
{
    void To<T>() where T : View;
}