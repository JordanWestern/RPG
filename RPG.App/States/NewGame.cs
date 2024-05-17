using RPG.Domain.Entities;
using RPG.Domain.Events;

namespace RPG.App.States;

public class NewGame : IState
{
    private readonly IPlayerCreatedEventHandler _playerCreatedEventHandler;
    private readonly GameExit _gameExit;

    public NewGame(IPlayerCreatedEventHandler playerCreatedEventHandler, GameExit gameExit)
    {
        _playerCreatedEventHandler = playerCreatedEventHandler;
        _gameExit = gameExit;
    }
    
    public IState Handle()
    {
        var player = Player.Create("playerName");
        _playerCreatedEventHandler.OnPlayerCreated(player);
        return _gameExit;
    }
}