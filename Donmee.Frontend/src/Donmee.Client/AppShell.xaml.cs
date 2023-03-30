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

    // Register the un-TabBar routes
    private static void InitializeRouting()
    {
        Routing.RegisterRoute("Login", typeof(LoginView));
        Routing.RegisterRoute("SignUp", typeof(SignUpView));
        Routing.RegisterRoute("WishDetails", typeof(WishDetailsView));
        Routing.RegisterRoute("MyWishDetails", typeof(MyWishDetailsView));
        Routing.RegisterRoute("SignUp", typeof(SignUpView));
    }


}
