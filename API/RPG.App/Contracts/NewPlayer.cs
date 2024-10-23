namespace RPG.App.Contracts;

public record NewPlayer(string Name, Guid MapId)
{
    // TODO: use meadiatr pipeline behaviour to validate and throw, use .NET exception handling middleware to catch and convert to problem details.
    // Validation here for now.
    public bool IsValid() => IsNameValid(Name) && IsMapIdValid(MapId);

    private static bool IsNameValid(string name) => !string.IsNullOrWhiteSpace(name);

    private static bool IsMapIdValid(Guid mapId) => mapId != Guid.Empty;
}