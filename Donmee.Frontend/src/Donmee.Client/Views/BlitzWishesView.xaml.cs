using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class BlitzWishesView : ContentPage
{
	public BlitzWishesView(BlitzWishesViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}