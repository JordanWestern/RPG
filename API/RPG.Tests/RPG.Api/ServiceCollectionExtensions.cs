using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RPG.Infrastructure.DbContexts;

namespace RPG.Tests.RPG.Api;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection UseInMemoryDatabase(this IServiceCollection serviceCollection, string dbName) => 
        serviceCollection.Replace(
            new ServiceDescriptor(
                typeof(ApplicationDbContext),
                _ => new ApplicationDbContext(
                    new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase(dbName).Options),
                ServiceLifetime.Scoped));
}
