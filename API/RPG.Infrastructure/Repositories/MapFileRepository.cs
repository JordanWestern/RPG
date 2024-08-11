using RPG.Domain.Repositories;
using RPG.Domain.ValueObjects;

namespace RPG.Infrastructure.Repositories;

public class MapFileRepository(IMapFileSource mapSource) : IMapFileRepository
{
    public IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken) => mapSource.GetMaps(cancellationToken);
}
