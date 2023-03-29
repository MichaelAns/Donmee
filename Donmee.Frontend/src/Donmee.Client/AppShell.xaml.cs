using Donmee.Client.Services.Navigation;

namespace Donmee.Client;

public partial class AppShell : Shell
{
    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeComponent();
    }
    private readonly INavigationService _navigationService;

    protected override async void OnParentSet()
    {
        base.OnParentSet();

        if (Parent is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }


}
