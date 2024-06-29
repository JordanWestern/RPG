namespace RPG.App.Contracts;

public record NewPlayer(string Name)
{
    public bool IsValid() => !string.IsNullOrWhiteSpace(Name);
}