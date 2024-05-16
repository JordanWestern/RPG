using RPG.App.Menus;
using RPG.Domain.Entities;
using RPG.Domain.Events;

namespace RPG.App.States;

public class NewGame : IState
{
    private readonly IDialog _dialog;
    private readonly PlayerClassMenu _playerClassMenu;
    private readonly IPlayerCreatedEventHandler _playerCreatedEventHandler;
    private readonly GameExit _gameExit;

    public NewGame(IDialog dialog, PlayerClassMenu playerClassMenu, IPlayerCreatedEventHandler playerCreatedEventHandler, GameExit gameExit)
    {
        _dialog = dialog;
        _playerClassMenu = playerClassMenu;
        _playerCreatedEventHandler = playerCreatedEventHandler;
        _gameExit = gameExit;
    }
    
    public IState Handle()
    {
        var playerName = _dialog.GetSelection("What is your heroe's name?:");
        var playerClass = _dialog.GetMenuSelection(_playerClassMenu);
        var player = Player.Create(playerName);
        _playerCreatedEventHandler.OnPlayerCreated(player);
        return _gameExit;
    }
}