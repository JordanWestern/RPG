using RPG.Domain.ValueObjects;

namespace RPG.Domain.Repositories;

public interface IMapRepository
{
    IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken);
}