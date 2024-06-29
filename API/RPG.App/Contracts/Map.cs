namespace RPG.App.Contracts;

public record Map(string Name, IReadOnlyList<Location> Locations);