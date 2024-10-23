using FluentAssertions;
using FluentAssertions.Execution;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RPG.App.Contracts;
using RPG.Domain.Events;
using RPG.Domain.ValueObjects;
using RPG.Infrastructure.DbContexts;
using RPG.Infrastructure.Repositories;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Map = RPG.Domain.ValueObjects.Map;

namespace RPG.Tests.RPG.Api.PlayerController;

public class CreatePlayerTests : ApiTestFixture
{
    private readonly Mock<INotificationHandler<GameLogCreatedEvent>> gameLogCreatedEventHandler = new();

    private readonly Mock<IMapFileSource> mockFileSource = new();

    private readonly Guid mapId = Guid.NewGuid();

    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection =>
        {
            mockFileSource.Setup(fileSource => fileSource.GetMap(mapId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Map(mapId, "map name", "map description", [ new Location(Guid.NewGuid(), "location name", "location description", [Guid.NewGuid()], true) ]));

            serviceCollection
                .UseInMemoryDatabase(nameof(CreatePlayerTests))
                .AddScoped(_ => gameLogCreatedEventHandler.Object)
                .AddScoped(_ => mockFileSource.Object);
        };

    [Fact]
    public async Task CreatePlayer_ReturnsBadRequest_IfNewPlayerIsNull()
    {
        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, (NewPlayer)null!, TokenSource.Token);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task CreatePlayer_ReturnsBadRequest_IfNewPlayerNameIsNullEmptyOrWhiteSpace(string name)
    {
        // Arrange
        var newPlayer = new NewPlayer(name, mapId);

        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreatePlayer_ReturnsBadRequest_IfNewPlayerMapIdIsEmpty()
    {
        // Arrange
        var newPlayer = new NewPlayer(nameof(CreatePlayer_ReturnsBadRequest_IfNewPlayerMapIdIsEmpty), Guid.Empty);

        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreatePlayer_ReturnsBadRequest_IfNewPlayerMapIdIsNull()
    {
        // Arrange
        var newPlayer = new { Name = nameof(CreatePlayer_ReturnsBadRequest_IfNewPlayerMapIdIsEmpty), MapId = (Guid?)null };

        var x = JsonSerializer.Serialize(newPlayer);

        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);
        var content = await result.Content.ReadAsStringAsync();

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreatePlayer_ReturnsCreated_IfNewPlayerIsValid()
    {
        // Arrange
        const string Name = nameof(CreatePlayer_ReturnsCreated_IfNewPlayerIsValid);
        var newPlayer = new NewPlayer(Name, mapId);

        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        var existingPlayer = await result.Content.ReadFromJsonAsync<ExistingPlayer>();

        using var scope = new AssertionScope();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
        existingPlayer!.Name.Should().Be(Name);
        existingPlayer.Id.Should().NotBeEmpty();
    }

    [Fact]
    public async Task CreatePlayer_SavesPlayerInDatabase()
    {
        // Arrange
        const string Name = nameof(CreatePlayer_SavesPlayerInDatabase);
        var newPlayer = new NewPlayer(Name, mapId);

        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Act
        _ = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        dbContext.Players.Should().Contain(player => player.Name == Name);

    }

    [Fact]
    public async Task CreatePlayer_SavesGameLogInDatabase()
    {
        // Arrange
        var newPlayer = new NewPlayer(nameof(CreatePlayer_SavesGameLogInDatabase), mapId);

        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        // Act
        _ = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        dbContext.GameLogs.Should().HaveCountGreaterThan(0);

    }

    [Fact]
    public async Task CreatePlayer_InvokesGameLogCreatedEventHandler()
    {
        // Arrange
        var newPlayer = new NewPlayer(nameof(CreatePlayer_InvokesGameLogCreatedEventHandler), mapId);

        // Act
        _ = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        gameLogCreatedEventHandler.Verify(handler => handler.Handle(It.IsAny<GameLogCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
