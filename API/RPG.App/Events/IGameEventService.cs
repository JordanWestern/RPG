namespace RPG.App.Events;

public interface IGameEventService
{
    Task EmitGameEvent(string message, CancellationToken cancellationToken);
}