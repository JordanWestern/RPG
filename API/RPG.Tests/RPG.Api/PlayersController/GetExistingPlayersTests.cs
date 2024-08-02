using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RPG.App.Contracts;
using RPG.Domain.Entities;
using RPG.Infrastructure.DbContexts;
using System.Net.Http.Json;

namespace RPG.Tests.RPG.Api.PlayersController;

public class GetExistingPlayersTests : ApiTestFixture
{
    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection => serviceCollection.Replace(
            new ServiceDescriptor(
                typeof(ApplicationDbContext),
                _ => new ApplicationDbContext(
                    new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(nameof(GetExistingPlayersTests)).Options),
                ServiceLifetime.Scoped));

    [Fact]
    public async Task GetExistingPlayers_ReturnsExistingPlayers()
    {
        // Arrange
        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var players = new List<Player>();

        for (int i = 0; i < 10; i++) 
        {
            players.Add(Player.Create($"player_{i}"));
        }

        dbContext.AddRange(players);
        dbContext.SaveChanges();
        var expected = players.Select(player => new ExistingPlayer(player.Id, player.Name));

        // Act
        var result = await Client.GetAsync(PlayersUri, TokenSource.Token);

        // Assert
        (await result.Content.ReadFromJsonAsync<ExistingPlayer[]>()).Should().BeEquivalentTo(expected);
    }
}
