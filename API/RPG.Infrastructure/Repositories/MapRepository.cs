using System.Text.Json;
using RPG.Domain.Entities;
using RPG.Domain.Repositories;

namespace RPG.Infrastructure.Repositories;

internal class MapRepository : IMapRepository
{
    public Map GetMap()
    {
        var file = File.ReadAllText("TestMap.json");

        ArgumentException.ThrowIfNullOrEmpty(file, nameof(file));

        var map = JsonSerializer.Deserialize<Map>(file);

        if (map is null)
        {
            throw new InvalidOperationException("Map could not be deserialized.");
        }

        return map;
    }
}