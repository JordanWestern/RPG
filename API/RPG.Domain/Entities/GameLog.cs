using RPG.Domain.Events;

namespace RPG.Domain.Entities;

public class GameLog : Entity
{
    private GameLog(Guid id, Guid playerId, DateOnly date, string logMessage) : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(logMessage, nameof(logMessage));

        PlayerId = playerId;
        Date = date;
        LogMessage = logMessage;
    }

    public Guid PlayerId { get; }

    public DateOnly Date { get; }

    public string LogMessage { get; }

    public static GameLog Create(Guid playerId, string message)
    {
        var gameLog = new GameLog(Guid.NewGuid(), playerId, DateOnly.FromDateTime(DateTime.UtcNow), message);
        gameLog.RaiseDomainEvent(new GameLogCreatedEvent(gameLog));
        return gameLog;
    }
}
