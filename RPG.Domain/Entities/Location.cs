namespace RPG.Domain.Entities;

public class Location
{
    private Location(Guid id, string name, string description, IReadOnlyList<Guid> connections, bool isStart)
    {
        Id = id;
        Name = name;
        Description = description;
        Connections = connections;
        IsStart = isStart;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public IReadOnlyList<Guid> Connections { get; }
    
    public bool IsStart { get; }

    public static Location Create(string name, string description, List<Guid> connections, bool isStart) => new(Guid.NewGuid(), name, description, connections, isStart);
}