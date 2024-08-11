﻿namespace RPG.Domain.ValueObjects;

public record Location
{
    public Location(Guid id, string name, string description, IEnumerable<Guid> connections, bool start)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));
        ArgumentException.ThrowIfNullOrWhiteSpace(description, nameof(description));

        if (connections is null || !connections.Any())
        {
            throw new ArgumentException("location must have at least one connection");
        }

        Id = id;
        Name = name;
        Description = description;
        Connections = connections;
        Start = start;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public IEnumerable<Guid> Connections { get; }

    public bool Start { get; }
}