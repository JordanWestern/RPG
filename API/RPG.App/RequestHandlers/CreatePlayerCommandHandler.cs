using MediatR;
using RPG.App.Contracts;
using RPG.App.Requests;
using RPG.Domain.Repositories;

namespace RPG.App.RequestHandlers
{
    internal class CreatePlayerCommandHandler(IPlayerRepository repository) : IRequestHandler<CreatePlayerCommand, ExistingPlayer>
    {
        public async Task<ExistingPlayer> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.Entities.Player.Create(request.NewPlayer.Name);
            await repository.SaveNewPlayer(entity, cancellationToken);
            return new ExistingPlayer(entity.Id, entity.Name);
        }
    }
}
