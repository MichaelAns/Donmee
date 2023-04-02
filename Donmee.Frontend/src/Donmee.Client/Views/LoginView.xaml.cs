using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}