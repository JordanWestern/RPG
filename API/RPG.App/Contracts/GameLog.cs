namespace RPG.App.Contracts;

public record GameLog(Guid Id, DateOnly Date, string LogMessage);