using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class RegisterView : ContentPage
{
	public RegisterView(RegisterViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}