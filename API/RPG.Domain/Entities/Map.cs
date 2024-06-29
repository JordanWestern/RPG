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

    public static Map Create(string name, List<Location> locations) => new(name, locations);
}