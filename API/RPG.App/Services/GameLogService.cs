using RPG.App.Contracts;
using RPG.Domain.Repositories;

namespace RPG.App.Services;

public class GameLogService(IGameLogRepository gameLogRepository) : IGameLogService
{
    public IAsyncEnumerable<GameLog> GetGameLogs(Guid playerId, CancellationToken cancellationToken) =>
        gameLogRepository.GetLogs(playerId, cancellationToken).Value
            .Select(entity => new GameLog(entity.Id, entity.Date, entity.LogMessage));
}
