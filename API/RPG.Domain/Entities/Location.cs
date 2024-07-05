namespace RPG.Domain.Entities;

public class Location
{
    private Location(Guid id, string name, string description, IReadOnlyList<Guid> connections, bool isStart)
    {
        Id = id;
        Name = name;
        Description = description;
        Connections = connections;
        IsPlayerHere = isStart;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public IReadOnlyList<Guid> Connections { get; }
    
    public bool IsPlayerHere { get; }

    public static Location Create(string name, string description, List<Guid> connections, bool isStart)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        if (connections is null || connections.Count == 0)
        {
            throw new ArgumentException("Location connections must not be null or empty", nameof(connections));
        }

        return new(Guid.NewGuid(), name, description, connections, isStart);
    }
}