using Donmee.Client.ViewModels;

namespace Donmee.Client.Views;

public partial class MyActiveWishesView : ContentPage
{
	public MyActiveWishesView(MyActiveWishesViewModel viewModel)
	{
        MyActiveWishesViewModel = viewModel;
		BindingContext = MyActiveWishesViewModel;
		InitializeComponent();
	}

    public MyActiveWishesViewModel MyActiveWishesViewModel { get; set; }
}