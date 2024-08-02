using RPG.Domain.Events;

namespace RPG.Domain.Entities;

public class GameLog : Entity
{
    private GameLog(Guid id, Guid playerId, DateOnly date, string logMessage) : base(id)
    {
        // TODO: primitive obsession leads to all these guards, wrap these values in objects that can handle the null checks themselves.
        if (playerId == Guid.Empty) 
        { 
            throw new ArgumentNullException(nameof(playerId), $"{nameof(playerId)} must not be an empty Guid"); 
        }

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
