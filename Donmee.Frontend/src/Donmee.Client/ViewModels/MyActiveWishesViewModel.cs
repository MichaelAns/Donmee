using Donmee.Client.Services.Navigation;
using Donmee.Client.Services.Settings;
using Donmee.Client.ViewModels.Base;
using Donmee.DataServices.Wish;
using Frontend.Persistance.Models;
using Frontend.Persistance.Models.Enums;
using System.Collections.ObjectModel;

namespace Donmee.Client.ViewModels
{
    public partial class MyActiveWishesViewModel : ViewModelBase
    {
        public MyActiveWishesViewModel(
            INavigationService navigationService, 
            ISettingsService settingsService,
            IWishService wishService) : base(navigationService, settingsService)
        {
            WishService = wishService;
            GetWishes();
        }

        // Wish service
        public IWishService WishService { get; private set; }        

        private void GetWishes()
        {
            try
            {
                WishService.GetWishesAsync(
                    Guid.Parse(SettingsService.UserId),
                    WishStatus.Active)
                    .ContinueWith(task =>
                    {
                        _wishes = new(task.Result);
                    });
            }
            catch (Exception exc)
            {

                throw;
            }
        }

        // 
        private ObservableCollection<Wish> _wishes;
        public IReadOnlyList<Wish> Wishes => _wishes;

        [ObservableProperty]
        private Wish _selectedWish;        

        [RelayCommand]
        private async Task SelectWishAsync()
        {
            var wish = SelectedWish;
            SelectedWish = null;
            await NavigationService.NavigateToAsync(
                    "/MyWishDetails",
                    new Dictionary<string, object>
                    {
                        {
                                "MyWishDetails",
                                wish
                        }
                    });
        }

        // 

    }
}
