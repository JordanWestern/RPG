using MediatR;
using RPG.App.Contracts;
using RPG.App.Queries;
using RPG.Domain.Repositories;

namespace RPG.App.RequestHandlers;

internal class GetPlayersQueryHandler(IPlayerRepository repository) : IStreamRequestHandler<GetPlayersQuery, ExistingPlayer>
{
    public IAsyncEnumerable<ExistingPlayer> Handle(GetPlayersQuery request, CancellationToken cancellationToken) => 
        repository.GetExistingPlayers(cancellationToken)
            .Select(entity => new ExistingPlayer(entity.Id, entity.Name));
}
