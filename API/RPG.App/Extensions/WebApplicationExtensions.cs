using Microsoft.AspNetCore.Builder;
using RPG.Infrastructure.Events;

namespace RPG.App.Extensions;

public static class WebApplicationExtensions
{
    public static void UseApplication(this WebApplication app)
    {
        app.MapHub<GameEventHub>("/gameEventHub")
            .RequireCors("AllowElectronApp");
    }
}
