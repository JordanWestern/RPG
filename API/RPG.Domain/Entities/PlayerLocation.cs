﻿namespace RPG.Domain.Entities;

public class PlayerLocation : Entity
{
    private PlayerLocation(Guid id, Guid playerId, string name, string description, IEnumerable<Guid> connections, bool start) : base(id)
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

    public IEnumerable<Guid> Connections { get; }

    public bool Start { get; }

    public static PlayerLocation Create(Guid playerId, string name, string description, IEnumerable<Guid> connections, bool start) =>
        new(Guid.NewGuid(), playerId, name, description, connections, start);
}
