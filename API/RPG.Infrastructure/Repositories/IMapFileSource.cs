using RPG.Domain.ValueObjects;

namespace RPG.Infrastructure.Repositories;

public interface IMapFileSource
{
    Task<Map> GetMap(Guid mapId, CancellationToken cancellationToken);

    IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken);
}
