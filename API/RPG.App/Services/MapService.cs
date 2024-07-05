using RPG.App.Contracts;
using RPG.Domain.Repositories;

namespace RPG.App.Services;

internal class MapService : IMapService
{
    private readonly IMapRepository _repository;

    public MapService(IMapRepository repository)
    {
        _repository = repository;
    }
        
    public Map GetMap()
    {
        var entity = _repository.GetMap();
            
        return new Map(entity.Name,
            entity.Locations.Select(location => new Location(location.Id, location.Name, location.Description,
                location.Connections, location.IsPlayerHere)).ToList());
    }
}