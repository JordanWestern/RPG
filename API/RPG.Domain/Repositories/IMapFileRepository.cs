using RPG.Domain.ValueObjects;

namespace RPG.Domain.Repositories;

public interface IMapFileRepository
{
    IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken);
}