using RPG.Domain.Entities;

namespace RPG.App.Services;

public interface IGameEventService
{
    Task EmitGameEvent(GameLog log, CancellationToken cancellationToken);
}