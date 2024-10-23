using RPG.Domain.Entities;
using RPG.Domain.Repositories;
using RPG.Domain.ValueObjects;
using RPG.Infrastructure.DbContexts;

namespace RPG.Infrastructure.Repositories;

public class MapFileRepository(IMapFileSource mapSource, ApplicationDbContext context) : IMapRepository
{
    public Task<Map> GetMap(Guid mapId, CancellationToken cancellationToken) => mapSource.GetMap(mapId, cancellationToken);

    public IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken) => mapSource.GetMaps(cancellationToken);

    public async Task SavePlayerLocations(IEnumerable<PlayerLocation> locations, CancellationToken cancellationToken)
    {
        context.PlayerLocations.AddRange(locations);
        await context.SaveChangesAsync(cancellationToken);
    }
}
