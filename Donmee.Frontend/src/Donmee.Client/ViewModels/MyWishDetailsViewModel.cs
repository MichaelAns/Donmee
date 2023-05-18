using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;

namespace Donmee.Client.ViewModels
{
    [QueryProperty(nameof(Wish), "MyWishDetails")]
    public partial class MyWishDetailsViewModel : ViewModelBase
    {
        public MyWishDetailsViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IWishService wishService) : base(navigationService, settingsService)
        {
            WishService = wishService;
        }

        public IWishService WishService { get; set; }

        [ObservableProperty]
        private Wish _wish;


    }
}
