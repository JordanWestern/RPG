namespace RPG.App.Game;

public interface IGameLoop
{
    bool IsRunning { get; }
    
    void Continue();
}