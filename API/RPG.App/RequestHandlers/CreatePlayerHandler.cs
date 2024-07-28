using MediatR;
using RPG.App.Contracts;
using RPG.App.Requests;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.App.RequestHandlers
{
    internal class CreatePlayerHandler(IPlayerRepository repository) : IRequestHandler<CreatePlayerRequest, CreatePlayerResponse>
    {
        public async Task<CreatePlayerResponse> Handle(CreatePlayerRequest request, CancellationToken cancellationToken)
        {
            var entity = Player.Create(request.NewPlayer.Name);
            await repository.SaveNewPlayer(entity, cancellationToken);
            return new CreatePlayerResponse(entity.Id, entity.Name);
        }
    }
}
