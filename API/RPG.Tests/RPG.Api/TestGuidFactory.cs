using RPG.Domain.Factories;

namespace RPG.Tests.RPG.Api;

internal class TestGuidFactory : IGuidFactory
{
    public Guid NewGuid => new("16812CA5-2FC2-486D-B2AE-EF283E1BE802");
}
