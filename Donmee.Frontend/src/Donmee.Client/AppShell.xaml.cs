using Donmee.Client.Services.Navigation;
using Donmee.Client.Views;

namespace Donmee.Client;

public partial class AppShell : Shell
{
    public AppShell(INavigationService navigationService)
    {
        _navigationService = navigationService;

        InitializeRouting();

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
    protected override async void OnHandlerChanged()
    {
        base.OnHandlerChanged();

        if (Handler is not null)
        {
            await _navigationService.InitializeAsync();
        }
    }
    private static void InitializeRouting()
    {
        Routing.RegisterRoute("WishDetails", typeof(WishDetailsView));
        Routing.RegisterRoute("MyWishDetails", typeof(MyWishDetailsView));
        Routing.RegisterRoute("CreatingWish", typeof(CreatingWishView));
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string location = args.Current?.Location?.ToString();

        switch(location)
        {
            case @"//Main/Options/Profile":
                ((ProfileView)Shell.Current.CurrentPage).ProfileViewModel.RefreshCommand.Execute(null);
                break;
            case @"//Main/MyWishes/ActiveWishes":
                ((MyActiveWishesView)Shell.Current.CurrentPage).MyActiveWishesViewModel.GetWishes();
                break;
        }

        /*if (location is @"//Main/Options/Profile")
        {
            ((ProfileView)Shell.Current.CurrentPage).ProfileViewModel.RefreshCommand.Execute(null);
        }*/

        base.OnNavigated(args);
    }
}
