namespace RPG.App.Contracts;

public record Location(Guid Id, string Name, string Description, IReadOnlyList<Guid> Connections, bool IsStart);