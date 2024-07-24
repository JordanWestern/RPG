using FluentAssertions;
using RPG.Domain.Entities;

namespace RPG.Tests.RPG.Domain;

public class PlayerTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Player_Throws_IfNameIsNullEmptyOrWhiteSpace(string? name)
    {
        // Act
        var act = () => Player.Create(name!);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
