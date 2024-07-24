using RPG.App.Contracts;

namespace RPG.App.Services;

public interface IGameLogService
{
    public IAsyncEnumerable<GameLog> GetGameLogs(Guid playerId, CancellationToken cancellationToken);
}
