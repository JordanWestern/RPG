using RPG.App.States;

namespace RPG.App.Game;

public class GameLoop : IGameLoop
{
    private IState _state;

    public GameLoop(GameStart gameStart)
    {
        _state = gameStart;
    }

    public bool IsRunning => _state is not GameExit;

    public void Continue() => _state = _state.Handle();
}