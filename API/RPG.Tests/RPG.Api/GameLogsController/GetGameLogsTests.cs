using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RPG.Domain.Entities;
using RPG.Infrastructure.DbContexts;
using System.Net.Http.Json;

namespace RPG.Tests.RPG.Api.GameLogsController;

public class GetGameLogsTests : ApiTestFixture
{
    protected override Action<IServiceCollection> ConfigureServices =>
        serviceCollection => serviceCollection.UseInMemoryDatabase(nameof(GetGameLogsTests));

    [Fact]
    public async Task GetGameLogs_ReturnsGameLogsAscendingByDate()
    {
        // Arrange
        using var scope = ServiceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var logs = new List<GameLog>();

        var playerId = Guid.NewGuid();

        for (int i = 0; i < 10; i++)
        {
            logs.Add(GameLog.Create(playerId, $"{i}"));
        }

        await dbContext.AddRangeAsync(logs, TokenSource.Token);
        await dbContext.SaveChangesAsync(TokenSource.Token);

        var expected = await logs.Select(log => new App.Contracts.GameLog(log.Id, log.Date, log.LogMessage))
            .ToAsyncEnumerable()
            .ToListAsync();

        // Act
        var response = await Client.GetAsync(GetGameLogsUri(playerId), TokenSource.Token);

        // Assert
        var gameLogs = await response.Content.ReadFromJsonAsAsyncEnumerable<App.Contracts.GameLog>(cancellationToken: TokenSource.Token)
            .ToListAsync(TokenSource.Token);

        gameLogs!.Should().BeEquivalentTo(expected).And.BeInAscendingOrder(log => log!.Date);
    }

    private static string GetGameLogsUri(Guid playerId) => $"{GameLogsUri}/{playerId}";
}
