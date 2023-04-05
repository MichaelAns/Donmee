using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class MyWishesView : ContentPage
{
	public MyWishesView(MyWishesViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}