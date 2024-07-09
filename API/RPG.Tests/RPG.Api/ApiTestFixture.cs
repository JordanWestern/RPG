using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace RPG.Tests.RPG.Api;

public abstract class ApiTestFixture
{
    protected ApiTestFixture()
    {
        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(serviceCollection => ConfigureServices(serviceCollection));
            });

        Client = factory.CreateClient();
    }

    protected HttpClient Client { get; }

    protected virtual Action<IServiceCollection> ConfigureServices => serviceCollection => {  };
}
