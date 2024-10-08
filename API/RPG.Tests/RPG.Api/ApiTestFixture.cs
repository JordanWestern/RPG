﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using RPG.Tests.RPG.Api.GameLogsController;
using System.Runtime.CompilerServices;

namespace RPG.Tests.RPG.Api;

public class ApiTestFixture
{
    protected const string InformationUri = "api/info";
    protected const string PlayersUri = "api/players";
    protected const string GameLogsUri = "api/gameLogs";

    private readonly CancellationTokenSource tokenSource = new();

    public ApiTestFixture()
    {
        var factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(serviceCollection => ConfigureServices(serviceCollection));
            });

        Client = factory.CreateClient();
        ServiceProvider = factory.Services;
    }

    protected CancellationTokenSource TokenSource => tokenSource;

    protected HttpClient Client { get; }

    protected IServiceProvider ServiceProvider { get; }

    protected virtual Action<IServiceCollection> ConfigureServices => serviceCollection => { };
}
