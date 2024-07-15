using RPG.Domain.Entities;

namespace RPG.Domain.Events;

public interface IGameEventService
{
    Task EmitGameEvent(GameLog log, CancellationToken cancellationToken);
}