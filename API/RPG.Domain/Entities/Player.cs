namespace RPG.Domain.Entities;

public class Player
{
    private Player(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }

    public static Player Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        return new Player(Guid.NewGuid(), name);
    }
}