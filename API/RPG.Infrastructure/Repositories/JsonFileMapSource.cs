using RPG.Domain.ValueObjects;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace RPG.Infrastructure.Repositories;

public class JsonFileMapSource : IMapFileSource
{
    private readonly JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

    public async IAsyncEnumerable<Map> GetMaps([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var mapFilePaths = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Maps"));

        foreach (var filePath in mapFilePaths)
        {
            var file = await File.ReadAllTextAsync(filePath, cancellationToken);
            var map = JsonSerializer.Deserialize<Map>(file, options);
            if (map != null)
            {
                yield return map;
            }
        }
    }
}
