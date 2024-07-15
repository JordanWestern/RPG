using RPG.Domain.ValueObjects;

namespace RPG.App.Services;

public interface IGameLogService
{
    public GameLogs GetGameLogs(Guid playerId, CancellationToken cancellationToken);
}
