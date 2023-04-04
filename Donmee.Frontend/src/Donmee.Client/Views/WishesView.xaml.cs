using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class WishesView : ContentPage
{
	public WishesView(WishesViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}