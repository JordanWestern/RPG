using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RPG.App.Contracts;
using RPG.App.Services;
using RPG.Domain.Repositories;
using RPG.Infrastructure.DbContexts;
using System.Net;
using System.Net.Http.Json;

using GameLog = RPG.Domain.Entities.GameLog;

namespace RPG.Tests.RPG.Api.PlayerController;

public class CreatePlayerTests : ApiTestFixture
{
    private readonly Mock<IGameLogRepository> gameLogRepositoryMock = new();
    private readonly Mock<IGameEventService> gameEventServiceMock = new();

    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection =>
        {
            serviceCollection
                .UseInMemoryDatabase(nameof(CreatePlayerTests))
                .AddScoped(_ => gameLogRepositoryMock.Object)
                .AddScoped(_ => gameEventServiceMock.Object);
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
        var newPlayer = new NewPlayer(name);

        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task CreatePlayer_ReturnsCreated_IfNewPlayerIsValid()
    {
        // Arrange
        const string Name = nameof(CreatePlayer_ReturnsCreated_IfNewPlayerIsValid);
        var newPlayer = new NewPlayer(Name);

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
        var newPlayer = new NewPlayer(Name);

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
        var newPlayer = new NewPlayer(nameof(CreatePlayer_SavesGameLogInDatabase));

        // Act
        _ = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        gameLogRepositoryMock.Verify(repo => repo.CreateLog(It.IsAny<GameLog>(), It.IsAny<CancellationToken>()), Times.Once);

    }

    [Fact]
    public async Task CreatePlayer_EmitsGameEvent()
    {
        // Arrange
        var newPlayer = new NewPlayer(nameof(CreatePlayer_EmitsGameEvent));

        // Act
        _ = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        gameEventServiceMock.Verify(service => service.EmitGameEvent(It.IsAny<GameLog>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
