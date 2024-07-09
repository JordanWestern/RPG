using RPG.Domain.Entities;

namespace RPG.App;

public class GuidProvider : IGuidProvider
{
    public Guid NewGuid => Guid.NewGuid();
}
