namespace MauiPeopleApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.PersonDetailPage), typeof(Views.PersonDetailPage));
    }
}
