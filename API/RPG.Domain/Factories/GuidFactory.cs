using RPG.Domain.Factories;

namespace RPG.App;

public class GuidFactory : IGuidFactory
{
    public Guid NewGuid => Guid.NewGuid();
}
