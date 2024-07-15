using RPG.Domain.Entities;

namespace RPG.Domain.ValueObjects;

public class GameLogs(IAsyncEnumerable<GameLog> gameLogs)
{
    private readonly IAsyncEnumerable<GameLog> gameLogs = gameLogs;

    public IAsyncEnumerable<GameLog> InChronologicalOrder => gameLogs.OrderBy(log => log.Date);
}
