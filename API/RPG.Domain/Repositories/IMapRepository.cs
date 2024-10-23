using RPG.Domain.Entities;
using RPG.Domain.ValueObjects;

namespace RPG.Domain.Repositories;

public interface IMapRepository
{
    IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken);

    Task<Map> GetMap(Guid mapId, CancellationToken cancellationToken);

    Task SavePlayerLocations(IEnumerable<PlayerLocation> locations, CancellationToken cancellationToken);
}