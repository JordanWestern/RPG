using MediatR;
using RPG.App.Commands;
using RPG.App.Contracts;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.App.RequestHandlers;

internal class CreatePlayerCommandHandler(IPlayerRepository playerRepository, IMapRepository mapRepository) : IRequestHandler<CreatePlayerCommand, ExistingPlayer>
{
    public async Task<ExistingPlayer> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var map = await mapRepository.GetMap(request.NewPlayer.MapId, cancellationToken);
        var playerEntity = Player.Create(request.NewPlayer.Name, map.StartingLocation.Id);

        // TODO: It might be an idea to regenrate the location ids for the entities to avoid needing to refer the player id and map id.
        var locations = map.Locations.Select(location => PlayerLocation.Create(location.Id, map.Id, playerEntity.Id, location.Name, location.Description, location.Connections, location.IsStartingLocation));

        await playerRepository.SaveNewPlayer(playerEntity, cancellationToken);
        await mapRepository.SavePlayerLocations(locations, cancellationToken);

        return new ExistingPlayer(playerEntity.Id, playerEntity.Name, playerEntity.CurrentLocation);
    }
}
