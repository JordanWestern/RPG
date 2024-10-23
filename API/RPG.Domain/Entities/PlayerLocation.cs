using RPG.Domain.ValueObjects;

namespace RPG.Domain.Entities;

public class PlayerLocation : Entity
{
    private PlayerLocation(Guid id, Guid mapId, Guid playerId, string name, string description, IEnumerable<Guid> connections, bool isStartLocation) : base(id)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        if (!connections.Any()) 
        {
            throw new ArgumentException("location must have at least one connection");
        }

        MapId = mapId;
        PlayerId = playerId;
        Name = name;
        Description = description;
        Connections = connections;
        IsStartLocation = isStartLocation;
    }

    public Guid MapId { get; }

    public Guid PlayerId { get; }

    public string Name { get; }

    public string Description { get; }

    public IEnumerable<Guid> Connections { get; }

    public bool IsStartLocation { get; }

    public static PlayerLocation Create(Guid locationId, Guid mapId, Guid playerId, string name, string description, IEnumerable<Guid> connections, bool isStartLocation) =>
        new(locationId, mapId, playerId, name, description, connections, isStartLocation);
}
