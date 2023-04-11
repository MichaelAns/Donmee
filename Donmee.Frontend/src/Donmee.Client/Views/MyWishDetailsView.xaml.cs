using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class MyWishDetailsView : ContentPage
{
	public MyWishDetailsView(MyWishDetailsViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}