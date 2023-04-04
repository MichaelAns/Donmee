using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class WishDetailsView : ContentPage
{
	public WishDetailsView(WishDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}