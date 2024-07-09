namespace RPG.Domain.Entities;

public interface IGuidProvider
{
    public Guid NewGuid { get; }
}