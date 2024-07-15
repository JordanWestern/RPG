using RPG.Domain.Repositories;
using RPG.Domain.ValueObjects;

namespace RPG.App.Services;

public class GameLogService(IGameLogRepository gameLogRepository) : IGameLogService
{
    public GameLogs GetGameLogs(Guid playerId, CancellationToken cancellationToken) => gameLogRepository.GetLogs(playerId, cancellationToken);
}
