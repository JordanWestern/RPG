using RPG.Domain.Events;

namespace RPG.Domain.Entities;

public class Player : Entity
{
    private Player(Guid id, string name) : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }

    public string Name { get; }

    public static Player Create(string name)
    {
        var player = new Player(Guid.NewGuid(), name);
        player.RaiseDomainEvent(new PlayerCreatedEvent(player));
        return player;
    }
}
