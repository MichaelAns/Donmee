using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class ProfileView : ContentPage
{
	public ProfileView(ProfileViewModel viewModel)
	{
		ProfileViewModel = viewModel;
		BindingContext = ProfileViewModel;

        InitializeComponent();
	}
    public ProfileViewModel ProfileViewModel { get; set; }
}