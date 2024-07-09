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

    public class PlayerFactory(IGuidFactory guidProvider) : IPlayerFactory
    {
        public Player Create(string name) => new(guidProvider.NewGuid, name);
    }
}
