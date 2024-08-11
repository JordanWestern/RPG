using MediatR;
using RPG.App.Contracts;
using RPG.App.Queries;
using RPG.Domain.Repositories;

namespace RPG.App.RequestHandlers;

internal class GetMapsQueryHandler(IMapFileRepository repository) : IStreamRequestHandler<GetMapsQuery, Map>
{
    public IAsyncEnumerable<Map> Handle(GetMapsQuery request, CancellationToken cancellationToken) =>
        repository.GetMaps(cancellationToken).Select(map => new Map(map.Id, map.Name, map.Description));
}
