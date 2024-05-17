using RPG.App.Views;

namespace RPG.App.States;

public class StartGame : IState
{
    private readonly IGui _gui;
    private readonly IState _newGame;
    private readonly IState _gameExit;

    public StartGame(IGui gui, NewGame newGame, GameExit gameExit)
    {
        _gui = gui;
        _newGame = newGame;
        _gameExit = gameExit;
    }

    public IState Handle()
    {
        _gui.Initialize(new StartGameView());
        return _gameExit;
    }
}