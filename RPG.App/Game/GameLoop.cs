using RPG.App.States;

namespace RPG.App.Game;

public class GameLoop : IGameLoop
{
    private IState _state;

    public GameLoop(StartGame startGame)
    {
        _state = startGame;
    }

    public bool IsRunning => _state is not GameExit;

    public void Continue() => _state = _state.Handle();
}