namespace RPG.Domain.Entities;

public class Map
{
    private Map(string name, IReadOnlyList<Location> locations)
    {
        this.Name = name;
        this.Locations = locations;
    }

    public string Name { get; }

    public IReadOnlyList<Location> Locations { get; }

    public static Map Create(string name, List<Location> locations) 
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        if (locations is null || locations.Count == 0)
        {
            throw new ArgumentException("Map locations must not be null or empty", nameof(locations));
        }

        return new Map(name, locations);
    }
}