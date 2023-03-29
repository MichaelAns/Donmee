using Donmee.Client.Services.Navigation;

namespace Donmee.Client;

public partial class App : Application
{
	public App(
		INavigationService navigationService)
	{
		_navigationService = navigationService;

		InitializeComponent();
        MainPage = new AppShell(navigationService);
	}

	private readonly INavigationService _navigationService;
}
