using RPG.Domain.Entities;
using RPG.Domain.Events;

namespace RPG.App.States;

public class GameStart : IState
{
    private readonly ICommandHandler _commandHandler;
    private readonly IPlayerCreatedEventHandler _playerCreatedEventHandler;

    public GameStart(ICommandHandler commandHandler, IPlayerCreatedEventHandler playerCreatedEventHandler)
    {
        _commandHandler = commandHandler;
        _playerCreatedEventHandler = playerCreatedEventHandler;
    }
    
    public IState Handle()
    {
        var name = _commandHandler.GetPlayerName();

        var player = Player.Create(name);

        _playerCreatedEventHandler.OnPlayerCreated(player);
        
        return new GameExit();
    }
}