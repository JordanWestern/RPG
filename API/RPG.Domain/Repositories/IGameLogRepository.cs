using RPG.Domain.Entities;
using RPG.Domain.ValueObjects;

namespace RPG.Domain.Repositories;

public interface IGameLogRepository
{
    public Task CreateLog(GameLog gameLog, CancellationToken cancellationToken);

    public GameLogs GetLogs(Guid playerId, CancellationToken cancellationToken);
}
