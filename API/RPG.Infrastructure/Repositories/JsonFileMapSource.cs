using RPG.Domain.ValueObjects;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace RPG.Infrastructure.Repositories;

// TODO: Tests.
public class JsonFileMapSource : IMapFileSource
{
    private readonly JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

    public async IAsyncEnumerable<Map> GetMaps([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var mapFileResources = assembly.GetManifestResourceNames();

        foreach (var mapFile in mapFileResources) 
        {
            using var stream = assembly.GetManifestResourceStream(mapFile);

            if (stream == null) 
            {
                continue;
            }

            var map = await JsonSerializer.DeserializeAsync<Map>(stream, options, cancellationToken);

            if (map == null)
            {
                continue;
            }

            yield return map;
        }
    }
}
