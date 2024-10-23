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

        if (locations.Count(location => location.IsStartingLocation) != 1)
        {
            throw new ArgumentException("map must have one start location");
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

    public Location StartingLocation => Locations.Single(location => location.IsStartingLocation);
}
