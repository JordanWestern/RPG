using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPG.App.Contracts;
using RPG.Infrastructure.DbContexts;
using System.Net;
using System.Net.Http.Json;

namespace RPG.Tests.RPG.Api.PlayerController;

public class CreatePlayerTests : ApiTestFixture
{
    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection => serviceCollection.AddDbContext<PlayerDbContext>(builder => builder.UseInMemoryDatabase(nameof(CreatePlayerTests)));

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
        const string Name = "Grognak the barbarian";
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
}
