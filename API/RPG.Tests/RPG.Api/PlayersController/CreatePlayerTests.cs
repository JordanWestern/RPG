using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using RPG.App.Contracts;
using RPG.Domain.Factories;
using System.Net;
using System.Net.Http.Json;

namespace RPG.Tests.RPG.Api.PlayerController;

public class CreatePlayerTests : ApiTestFixture
{
    private readonly TestGuidFactory guidProvider;

    public CreatePlayerTests()
    {
        guidProvider = new TestGuidFactory();
    }

    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection => serviceCollection.AddTransient<IGuidFactory>(_ => guidProvider);

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
        var expected = new ExistingPlayer(guidProvider.NewGuid, Name);

        // Act
        var result = await Client.PostAsJsonAsync(PlayersUri, newPlayer, TokenSource.Token);

        // Assert
        using var scope = new AssertionScope();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
        (await result.Content.ReadFromJsonAsync<ExistingPlayer>()).Should().BeEquivalentTo(expected);
    }
}
