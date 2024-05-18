using System.Collections.Immutable;
using Terminal.Gui;

namespace RPG.Console;

internal class ViewsController<TEntryView> : IViewsController where TEntryView : View
{
    private readonly IEnumerable<View> _views;
    private View _current;

    public ViewsController(ImmutableHashSet<View> views)
    {
        _current = views.Single(x => x.GetType() == typeof(TEntryView));
        _current.Visible = true;
        _current.SetFocus();
        _views = views;
    }

    public void SetFocus(View view)
    {
        _current.Visible = false;
        view.Visible = true;
        view.SetFocus();
        _current = view;
    }
}