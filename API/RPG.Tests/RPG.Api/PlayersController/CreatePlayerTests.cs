using FluentAssertions;
using FluentAssertions.Execution;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using RPG.App.Contracts;
using RPG.Domain.Events;
using RPG.Infrastructure.DbContexts;
using System.Net;
using System.Net.Http.Json;

namespace RPG.Tests.RPG.Api.PlayerController;

public class CreatePlayerTests : ApiTestFixture
{
    private readonly Mock<INotificationHandler<GameLogCreatedEvent>> gameLogCreatedEventHandler = new();

    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection =>
        {
            serviceCollection
                .UseInMemoryDatabase(nameof(CreatePlayerTests))
                .AddScoped(_ => gameLogCreatedEventHandler.Object);
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
        var newPlayer = new NewPlayer(nameof(CreatePlayer_InvokesGameLogCreatedEventHandler));

        // Act
        _ = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        gameLogCreatedEventHandler.Verify(handler => handler.Handle(It.IsAny<GameLogCreatedEvent>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
