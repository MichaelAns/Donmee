using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class ProfileView : ContentPage
{
	public ProfileView(ProfileViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}