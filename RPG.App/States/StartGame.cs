namespace RPG.App.States;

public class StartGame : IState
{
    private readonly IState _newGame;
    private readonly IState _gameExit;

    public StartGame(NewGame newGame, GameExit gameExit)
    {
        _newGame = newGame;
        _gameExit = gameExit;
    }

    public IState Handle()
    {
        return _gameExit;
    }
}