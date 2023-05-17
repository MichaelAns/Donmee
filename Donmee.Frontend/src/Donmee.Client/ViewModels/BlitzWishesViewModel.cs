using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class BlitzWishesViewModel : ViewModelBase
    {
        public BlitzWishesViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IWishService wishService) : base(navigationService, settingsService)
        {
            WishService = wishService;
            //GetWishes();
        }


        private void GetWishes()
        {
            WishService.GetWishesAsync(
                Guid.Parse(SettingsService.UserId),
                WishType.Blitz)
                .ContinueWith(
                task =>
                {
                    _wishes = new(task.Result);
                });
        }

        private ObservableCollection<Wish> _wishes;

        public IWishService WishService { get; private set; }

        public IReadOnlyList<Wish> Wishes => _wishes;
        
        [RelayCommand]
        private async Task DonateAsync()
        {
            
        }
    }
}
