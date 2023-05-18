using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class MyCompletedWishesView : ContentPage
{
	public MyCompletedWishesView(MyCompletedWishesViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}