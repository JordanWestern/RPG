namespace RPG.Domain.Entities;

internal class Location : Entity
{
    private Location(Guid id, Guid playerId, string name, string description, IEnumerable<Location> connections, bool start) : base(id)
    {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentNullException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        if (!connections.Any()) 
        {
            throw new ArgumentException("location must have at least one connection");
        }

        PlayerId = playerId;
        Name = name;
        Description = description;
        Connections = connections;
        Start = start;
    }

    public Guid PlayerId { get; }

    public string Name { get; }

    public string Description { get; }

    public IEnumerable<Location> Connections { get; }

    public bool Start { get; }

    public static Location Create(Guid playerId, string name, string description, IEnumerable<Location> connections, bool start)
    {
        return new Location(Guid.NewGuid(), playerId, name, description, connections, start);
    }
}
