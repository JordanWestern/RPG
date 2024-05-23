using Microsoft.Extensions.DependencyInjection;
using Terminal.Gui;

namespace RPG.Console;

internal class Navigate : INavigate
{
    private readonly IServiceProvider _serviceProviders;

    public Navigate(IServiceProvider serviceProviders)
    {
        _serviceProviders = serviceProviders;
    }

    public void To<T>() where T : View => NavigateTo(_serviceProviders.GetRequiredService<T>());

    private static void NavigateTo(View view)
    {
        Application.Top.RemoveAll();
        Application.Top.Add(view);
        Application.Refresh();
    }
}