namespace RPG.App.Views;

public interface IMenu
{
    public string Title { get; }
    
    public string[] MenuItems { get; }

    public string OnMenuItemSelected(string item);
}