using RPG.Domain.ValueObjects;

namespace RPG.Infrastructure.Repositories;

public interface IMapFileSource
{
    IAsyncEnumerable<Map> GetMaps(CancellationToken cancellationToken);
}
