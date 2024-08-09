using FluentAssertions;
using RPG.Domain.Entities;

namespace RPG.Tests.RPG.Domain;

public class GameLogTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void GameLog_Throws_IfMessageIsNullEmptyOrWhiteSpace(string? message)
    {
        // Act
        var act = () => GameLog.Create(Guid.NewGuid(), message!);

        // Assert
        act.Should().Throw<ArgumentException>();
    }
}
