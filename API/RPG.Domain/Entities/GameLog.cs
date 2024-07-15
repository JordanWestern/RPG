using RPG.Domain.Factories;

namespace RPG.Domain.Entities;

public class GameLog
{
    private GameLog(Guid id, Guid playerId, DateOnly date, string logMessage)
    {
        Id = id;
        PlayerId = playerId;
        Date = date;
        LogMessage = logMessage;
    }

    public Guid Id { get; }

    public Guid PlayerId { get; }

    public DateOnly Date { get; }

    public string LogMessage { get; }

    public class GameLogFactory(IGuidFactory guidFactory) : IGameLogFactory
    {
        public GameLog Create(Guid playerId, string message) => new(guidFactory.NewGuid, playerId, DateOnly.FromDateTime(DateTime.UtcNow), message);
    }
}
