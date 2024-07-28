using MediatR;
using RPG.App.Contracts;
using RPG.App.Queries;
using RPG.Domain.Repositories;

namespace RPG.App.RequestHandlers;

internal class GetGameLogsQueryHandler(IGameLogRepository repository) : IStreamRequestHandler<GetGameLogsQuery, GameLog>
{
    public IAsyncEnumerable<GameLog> Handle(GetGameLogsQuery request, CancellationToken cancellationToken) =>
        repository.GetLogs(request.PlayerId, cancellationToken).Value
        .Select(entity => new GameLog(entity.Id, entity.Date, entity.LogMessage));
}
