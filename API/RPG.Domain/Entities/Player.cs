using RPG.Domain.Events;

namespace RPG.Domain.Entities;

public class Player : Entity
{
    private Player(Guid id, string name, Guid currentLocation) : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        if (currentLocation == Guid.Empty)
        {
            throw new ArgumentException("current location must not be empty", nameof(currentLocation));
        }

        Name = name;
        CurrentLocation = currentLocation;
    }

    public string Name { get; }

    public Guid CurrentLocation { get; }

    public static Player Create(string name, Guid currentLocation)
    {
        var player = new Player(Guid.NewGuid(), name, currentLocation);
        player.RaiseDomainEvent(new PlayerCreatedEvent(player));
        return player;
    }
}
