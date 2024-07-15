using RPG.Domain.Events;
using RPG.Domain.Factories;

namespace RPG.Domain.Entities;

public class Player
{

    private Player(Guid id, string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }

    public List<IDomainEvent> DomainEvents { get; } = [];

    public void RaiseDomainEvent(IDomainEvent domainEvent) => DomainEvents.Add(domainEvent);

    public class PlayerFactory(IGuidFactory guidProvider) : IPlayerFactory
    {
        public Player Create(string name)
        {
            var player = new Player(guidProvider.NewGuid, name);
            player.RaiseDomainEvent(new PlayerCreatedEvent(player));
            return player;
        }
    }
}
