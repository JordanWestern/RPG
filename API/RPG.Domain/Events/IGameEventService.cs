namespace RPG.Domain.Events;

public interface IGameEventService
{
    Task EmitGameEvent(string message, CancellationToken cancellationToken);
}