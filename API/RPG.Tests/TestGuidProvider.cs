using RPG.Domain.Entities;

namespace RPG.Tests;

internal class TestGuidProvider : IGuidProvider
{
    public Guid NewGuid => new("16812CA5-2FC2-486D-B2AE-EF283E1BE802");
}
