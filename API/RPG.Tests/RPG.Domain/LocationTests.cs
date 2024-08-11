using FluentAssertions;
using RPG.Domain.Entities;

namespace RPG.Tests.RPG.Domain;

public class LocationTests
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Location_Throws_IfNameIsNullEmptyOrWhiteSpace(string? name)
    {
        // Act
        var act = () => PlayerLocation.Create(Guid.NewGuid(), name!, "description", [Guid.NewGuid()], false);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Location_Throws_IfDescriptionIsNullEmptyOrWhiteSpace(string? description)
    {
        // Act
        var act = () => PlayerLocation.Create(Guid.NewGuid(), "name", description!, [Guid.NewGuid()], false);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Location_Throws_IfNoConnectionsProvided()
    {
        // Act
        var act = () => PlayerLocation.Create(Guid.NewGuid(), "name", "description", [], false);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Location_Create_ShouldReturnValidLocation()
    {
        // Arrange
        var playerId = Guid.NewGuid();
        var name = "name";
        var description = "description";
        var connections = new Guid[] { Guid.NewGuid() };
        var isStartLocation = true;

        // Act
        var location = PlayerLocation.Create(playerId, name, description, connections, isStartLocation);

        // Assert
        location.PlayerId.Should().Be(playerId);
        location.Name.Should().Be(name);
        location.Description.Should().Be(description);
        location.Connections.Should().NotBeEmpty();
        location.Start.Should().Be(isStartLocation);
    }
}
