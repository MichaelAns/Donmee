using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class CreatingWishView : ContentPage
{
	public CreatingWishView(CreatingWishViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}