using RPG.App.Menus;

namespace RPG.App.States;

public class GameStart : IState
{
    private readonly IDialog _dialog;
    private readonly IMenu _startMenu;
    private readonly IState _newGame;
    private readonly IState _gameExit;

    public GameStart(StartMenu startMenu, IDialog dialog, NewGame newGame, GameExit gameExit)
    {
        _dialog = dialog;
        _newGame = newGame;
        _gameExit = gameExit;
        _startMenu = startMenu;
    }

    public IState Handle() => _dialog.GetMenuSelection(_startMenu) == StartMenu.Exit ? _gameExit : _newGame;
}