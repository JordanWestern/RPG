using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.DependencyInjection;
using RPG.App.Contracts;
using RPG.Domain.Entities;
using System.Net;
using System.Net.Http.Json;

namespace RPG.Tests.RPG.Api;

public class PlayerControllerTests : ApiTestFixture
{
    private readonly CancellationTokenSource tokenSource = new();

    private readonly TestGuidProvider guidProvider;

    public PlayerControllerTests()
    {
        guidProvider = new TestGuidProvider();
    }

    protected override Action<IServiceCollection> ConfigureServices => 
        serviceCollection => serviceCollection.AddTransient<IGuidProvider>(_ => guidProvider);

    [Fact]
    public async Task PostAsync_ReturnsBadRequest_IfNewPlayerIsNull()
    {
        // Arrange
        NewPlayer? newPlayer = null;

        // Act
        var result = await Client.PostAsJsonAsync("api/player", newPlayer, tokenSource.Token);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public async Task PostAsync_ReturnsBadRequest_IfNewPlayerNameIsNullEmptyOrWhiteSpace(string name)
    {
        // Arrange
        var newPlayer = new NewPlayer(name);

        // Act
        var result = await Client.PostAsJsonAsync("api/player", newPlayer, tokenSource.Token);

        // Assert
        result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task PostAsync_ReturnsCreated_IfNewPlayerIsValid()
    {
        // Arrange
        var newPlayer = new NewPlayer("Groknak the barbarian");
        var expected = new ExistingPlayer(guidProvider.NewGuid, "Groknak the barbarian");

        // Act
        var result = await Client.PostAsJsonAsync("api/player", newPlayer, tokenSource.Token);

        // Assert
        using var scope = new AssertionScope();
        result.StatusCode.Should().Be(HttpStatusCode.Created);
        (await result.Content.ReadFromJsonAsync<ExistingPlayer>()).Should().BeEquivalentTo(expected);
    }
}
