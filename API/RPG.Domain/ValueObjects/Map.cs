namespace RPG.Domain.ValueObjects;

public record Map
{
    public Map(Guid id, string name, string description, IEnumerable<Location> locations)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        if (locations is null || !locations.Any())
        {
            throw new ArgumentException("map must have at least one location");
        }

        Id = id;
        Name = name;
        Description = description;
        Locations = locations;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public IEnumerable<Location> Locations { get; }
}
