using RPG.Domain.Entities;

namespace RPG.Domain.ValueObjects;

public record GameLogs
{
    public GameLogs(IAsyncEnumerable<GameLog> Logs)
    {
        Value = Logs.OrderBy(log => log.Date);
    }

    public IOrderedAsyncEnumerable<GameLog> Value { get; }
}
