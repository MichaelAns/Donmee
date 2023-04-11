using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class MyActiveWishesView : ContentPage
{
	public MyActiveWishesView(MyActiveWishesViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}