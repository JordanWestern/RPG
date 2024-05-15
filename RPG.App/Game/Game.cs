namespace RPG.App.Game;

public class Game : IGame
{
    private readonly IGameLoop _gameLoop;

    public Game(IGameLoop gameLoop)
    {
        _gameLoop = gameLoop;
    }

    public void Start()
    {
        while (_gameLoop.IsRunning)
        {
            _gameLoop.Continue();
        }
    }
}